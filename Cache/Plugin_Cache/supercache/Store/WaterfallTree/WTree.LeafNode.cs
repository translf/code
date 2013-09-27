﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using STSdb4.General.Compression;

namespace STSdb4.WaterfallTree
{
    public partial class WTree
    {
        private sealed class LeafNode : Node
        {
            public double FillPercentage { get; protected set; }

            public readonly Dictionary<ILocator, IDataContainer> Container;

            public LeafNode(Branch branch, bool isModified)
                : base(branch)
            {
                Debug.Assert(branch.NodeType == NodeType.Leaf);

                Container = new Dictionary<ILocator, IDataContainer>();
                IsModified = isModified;
            }

            public override void Apply(IOperationCollection operations)
            {
                ILocator locator = operations.Locator;

                IDataContainer data;
                if (Container.TryGetValue(locator, out data))
                {
                    FillPercentage -= data.FillPercentage;

                    if (locator.Apply.Leaf(operations, data))
                        IsModified = true;

                    FillPercentage += data.FillPercentage;

                    //if (data.IsEmpty)
                    //    Container.Remove(locator);
                }
                else
                {
                    data = locator.CreateDataContainer();
                    Debug.Assert(data != null);
                    if (locator.Apply.Leaf(operations, data))
                        IsModified = true;

                    FillPercentage += data.FillPercentage;

                    if (!data.IsEmpty)
                        Container.Add(locator, data);
                }
            }

            public override Node Split()
            {
                double HALF_PERCENTAGE = FillPercentage / 2;

                Branch rightBranch = new Branch(Branch.Tree, NodeType.Leaf);
                LeafNode rightNode = ((LeafNode)rightBranch.Node);
                var rightContainer = rightNode.Container;

                double leftPercentage = 0;
                KeyValuePair<ILocator, IDataContainer> specialCase = new KeyValuePair<ILocator, IDataContainer>(default(ILocator), null);

                if (Container.Count == 1)
                {
                    var kv = Container.First();
                    var data = kv.Value.Split(HALF_PERCENTAGE);
                    Debug.Assert(!data.IsEmpty);
                    rightContainer.Add(kv.Key, data);
                    leftPercentage = FillPercentage - data.FillPercentage;
                }
                else //if (Container.Count > 1)
                {
                    var enumerator = Container.OrderBy(x => x.Key).GetEnumerator();

                    List<ILocator> emptyContainers = new List<ILocator>();

                    //the left part
                    while (enumerator.MoveNext())
                    {
                        var kv = enumerator.Current;
                        if (kv.Value.IsEmpty)
                        {
                            emptyContainers.Add(kv.Key);
                            continue;
                        }

                        leftPercentage += kv.Value.FillPercentage;
                        if (leftPercentage < HALF_PERCENTAGE)
                            continue;

                        if (leftPercentage > HALF_PERCENTAGE)
                        {
                            var data = kv.Value.Split(leftPercentage - HALF_PERCENTAGE);
                            if (!data.IsEmpty)
                            {
                                specialCase = new KeyValuePair<ILocator, IDataContainer>(kv.Key, data);
                                leftPercentage -= data.FillPercentage;
                            }
                        }

                        break;
                    }

                    //the right part
                    while (enumerator.MoveNext())
                    {
                        var kv = enumerator.Current;
                        if (kv.Value.IsEmpty)
                        {
                            emptyContainers.Add(kv.Key);
                            continue;
                        }

                        rightContainer[kv.Key] = kv.Value;
                    }

                    foreach (var kv in rightContainer)
                        Container.Remove(kv.Key);

                    foreach (var key in emptyContainers)
                        Container.Remove(key);

                    if (specialCase.Value != null) //have special case?
                        rightContainer[specialCase.Key] = specialCase.Value;
                }

                rightNode.FillPercentage = FillPercentage - leftPercentage;
                FillPercentage = leftPercentage;
                rightNode.TouchID = TouchID;
                IsModified = true;

                return rightNode;
            }

