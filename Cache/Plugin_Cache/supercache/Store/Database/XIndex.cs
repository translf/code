using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using STSdb4.General.Collections;
using STSdb4.General.Extensions;
using STSdb4.Data;
using STSdb4.Database.Operations;
using STSdb4.WaterfallTree;

namespace STSdb4.Database
{
    public partial class XIndex : IIndex<IData, IData>
    {
        private IOperationCollection operations;

        public readonly StorageEngine StorageEngine;

        //public event Apply.ReadOperationDelegate PendingRead;

        internal XIndex(StorageEngine storageEngine, ILocator locator)
        {
            StorageEngine = storageEngine;
            Locator = locator;

            operations = locator.CreateOperationCollection(256);

            //((Apply)Path.DataDescriptor.Apply).ReadCallback += new Apply.ReadOperationDelegate(Apply_ReadCallback);
        }

        ~XIndex()
        {
            Flush();
        }

        //private void Apply_ReadCallback(long handle, bool exist, Path path, IKey key, IRecord record)
        //{
        //    if (!Path.Equals(path))
        //        return;

        //    if (PendingRead != null)
        //        PendingRead(handle, exist, path, key, record);
        //}

        //private void Read(IKey key, long handle)
        //{
        //    InternalExecute(new ReadOperation(key, handle));
        //}

        private void InternalExecute(IOperation operation)
        {
            if (operations.Capacity == 0)
            {
                StorageEngine.Execute(Locator, operation);
                return;
            }

            operations.Add(operation);
            if (operations.Count == operations.Capacity)
                Flush();
        }

        #region IIndex Membres

        public ILocator Locator { get; private set; }

        public void Execute(IOperation operation)
        {
            InternalExecute(operation);
        }

        public void Execute(IOperationCollection operations)
        {
            foreach (var operation in operations)
                Execute(operation);
        }

        public void Flush()
        {
            if (operations.Count == 0)
                return;

            StorageEngine.Execute(operations);
            operations.Clear();
        }

        #endregion

        #region IIndex<IKey, IRecord>

        public IData this[IData key]
        {
            get
            {
                IData record;
                if (!TryGet(key, out record))
                    throw new KeyNotFoundException(key.ToString());

                return record;
            }
            set
            {
                Replace(key, value);
            }
        }

        public void Replace(IData key, IData record)
        {
            Execute(new ReplaceOperation(key, record));
        }

        public void InsertOrIgnore(IData key, IData record)
        {
            Execute(new InsertOrIgnoreOperation(key, record));
        }

        public void Delete(IData key)
        {
            Execute(new DeleteOperation(key));
        }

        public void Delete(IData fromKey, IData toKey)
        {
            Execute(new DeleteRangeOperation(fromKey, toKey));
        }

        public void Clear()
        {
            Execute(new ClearOperation());
        }

        public bool Exists(IData key)
        {
            IData record;
            return TryGet(key, out record);
        }

        public bool TryGet(IData key, out IData record)
        {
            Flush();

            StorageEngine.FullKey nearFullKey;
            bool haveNearLocator;
            WTree.FullKey lastVisitedFullKey = default(WTree.FullKey);
            var records = (IOrderedSet<IData, IData>)StorageEngine.FindData(Locator, Locator, key, Direction.Forward, out nearFullKey, out haveNearLocator, ref lastVisitedFullKey);
            if (records == null)
            {
                record = default(IData);
                return false;
            }

            return records.TryGetValue(key, out record);
        }

        public IData Find(IData key)
        {
            IData record;
            TryGet(key, out record);

            return record;
        }

        public IData TryGetOrDefault(IData key, IData defaultRecord)
        {
            IData record;
            if (!TryGet(key, out record))
                return defaultRecord;

            return record;
        }

        public KeyValuePair<IData, IData>? FindNext(IData key)
        {
            foreach (var kv in Forward(key, true, default(IData), false))
                return kv;

            return null;
        }

        public KeyValuePair<IData, IData>? FindAfter(IData key)
        {
            var comparer = Locator.KeyComparer;

            foreach (var kv in Forward(key, true, default(IData), false))
            {
                if (comparer.Compare(kv.Key, key) == 0)
                    continue;

                return kv;
            }

            return null;
        }

        public KeyValuePair<IData, IData>? FindPrev(IData key)
        {
            foreach (var kv in Backward(key, true, default(IData), false))
                return kv;

            return null;
        }

        public KeyValuePair<IData, IData>? FindBefore(IData key)
        {
            var comparer = Locator.KeyComparer;

            foreach (var kv in Backward(key, true, default(IData), false))
            {
                if (comparer.Compare(kv.Key, key) == 0)
                    continue;

                return kv;
            }

            return null;
        }

