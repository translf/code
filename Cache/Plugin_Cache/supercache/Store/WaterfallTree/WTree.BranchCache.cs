using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace STSdb4.WaterfallTree
{
    public partial class WTree
    {
        private class BranchCache : IEnumerable<KeyValuePair<ILocator, IOperationCollection>>
        {
            private Dictionary<ILocator, IOperationCollection> cache;
            private IOperationCollection Operations;

            /// <summary>
            /// Number of all operations in cache
            /// </summary>
            public int OperationCount { get; private set; }

            public int Count { get; private set; }

            public BranchCache()
            {
            }

            public BranchCache(IOperationCollection operations)
            {
                Operations = operations;
                Count = 1;
                OperationCount = operations.Count;
            }

            private IOperationCollection Obtain(ILocator locator)
            {
                if (Count == 0)
                {
                    Operations = locator.CreateOperationCollection(0);
                    Count++;
                }
                else
                {
                    if (!Operations.Locator.Equals(locator))
                    {
                        if (cache == null)
                        {
                            cache = new Dictionary<ILocator, IOperationCollection>();
                            cache[Operations.Locator] = Operations;
                        }

                        if (!cache.TryGetValue(locator, out Operations))
                        {
                            cache[locator] = Operations = locator.CreateOperationCollection(0);
                            Count++;
                        }
                    }
                }

                return Operations;
            }

            public void Apply(ILocator locator, IOperation operation)
            {
                var operations = Obtain(locator);

                operations.Add(operation);
                OperationCount++;
            }

            public void Apply(IOperationCollection oprs)
            {
                var operations = Obtain(oprs.Locator);

                operations.AddRange(oprs);
                OperationCount += oprs.Count;
            }

            public void Clear()
            {
                cache = null;
                Operations = null;
                Count = 0;
                OperationCount = 0;
            }

            public bool Contains(ILocator locator)
            {
                if (Count == 0)
                    return false;

                if (cache != null)
                    return cache.ContainsKey(locator);

                if (Operations != null)
                    return Operations.Locator.Equals(locator);

                return false;
            }
                        
            public IOperationCollection Exclude(ILocator locator)
            {
                if (Count == 0)
                    return null;

                IOperationCollection operations;

                if (!Operations.Locator.Equals(locator))
                {
                    if (cache == null || !cache.TryGetValue(locator, out operations))
                        return null;

                    cache.Remove(locator);
                }
                else
                {
                    operations = Operations;

                    if (Count == 1)
                        Operations = null;
                    else
                    {
                        cache.Remove(locator);
                        Operations = cache.First().Value;
                        if (cache.Count == 1)
                            cache = null;
                    }
                }

                Count--;
                OperationCount -= operations.Count;

                return operations;
            }

            public IEnumerator<KeyValuePair<ILocator, IOperationCollection>> GetEnumerator()
            {
                IEnumerable<KeyValuePair<ILocator, IOperationCollection>> enumerable;
                if (Count == 0)
                    enumerable = System.Linq.Enumerable.Empty<KeyValuePair<ILocator, IOperationCollection>>();
                else if (cache != null)
                    enumerable = cache;
                else
                    enumerable = new KeyValuePair<ILocator, IOperationCollection>[] { new KeyValuePair<ILocator, IOperationCollection>(Operations.Locator, Operations) };

                return enumerable.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Store(WTree tree, BinaryWriter writer)
            {
                writer.Write(Count);
                if (Count == 0)
                    return;

                //write cache
                foreach (var kv in this)
                {
                    var locator = kv.Key;
                    var operations = kv.Value;

                    //write locator
                    tree.Serialize(writer, locator);

                    //write operations
                    locator.PersistOperations.Write(writer, operations);
                }
            }

            public void Load(WTree tree, BinaryReader reader)
            {
                int count = reader.ReadInt32();
                if (count == 0)
                    return;

                for (int i = 0; i < count; i++)
                {
                    //read locator
                    var locator = tree.Deserialize(reader);

                    //read operations
                    var operations = locator.PersistOperations.Read(reader);

                    Add(locator, operations);
                }
            }

            private void Add(ILocator locator, IOperationCollection operations)
            {
                if (Count > 0)
                {
                    if (cache == null)
                    {
                        cache = new Dictionary<ILocator, IOperationCollection>();
                        cache[Operations.Locator] = Operations;
                    }

                    cache.Add(locator, operations);
                }

                Operations = operations;

                OperationCount += operations.Count;
                Count++;
            }
        }
    }
}