            public override void Merge(Node node)
            {
                foreach (var kv in ((LeafNode)node).Container)
                {
                    IDataContainer data;
                    if (!Container.TryGetValue(kv.Key, out data))
                        Container[kv.Key] = data = kv.Value;
                    else
                    {
                        FillPercentage -= data.FillPercentage;
                        data.Merge(kv.Value);
                    }

                    FillPercentage += data.FillPercentage;
                }

                if (TouchID < node.TouchID)
                    TouchID = node.TouchID;

                IsModified = true;
            }

            public override bool IsOverflow
            {
                get { return FillPercentage > 103; }
            }

            public override bool IsUnderflow
            {
                get
                {
                    if (IsRoot)
                        return false;

                    return FillPercentage < 47;
                }
            }

            public override FullKey FirstKey
            {
                get
                {
                    var kv = (Container.Count == 1) ? Container.First() : Container.OrderBy(x => x.Key).First();

                    return new FullKey(kv.Key, kv.Value.FirstKey);
                }
            }

            public override void Store(Stream stream)
            {
                BinaryWriter writer = new BinaryWriter(stream);
                CountCompression.Serialize(writer, 1); //structure version

                CountCompression.Serialize(writer, checked((ulong)Branch.NodeHandle));

                CountCompression.Serialize(writer, checked((ulong)Container.Count));
                foreach (var kv in Container)
                {
                    Branch.Tree.Serialize(writer, kv.Key);
                    kv.Key.PersistDataContainer.Write(writer, kv.Value);
                }

                IsModified = false;
            }

            public override void Load(Stream stream)
            {
                BinaryReader reader = new BinaryReader(stream);

                int version = (int)CountCompression.Deserialize(reader);
                switch (version)
                {
                    case 1:
                        {
                            long id = (long)CountCompression.Deserialize(reader);
                            if (id != Branch.NodeHandle)
                                throw new Exception("Wtree logical error.");

                            int count = (int)CountCompression.Deserialize(reader);
                            for (int i = 0; i < count; i++)
                            {
                                ILocator path = Branch.Tree.Deserialize(reader);
                                IDataContainer data = path.PersistDataContainer.Read(reader);
                                Container[path] = data;

                                FillPercentage += data.FillPercentage;
                            }
                        }
                        break;
                    default:
                        throw new NotSupportedException(string.Format("Leaf node version {0}", version));
                }

                IsModified = false;
            }

            public IDataContainer FindData(ILocator locator, Direction direction, ref FullKey nearFullKey, ref bool hasNearFullKey)
            {
                IDataContainer data = null;
                Container.TryGetValue(locator, out data);
                if (direction == Direction.None)
                    return data;

                if (Container.Count == 1 && data != null)
                    return data;

                IDataContainer nearData = null;
                if (direction == Direction.Backward)
                {
                    bool havePrev = false;
                    ILocator prev = default(ILocator);

                    foreach (var kv in Container)
                    {
                        if (kv.Key.CompareTo(locator) < 0)
                        {
                            if (!havePrev || kv.Key.CompareTo(prev) > 0)
                            {
                                prev = kv.Key;
                                nearData = kv.Value;
                                havePrev = true;
                            }
                        }
                    }

                    if (havePrev)
                    {
                        hasNearFullKey = true;
                        nearFullKey = new FullKey(prev, nearData.LastKey);
                    }
                }
                else //if (direction == Direction.Forward)
                {
                    bool haveNext = false;
                    ILocator next = default(ILocator);

                    foreach (var kv in Container)
                    {
                        if (kv.Key.CompareTo(locator) > 0)
                        {
                            if (!haveNext || kv.Key.CompareTo(next) < 0)
                            {
                                next = kv.Key;
                                nearData = kv.Value;
                                haveNext = true;
                            }
                        }
                    }

                    if (haveNext)
                    {
                        hasNearFullKey = true;
                        nearFullKey = new FullKey(next, nearData.FirstKey);
                    }
                }

                return data;
            }
        }
    }
}
