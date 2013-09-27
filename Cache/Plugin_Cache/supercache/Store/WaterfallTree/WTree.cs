using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;
using System.Diagnostics;
using STSdb4.General.Threading;
using STSdb4.Data;

namespace STSdb4.WaterfallTree
{
    public abstract partial class WTree : IDisposable
    {
        private readonly Countdown WorkingFallCount = new Countdown();
        private readonly Branch RootBranch;
        private volatile bool disposed = false;
        private volatile bool Shutdown = false;
        private int Depth = 1;

        public int MAX_OPERATIONS_IN_ROOT = 10000;

        private long globalVersion;

        public long GlobalVersion
        {
            get { return Interlocked.Read(ref globalVersion); }
            set { Interlocked.Exchange(ref globalVersion, value); }
        }

        public readonly IHeap Heap;

        public WTree(IHeap heap)
        {
            if (heap == null)
                throw new NullReferenceException("heap");

            Heap = heap;

            if (Heap.Exists(0))
            {
                //create root branch with fictive type and handle.
                RootBranch = new Branch(this, NodeType.Leaf, 1);

                //read settings & root cache (always at handle 0).
                byte[] buffer = Heap.Read(0);
                using (MemoryStream ms = new MemoryStream(buffer)) 
                {
                    Settings.Deserialize(this, ms);
                    RootBranch.Cache.Load(this, new BinaryReader(ms));
                }
            }
            else
            {
                long headerHandle = Heap.ObtainHandle();
                if (headerHandle != 0)
                    throw new Exception("Logical Error.");

                RootBranch = new Branch(this, NodeType.Leaf);
            }

            CacheThread = new Thread(DoCache);
            CacheThread.Start();
        }

        private void Sink()
        {
            RootBranch.WaitFall();

            if (RootBranch.NodeState != NodeState.None)
            {
                Token token = new Token(CacheSemaphore, new CancellationTokenSource().Token);
                RootBranch.MaintenanceRoot(token);
                RootBranch.Node.Touch(Depth + 1);
                token.CountdownEvent.Wait();
            }

            RootBranch.Fall(Depth + 1, new Token(CacheSemaphore, CancellationToken.None), new Params(WalkMethod.Current, WalkAction.None, null, true));
        }

        public IOperationCollection Execute(IOperationCollection operations)
        {
            if (disposed)
                throw new ObjectDisposedException("WTree");

            lock (RootBranch)
            {
                RootBranch.ApplyToCache(operations);

                if (RootBranch.Cache.OperationCount > MAX_OPERATIONS_IN_ROOT)
                    Sink();
            }

            return null;
        }

        public void Execute(ILocator locator, IOperation operation)
        {
            if (disposed)
                throw new ObjectDisposedException("WTree");

            lock (RootBranch)
            {
                RootBranch.ApplyToCache(locator, operation);

                if (RootBranch.Cache.OperationCount > MAX_OPERATIONS_IN_ROOT)
                    Sink();
            }
        }

