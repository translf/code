using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using STSdb4.General.Compression;
using STSdb4.General.Patches;
using STSdb4.General.Collections;
using STSdb4.General.Comparers;

namespace STSdb4.WaterfallTree
{
    public partial class WTree
    {
        [DebuggerDisplay("Count = {Count}")]
        private class BranchCollection : ListPatch<KeyValuePair<FullKey, Branch>>
        {
            public static readonly KeyValuePairComparer<FullKey, Branch> Comparer = new KeyValuePairComparer<FullKey, Branch>(Comparer<FullKey>.Default);

            public BranchCollection()
            {
            }

            public BranchCollection(int capacity)
                : base(capacity)
            {
            }


            public BranchCollection(params KeyValuePair<FullKey, Branch>[] array)
                : base(array)
            {
            }

            public BranchCollection(IEnumerable<KeyValuePair<FullKey, Branch>> collection)
                : base(collection)
            {
            }

            public int BinarySearch(FullKey locator, int index, int length, IComparer<KeyValuePair<FullKey, Branch>> comparer)
            {
                return BinarySearch(new KeyValuePair<FullKey, Branch>(locator, null), index, length, comparer);
            }

            public int BinarySearch(FullKey locator, int index, int length)
            {
                return BinarySearch(locator, index, length, BranchCollection.Comparer);
            }

            public int BinarySearch(FullKey locator)
            {
                return BinarySearch(locator, 0, Count);
            }

            public void Add(FullKey locator, Branch branch)
            {
                Add(new KeyValuePair<FullKey, Branch>(locator, branch));
            }

            public IEnumerable<KeyValuePair<FullKey, Branch>> Range(int fromIndex, int toIndex)
            {
                for (int i = fromIndex; i <= toIndex; i++)
                    yield return this[i];
            }

            public void Store(WTree tree, BinaryWriter writer)
            {
                CountCompression.Serialize(writer, checked((ulong)Count));

                Debug.Assert(Count > 0);
                writer.Write((byte)this[0].Value.NodeType);

                for (int i = 0; i < Count; i++)
                {
                    var kv = this[i];
                    FullKey fullkey = kv.Key;
                    Branch branch = kv.Value;
                    //lock (branch)
                    //{
                    //}

                    //write locator
                    tree.Serialize(writer, fullkey.Locator);
                    fullkey.Locator.PersistKey.Write(writer, fullkey.Key);

                    //write branch info
                    writer.Write(branch.NodeHandle);                    
                    writer.Write((int)branch.NodeState);
                    
                    branch.Cache.Store(tree, writer);                    
                }
            }

            public void Load(WTree tree, BinaryReader reader)
            {
                int count = (int)CountCompression.Deserialize(reader);
                Capacity = count;

                NodeType nodeType = (NodeType)reader.ReadByte();

                for (int i = 0; i < count; i++)
                {
                    //read locator
                    var path = tree.Deserialize(reader);
                    var key = path.PersistKey.Read(reader);
                    var locator = new FullKey(path, key);

                    //read branch info
                    long nodeID = reader.ReadInt64();
                    NodeState nodeState = (NodeState)reader.ReadInt32();

                    Branch branch = new Branch(tree, nodeType, nodeID);
                    branch.NodeState = nodeState;

                    branch.Cache.Load(tree, reader);

                    Add(new KeyValuePair<FullKey, Branch>(locator, branch));
                }
            }
        }
    }
}
