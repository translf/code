using System;
using STSdb4.General.Collections;
using STSdb4.Data;
using STSdb4.Database.Operations;
using STSdb4.WaterfallTree;
using System.Collections.Generic;

namespace STSdb4.Database
{
    public sealed class XIndexApply : IApply
    {
        public event ReadOperationDelegate ReadCallback;

        public delegate void ReadOperationDelegate(long handle, bool exist, ILocator path, IData key, IData record);

        public XIndexApply(ILocator locator)
        {
            Locator = locator;
        }

        public bool Internal(IOperationCollection operations)
        {
            return false;
        }

        public bool Leaf(IOperationCollection operations, IDataContainer data)
        {
            var records = (IOrderedSet<IData, IData>)data;

            //sequential optimization
            if (operations.IsAllMonotoneAndPoint && (records.Count == 0 || operations.Locator.KeyComparer.Compare(records.Last.Key, operations[0].FromKey) < 0))
            {
                switch (operations.CommonAction)
                {
                    case OperationCode.REPLACE:
                    case OperationCode.INSERT_OR_IGNORE:
                        {
                            KeyValuePair<IData, IData>[] array = new KeyValuePair<IData, IData>[operations.Count];

                            int idx = 0;
                            foreach (var operation in operations)
                            {
                                ValueOperation opr = (ValueOperation)operation;
                                array[idx++] = new KeyValuePair<IData, IData>(opr.FromKey, opr.Record);
                            }

                            records.AddOrdered(array, 0, array.Length);

                            return true;
                        }
                    case OperationCode.READ:
                    case OperationCode.READ_RANGE:
                    case OperationCode.DELETE:
                    case OperationCode.DELETE_RANGE:
                    case OperationCode.CLEAR:
                    case OperationCode.REFRESH:
                    case OperationCode.REFRESH_POINT:
                    case OperationCode.REFRESH_RANGE:
                        {
                            return false;
                        }
                }
            }

            //standart apply
            bool isModified = false;

            foreach (var opr in operations)
            {
                switch (opr.Code)
                {
                    case OperationCode.REPLACE:
                        {
                            records[opr.FromKey] = ((ReplaceOperation)opr).Record;

                            isModified = true;
                        }
                        break;
                    case OperationCode.INSERT_OR_IGNORE:
                        {
                            if (records.ContainsKey(opr.FromKey))
                                continue;

                            records[opr.FromKey] = ((InsertOrIgnoreOperation)opr).Record;

                            isModified = true;
                        }
                        break;
                    case OperationCode.DELETE:
                        {
                            if (records.Remove(opr.FromKey))
                                isModified = true;
                        }
                        break;
                    case OperationCode.DELETE_RANGE:
                        {
                            if (records.Remove(opr.FromKey, true, opr.ToKey, true))
                                isModified = true;
                        }
                        break;
                    case OperationCode.CLEAR:
                        {
                            records.Clear();
                            isModified = true;
                        }
                        break;
                    case OperationCode.READ:
                        {
                            if (ReadCallback == null)
                                break;

                            IData record;
                            if (records.TryGetValue(opr.FromKey, out record))
                                ReadCallback(((ReadOperation)opr).Handle, true, Locator, opr.FromKey, record);
                            else
                                ReadCallback(((ReadOperation)opr).Handle, false, Locator, opr.FromKey, default(IData));
                        }
                        break;
                    case OperationCode.READ_RANGE:
                        {
                            if (ReadCallback == null)
                                break;

                            foreach (var kv in records.Forward(opr.FromKey, true, opr.ToKey, true))
                                    ReadCallback(((ReadOperation)opr).Handle, true, Locator, opr.FromKey, kv.Value);
                        }
                        break;
                    case OperationCode.REFRESH:
                    case OperationCode.REFRESH_POINT:
                    case OperationCode.REFRESH_RANGE:
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return isModified;
        }

        public ILocator Locator { get; private set; }
    }
}
