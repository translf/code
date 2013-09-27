using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.WaterfallTree;
using STSdb4.Data;
using STSdb4.General.Collections;

namespace STSdb4.Database.Operations
{
    public class RangeOperation : IOperation
    {
        private readonly IData from;
        private readonly IData to;

        protected RangeOperation(int action, IData from, IData to)
        {
            Code = action;
            this.from = from;
            this.to = to;
        }

        protected RangeOperation(int action)
        {
            Code = action;
        }

        public int Code { get; private set; }

        public IData FromKey
        {
            get { return from; }
        }

        public IData ToKey
        {
            get { return to; }
        }

        public bool IsPoint
        {
            get { return false; }
        }

        public bool IsOverall
        {
            get { return false; }
        }

        public bool IsSynchronous { get; protected set; }
    }

    public class DeleteRangeOperation : RangeOperation
    {
        public DeleteRangeOperation(IData from, IData to)
            : base(OperationCode.DELETE_RANGE, from, to)
        {
            base.IsSynchronous = false;
        }
    }

    public class ReadRangeOperation : RangeOperation
    {
        public readonly long Handle;

        public ReadRangeOperation(IData from, IData to, long handle)
            : base(OperationCode.READ_RANGE, from, to)
        {
            Handle = handle;
            base.IsSynchronous = false;
        }
    }

    public class RefreshRangeOperation : RangeOperation
    {
        public RefreshRangeOperation(IData from, IData to)
            : base(OperationCode.REFRESH_RANGE, from, to)
        {
            base.IsSynchronous = false;
        }
    }
}
