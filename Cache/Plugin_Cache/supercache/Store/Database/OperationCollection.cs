using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.General.Patches;
using STSdb4.Database.Operations;
using STSdb4.WaterfallTree;
using System.Collections;
using STSdb4.Data;
using System.Diagnostics;
using STSdb4.General.Extensions;

namespace STSdb4.Database
{
    public class OperationCollection : ListPatch<IOperation>, IOperationCollection
    {
        private OperationCollection(ILocator locator, IOperation[] operations, int commonAction, bool isAllMonotoneAndPoint)
            : base(operations)
        {
            Locator = locator;
            CommonAction = commonAction;
            IsAllMonotoneAndPoint = isAllMonotoneAndPoint;
        }

        public OperationCollection(ILocator locator, int capacity)
            : base(capacity)
        {
            Locator = locator;
            CommonAction = OperationCode.UNDEFINED;
            IsAllMonotoneAndPoint = true;
        }

        public new void Add(IOperation operation)
        {
            if (IsAllMonotoneAndPoint)
            {
                if (Count == 0)
                {
                    IsAllMonotoneAndPoint = operation.IsPoint;
                    CommonAction = operation.Code;
                }
                else
                {
                    if (!operation.IsPoint || Locator.KeyComparer.Compare(operation.FromKey, this[Count - 1].FromKey) <= 0)
                        IsAllMonotoneAndPoint = false;
                }
            }

            if (CommonAction != OperationCode.UNDEFINED)
            {
                if (operation.Code != CommonAction)
                    CommonAction = OperationCode.UNDEFINED;
            }

            base.Add(operation);
        }

        public void AddRange(IOperationCollection operations)
        {
            if (!operations.IsAllMonotoneAndPoint)
                IsAllMonotoneAndPoint = false;
            else
            {
                if (IsAllMonotoneAndPoint && this.Count > 0 && operations.Count > 0 && Locator.KeyComparer.Compare(this[Count - 1].FromKey, operations[0].FromKey) >= 0)
                    IsAllMonotoneAndPoint = false;
            }

            if (operations.CommonAction != this.CommonAction)
            {
                if (this.Count == 0)
                    this.CommonAction = operations.CommonAction;
                else if (operations.Count > 0)
                    this.CommonAction = OperationCode.UNDEFINED;
            }

            var oprs = operations as OperationCollection;

            if (oprs != null)
                base.AddRange(oprs.Array, 0, oprs.Count);
            else
            {
                foreach (var o in oprs)
                    base.Add(o);
            }
        }

        public new void Clear()
        {
            base.Clear();
            CommonAction = OperationCode.UNDEFINED;
            IsAllMonotoneAndPoint = true;
        }

        public IOperationCollection Midlle(int index, int count)
        {
            IOperation[] array = new IOperation[count];
            System.Array.Copy(Array, index, array, 0, count);

            return new OperationCollection(Locator, array, CommonAction, IsAllMonotoneAndPoint);
        }

        public int BinarySearch(IData key, int index, int count)
        {
            Debug.Assert(IsAllMonotoneAndPoint);

            int low = index;
            int high = index + count - 1;

            var comparer = Locator.KeyComparer;

            while (low <= high)
            {
                int mid = (low + high) >> 1;
                int cmp = comparer.Compare(this[mid].FromKey, key);

                if (cmp == 0)
                    return mid;
                if (cmp < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return ~low;
        }

        public int CommonAction { get; private set; }
        public bool IsAllMonotoneAndPoint { get; private set; }

        public ILocator Locator { get; private set; }
    }
}
