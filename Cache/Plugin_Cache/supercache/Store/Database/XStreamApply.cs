using System;
using System.Diagnostics;
using STSdb4.General.Collections;
using STSdb4.Data;
using STSdb4.Database.Operations;
using STSdb4.WaterfallTree;

namespace STSdb4.Database
{
    public class XStreamApply : IApply
    {
        const int BLOCK_SIZE = XFile.BLOCK_SIZE;

        public XStreamApply(ILocator path)
        {
            Locator = path;
        }

        public bool Internal(IOperationCollection operations)
        {
            return false;
        }

        public bool Leaf(IOperationCollection operations, IDataContainer data)
        {
            IOrderedSet<IData, IData> set = (IOrderedSet<IData, IData>)data;
            bool isModified = false;

            foreach (var opr in operations)
            {
                switch (opr.Code)
                {
                    case OperationCode.REPLACE:
                        {
                            if (Replace(set, (ReplaceOperation)opr))
                                isModified = true;
                        }
                        break;
                    case OperationCode.DELETE:
                        {
                            DeleteRangeOperation o = new DeleteRangeOperation(opr.FromKey, opr.FromKey);
                            if (Delete(set, (DeleteRangeOperation)o))
                                isModified = true;
                        }
                        break;
                    case OperationCode.DELETE_RANGE:
                        {
                            if (Delete(set, (DeleteRangeOperation)opr))
                                isModified = true;
                        }
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
            return isModified;
        }

        public ILocator Locator { get; private set; }

        private bool Replace(IOrderedSet<IData, IData> set, ReplaceOperation operation)
        {
            Debug.Assert(operation.IsPoint);

            long from = ((Data<long>)operation.FromKey).Slot0;
            int localFrom = (int)(from % BLOCK_SIZE);
            long baseFrom = from - localFrom;
            Data<long> baseKey = new Data<long>(baseFrom);

            byte[] src = ((Data<byte[]>)operation.Record).Slot0;
            Debug.Assert(src.Length <= BLOCK_SIZE);
            Debug.Assert(baseFrom == BLOCK_SIZE * ((from + src.Length - 1) / BLOCK_SIZE));

            IData tmp;
            if (set.TryGetValue(baseKey, out tmp))
            {
                Data<byte[]> rec = (Data<byte[]>)tmp;

                if (src.Length == BLOCK_SIZE)
                    rec.Slot0 = src;
                else // if(src.Length < BLOCK_SIZE
                {
                    byte[] dst = rec.Slot0;
                    if (dst.Length > localFrom + src.Length)
                        src.CopyTo(dst, localFrom);
                    else
                    {
                        byte[] buffer = new byte[localFrom + src.Length];
                        dst.CopyTo(buffer, 0);
                        src.CopyTo(buffer, localFrom);
                        rec.Slot0 = buffer;
                    }
                }
            }
            else
            {
                if (localFrom == 0)
                    set[baseKey] = new Data<byte[]>(src);
                else
                {
                    byte[] values = new byte[localFrom + src.Length];
                    src.CopyTo(values, localFrom);
                    set[baseKey] = new Data<byte[]>(values);
                }
            }

            return true;
        }

        private bool Delete(IOrderedSet<IData, IData> set, DeleteRangeOperation operation)
        {
            long from = ((Data<long>)operation.FromKey).Slot0;
            long to = ((Data<long>)operation.ToKey).Slot0;

            int localFrom = (int)(from % BLOCK_SIZE);
            int localTo = (int)(to % BLOCK_SIZE);
            long baseFrom = from - localFrom;
            long baseTo = to - localTo;

            long internalFrom = localFrom > 0 ? baseFrom + BLOCK_SIZE : baseFrom;
            long internalTo = localTo < BLOCK_SIZE - 1 ? baseTo - 1 : baseTo;

            bool isModified = false;

            if (internalFrom <= internalTo)
                isModified = set.Remove(new Data<long>(internalFrom), true, new Data<long>(internalTo), true);

            IData tmp;
            Data<byte[]> record;

            if (localFrom > 0 && set.TryGetValue(new Data<long>(baseFrom), out tmp))
            {
                record = (Data<byte[]>)tmp;
                if (localFrom < record.Slot0.Length)
                {
                    Array.Clear(record.Slot0, localFrom, baseFrom < baseTo ? record.Slot0.Length - localFrom : localTo - localFrom + 1);
                    isModified = true;
                }
                if (baseFrom == baseTo)
                    return isModified;
            }

            if (localTo < BLOCK_SIZE - 1 && set.TryGetValue(new Data<long>(baseTo), out tmp))
            {
                record = (Data<byte[]>)tmp;
                if (localTo < record.Slot0.Length - 1)
                {
                    Array.Clear(record.Slot0, 0, localTo + 1);
                    isModified = true;
                }
                else
                    isModified = set.Remove(new Data<long>(baseTo));
            }

            return isModified;
        }
    }
}