        public IEnumerable<KeyValuePair<IData, IData>> Forward()
        {
            return Forward(default(IData), false, default(IData), false);
        }

        public IEnumerable<KeyValuePair<IData, IData>> Forward(IData from, bool hasFrom, IData to, bool hasTo)
        {
            if (hasFrom && hasTo && Locator.KeyComparer.Compare(from, to) > 0)
                throw new ArgumentException("from > to");

            Flush();

            StorageEngine.FullKey nearFullKey;
            bool hasNearFullKey;
            WTree.FullKey lastVisitedFullKey = default(WTree.FullKey);
            IOrderedSet<IData, IData> records;

            records = (IOrderedSet<IData, IData>)StorageEngine.FindData(Locator, Locator, hasFrom ? from : null, Direction.Forward, out nearFullKey, out hasNearFullKey, ref lastVisitedFullKey);

            if (records == null)
            {
                if (!hasNearFullKey || !nearFullKey.Locator.Equals(Locator))
                    yield break;

                records = (IOrderedSet<IData, IData>)StorageEngine.FindData(Locator, nearFullKey.Locator, nearFullKey.Key, Direction.Forward, out nearFullKey, out hasNearFullKey, ref lastVisitedFullKey);
            }

            while (records != null)
            {
                Task task = null;
                IOrderedSet<IData, IData> recs = null;

                if (hasNearFullKey && nearFullKey.Locator.Equals(Locator))
                {
                    if (hasTo && records.Count > 0 && Locator.KeyComparer.Compare(records.First.Key, to) > 0)
                        break;
                    
                    task = Task.Factory.StartNew(() =>
                    {
                        recs = (IOrderedSet<IData, IData>)StorageEngine.FindData(Locator, nearFullKey.Locator, nearFullKey.Key, Direction.Forward, out nearFullKey, out hasNearFullKey, ref lastVisitedFullKey);
                    });
                }

                foreach (var record in records.Forward(from, hasFrom, to, hasTo))
                    yield return record;

                if (task != null)
                    task.Wait();

                records = recs;
            }
        }

        public IEnumerable<KeyValuePair<IData, IData>> Backward()
        {
            return Backward(default(IData), false, default(IData), false);
        }

        public IEnumerable<KeyValuePair<IData, IData>> Backward(IData to, bool hasTo, IData from, bool hasFrom)
        {
            if (hasFrom && hasTo && Locator.KeyComparer.Compare(from, to) > 0)
                throw new ArgumentException("from > to");

            Flush();

            WTree.FullKey nearFullKey;
            bool hasNearFullKey;
            IOrderedSet<IData, IData> records;

            WTree.FullKey lastVisitedFullKey = new WTree.FullKey(Locator, to);
            records = (IOrderedSet<IData, IData>)StorageEngine.FindData(Locator, Locator, hasTo ? to : null, Direction.Backward, out nearFullKey, out hasNearFullKey, ref lastVisitedFullKey);

            if (records == null)
                yield break;

            while (records != null)
            {
                Task task = null;
                IOrderedSet<IData, IData> recs = null;

                //if (records.Count > 0)
                //    lastVisitedFullKey = new WTree.FullKey(Locator, records.First.Key);

                if (hasNearFullKey)
                {
                    if (hasFrom && records.Count > 0 && Locator.KeyComparer.Compare(records.Last.Key, from) < 0)
                        break;

                    task = Task.Factory.StartNew(() =>
                    {
                        recs = (IOrderedSet<IData, IData>)StorageEngine.FindData(Locator, nearFullKey.Locator, nearFullKey.Key, Direction.Backward, out nearFullKey, out hasNearFullKey, ref lastVisitedFullKey);
                    });
                }

                foreach (var record in records.Backward(to, hasTo, from, hasFrom))
                    yield return record;

                if (task != null)
                    task.Wait();

                if (recs == null)
                    break;

                if (recs.Count > 0 && records.Count > 0)
                {
                    if (Locator.KeyComparer.Compare(recs.First.Key, records.First.Key) >= 0)
                        break;
                }

                records = recs;
            }
        }

        public KeyValuePair<IData, IData> FirstRow
        {
            get { return Forward().First(); }
        }

        public KeyValuePair<IData, IData> LastRow
        {
            get { return Backward().First(); }
        }

        public long Count()
        {
            return this.LongCount();
        }

        public IEnumerator<KeyValuePair<IData, IData>> GetEnumerator()
        {
            return Forward().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public int OperationQueueCapacity
        {
            get { return operations.Capacity; }
            set
            {
                Flush();

                operations = Locator.CreateOperationCollection(value);
            }
        }
    }
}