        /// <summary>
        /// The hook.
        /// </summary>
        public IDataContainer FindData(ILocator originalLocator, ILocator locator, IData key, Direction direction, out FullKey nearFullKey, out bool hasNearFullKey, ref FullKey lastVisitedFullKey)
        {
            if (disposed)
                throw new ObjectDisposedException("WTree");

            nearFullKey = default(FullKey);
            hasNearFullKey = false;

            var branch = RootBranch;
            Monitor.Enter(branch);

            Params param;
            if (key != null)
                param = new Params(WalkMethod.Cascade, WalkAction.None, null, true, locator, key);
            else
            {
                switch (direction)
                {
                    case Direction.Forward:
                        param = new Params(WalkMethod.CascadeFirst, WalkAction.None, null, true, locator);
                        break;
                    case Direction.Backward:
                        param = new Params(WalkMethod.CascadeLast, WalkAction.None, null, true, locator);
                        break;
                    default:
                        throw new NotSupportedException(direction.ToString());
                }
            }

            branch.Fall(Depth + 1, new Token(CacheSemaphore, CancellationToken.None), param);
            branch.WaitFall();

            switch (direction)
            {
                case Direction.Forward:
                    {
                        while (branch.NodeType == NodeType.Internal)
                        {
                            KeyValuePair<FullKey, Branch> newBranch = ((InternalNode)branch.Node).FindBranch(locator, key, direction, ref nearFullKey, ref hasNearFullKey);

                            Monitor.Enter(newBranch.Value);
                            newBranch.Value.WaitFall();
                            Debug.Assert(!newBranch.Value.Cache.Contains(originalLocator));
                            Monitor.Exit(branch);

                            branch = newBranch.Value;
                        }
                    }
                    break;
                case Direction.Backward:
                    {
                        int depth = Depth;
                        KeyValuePair<FullKey, Branch> newBranch = default(KeyValuePair<FullKey, Branch>);
                        while (branch.NodeType == NodeType.Internal)
                        {
                            InternalNode node = (InternalNode)branch.Node;
                            newBranch = node.Branches[node.Branches.Count - 1];

                            int cmp = newBranch.Key.Locator.CompareTo(lastVisitedFullKey.Locator);
                            if (cmp == 0)
                            {
                                if (lastVisitedFullKey.Key == null)
                                    cmp = -1;
                                else
                                    cmp = newBranch.Key.Locator.KeyComparer.Compare(newBranch.Key.Key, lastVisitedFullKey.Key);
                            }
                            //else
                            //{
                            //    Debug.WriteLine("");
                            //}

                            //newBranch.Key.CompareTo(lastVisitedFullKey) >= 0
                            if (cmp >= 0)
                                newBranch = node.FindBranch(locator, key, direction, ref nearFullKey, ref hasNearFullKey);
                            else
                            {
                                if (node.Branches.Count >= 2)
                                {
                                    hasNearFullKey = true;
                                    nearFullKey = node.Branches[node.Branches.Count - 2].Key;
                                }
                            }
                            
                            Monitor.Enter(newBranch.Value);
                            depth--;
                            newBranch.Value.WaitFall();
                            if (newBranch.Value.Cache.Contains(originalLocator))
                            {
                                newBranch.Value.Fall(depth + 1, new Token(CacheSemaphore, CancellationToken.None), new Params(WalkMethod.Current, WalkAction.None, null, true, originalLocator));
                                newBranch.Value.WaitFall();
                            }
                            Debug.Assert(!newBranch.Value.Cache.Contains(originalLocator));
                            Monitor.Exit(branch);

                            branch = newBranch.Value;
                        }

                        //if (lastVisitedFullKey.Locator.Equals(newBranch.Key.Locator) &&
                        //    (lastVisitedFullKey.Key != null && lastVisitedFullKey.Locator.KeyEqualityComparer.Equals(lastVisitedFullKey.Key, newBranch.Key.Key)))
                        //{
                        //    Monitor.Exit(branch);
                        //    return null;
                        //}

                        lastVisitedFullKey = newBranch.Key;
                    }
                    break;
                default:
                    throw new NotSupportedException(direction.ToString());
            }
            
            IDataContainer data = ((LeafNode)branch.Node).FindData(originalLocator, direction, ref nearFullKey, ref hasNearFullKey);

            Monitor.Exit(branch);

            return data;
        }

