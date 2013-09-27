using STSdb4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.Database.Operations
{
    public abstract class IteratorOperations : RangeOperation
    {
        public int PageCount;
        public List<KeyValuePair<IData, IData>> List;

        public IteratorOperations(int action, int pageCount, IData from, IData to, List<KeyValuePair<IData, IData>> list)
            : base(action, from, to)
        {
            PageCount = pageCount;
            List = list;
            base.IsSynchronous = true;
        }
    }

    public class ForwardOperation : IteratorOperations
    {
        public ForwardOperation(int pageCount, IData from, IData to, List<KeyValuePair<IData, IData>> list)
            : base(OperationCode.FORWARD, pageCount, from, to, list)
        {
        }
    }

    public class BackwardOperation : IteratorOperations
    {
        public BackwardOperation(int pageCount, IData from, IData to, List<KeyValuePair<IData, IData>> list)
            : base(OperationCode.BACKWARD, pageCount, from, to, list)
        {
        }
    }
}