        public void Commit(CancellationToken cancellationToken, ILocator locator = default(ILocator), bool hasLocator = false, IData fromKey = null, IData toKey = null)
        {
            if (disposed)
                throw new ObjectDisposedException("WTree");

            Params param;
            if (!hasLocator)
                param = new Params(WalkMethod.CascadeButOnlyLoaded, WalkAction.Store, null, false);
            else
            {
                if (fromKey == null)
                    param = new Params(WalkMethod.CascadeButOnlyLoaded, WalkAction.Store, null, false, locator);
                else
                {
                    if (toKey == null)
                        param = new Params(WalkMethod.CascadeButOnlyLoaded, WalkAction.Store, null, false, locator, fromKey);
                    else
                        param = new Params(WalkMethod.CascadeButOnlyLoaded, WalkAction.Store, null, false, locator, fromKey, toKey);
                }
            }

            lock (RootBranch)
            {
                Token token = new Token(CacheSemaphore, cancellationToken);
                RootBranch.Fall(Depth + 1, token, param);

                token.CountdownEvent.Signal();
                token.CountdownEvent.Wait();

                //write settings & root cache (always at handle 0).
                using (MemoryStream ms = new MemoryStream())
                {
                    Settings.Serialize(this, ms);
                    RootBranch.Cache.Store(this, new BinaryWriter(ms));
                    Heap.Write(0, ms.GetBuffer(), 0, (int)ms.Length);
                    Heap.Commit();
                }
            }
        }

        public void Commit()
        {
            Commit(CancellationToken.None);
        }

        public abstract ILocator MinLocator { get; }
        protected abstract void Serialize(BinaryWriter writer, ILocator path);
        protected abstract ILocator Deserialize(BinaryReader reader);

        #region Cache

        /// <summary>
        /// Branch.NodeID -> node
        /// </summary>
        private readonly ConcurrentDictionary<long, Node> Cache = new ConcurrentDictionary<long, Node>();
        private Thread CacheThread;

        private SemaphoreSlim CacheSemaphore = new SemaphoreSlim(int.MaxValue, int.MaxValue);

        private int cacheCapacity = 30;

        public int CacheCapacity
        {
            get { return cacheCapacity; }
            set
            {
                cacheCapacity = value;

                if (Cache.Count > CacheCapacity * 1.1)
                {
                    lock (Cache)
                        Monitor.Pulse(Cache);
                }
            }
        }

        private void Packet(long id, Node node)
        {
            Debug.Assert(!Cache.ContainsKey(id));
            Cache[id] = node;

            if (Cache.Count > CacheCapacity * 1.1)
            {
                lock (Cache)
                    Monitor.Pulse(Cache);
            }
        }

        private Node Retrieve(long id)
        {
            Node node;
            Cache.TryGetValue(id, out node);

            return node;
        }

        private Node Exclude(long id)
        {
            Node node;
            Cache.TryRemove(id, out node);
            //Debug.Assert(node != null);

            int delta = (int)(CacheCapacity * 1.1 - Cache.Count);
            if (delta > 0)
                CacheSemaphore.Release(delta);

            return node;
        }

        private void DoCache()
        {
            while (!Shutdown)
            {
                while (Cache.Count > CacheCapacity * 1.1)
                {
                    KeyValuePair<long, Node>[] kvs = Cache.ToArray();

                    foreach (var kv in kvs.Where(x => !x.Value.IsRoot).OrderBy(x => x.Value.TouchID).Take(Cache.Count - CacheCapacity))
                        kv.Value.IsExpiredFromCache = true;
                    //Debug.WriteLine(Cache.Count);
                    Token token;
                    lock (RootBranch)
                    {
                        token = new Token(CacheSemaphore, CancellationToken.None);
                        CacheSemaphore = new SemaphoreSlim(0, int.MaxValue);
                        var param = new Params(WalkMethod.CascadeButOnlyLoaded, WalkAction.CacheFlush, null, false);
                        RootBranch.Fall(Depth + 1, token, param);
                    }

                    token.CountdownEvent.Signal();
                    token.CountdownEvent.Wait();
                    CacheSemaphore.Release(int.MaxValue / 2);
                }

                lock (Cache)
                {
                    if (Cache.Count <= CacheCapacity * 1.1)
                        Monitor.Wait(Cache, 1);
                }
            }
        }

        #endregion

        #region IDisposable Members

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Shutdown = true;
                    if (CacheThread != null)
                        CacheThread.Join();

                    WorkingFallCount.Wait();

                    Heap.Close();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        ~WTree()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        #endregion
    }

    public enum Direction
    {
        Backward = -1,
        None = 0,
        Forward = 1
    }
}
