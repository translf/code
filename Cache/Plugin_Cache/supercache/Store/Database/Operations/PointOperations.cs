using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.WaterfallTree;
using System.Threading;
using STSdb4.Database.Index;
using STSdb4.Data;

namespace STSdb4.Database.Operations
{
    public class PointOperation : IOperation
    {
        private readonly IData key;

        protected PointOperation(int action, IData key)
        {
            Code = action;
            this.key = key;
        }

        public int Code { get; private set; }

        public IData FromKey
        {
            get { return key; }
        }

        public IData ToKey
        {
            get { return key; }
        }

        public bool IsPoint
        {
            get { return true; }
        }

        public bool IsOverall
        {
            get { return false; }
        }

        public override string ToString()
        {
            return ToKey.ToString();
        }

        public bool IsSynchronous { get; protected set; }
    }

    public abstract class ValueOperation : PointOperation
    {
        public IData Record;

        public ValueOperation(int action, IData key, IData record)
            : base(action, key)
        {
            Record = record;
        }
    }

    public class ReplaceOperation : ValueOperation
    {
        public ReplaceOperation(IData key, IData record)
            : base(OperationCode.REPLACE, key, record)
        {
            base.IsSynchronous = false;
        }
    }

    public class InsertOrIgnoreOperation : ValueOperation
    {
        public InsertOrIgnoreOperation(IData key, IData record)
            : base(OperationCode.INSERT_OR_IGNORE, key, record)
        {
            base.IsSynchronous = false;
        }
    }

    public class DeleteOperation : PointOperation
    {
        public DeleteOperation(IData key)
            : base(OperationCode.DELETE, key)
        {
            base.IsSynchronous = false;
        }
    }

    public class ReadOperation : PointOperation
    {
        public readonly long Handle;

        public ReadOperation(IData key, long handle)
            : base(OperationCode.READ, key)
        {
            Handle = handle;
            base.IsSynchronous = true;
        }
    }

    public class RefreshPointOperation : PointOperation
    {
        public RefreshPointOperation(IData key)
            : base(OperationCode.REFRESH_POINT, key)
        {
            base.IsSynchronous = false;
        }
    }

    public abstract class OutValueOperation : ValueOperation
    {
        public OutValueOperation(int action, IData key, IData record)
            : base(action, key, record)
        {
        }
    }

    public class TryGetOperation : OutValueOperation
    {
        public TryGetOperation(IData key, IData record)
            : base(OperationCode.TRY_GET, key, record)
        {
            base.IsSynchronous = true;
        }

        public TryGetOperation(IData key)
            : this(key, null)
        {
        }
    }

    public abstract class OutKeyValueOperation : PointOperation
    {
        public KeyValuePair<IData, IData>? KeyValue;

        public OutKeyValueOperation(int action, IData key, KeyValuePair<IData, IData>? keyValue)
            : base(action, key)
        {
            KeyValue = keyValue;
            base.IsSynchronous = true;
        }
    }

    public class FindNextOperation : OutKeyValueOperation
    {
        public FindNextOperation(IData key, KeyValuePair<IData, IData>? keyValue)
            : base(OperationCode.FIND_NEXT, key, keyValue)
        {
        }

        public FindNextOperation(IData key)
            : this(key, null)
        {
        }
    }

    public class FindAfterOperation : OutKeyValueOperation
    {
        public FindAfterOperation(IData key, KeyValuePair<IData, IData>? keyValue)
            : base(OperationCode.FIND_AFTER, key, keyValue)
        {
        }

        public FindAfterOperation(IData key)
            : this(key, null)
        {
        }
    }

    public class FindPrevOperation : OutKeyValueOperation
    {
        public FindPrevOperation(IData key, KeyValuePair<IData, IData>? keyValue)
            : base(OperationCode.FIND_PREV, key, keyValue)
        {
        }

        public FindPrevOperation(IData key)
            : this(key, null)
        {
        }
    }

    public class FindBeforeOperation : OutKeyValueOperation
    {
        public FindBeforeOperation(IData key, KeyValuePair<IData, IData>? keyValue)
            : base(OperationCode.FIND_BEFORE, key, keyValue)
        {
        }

        public FindBeforeOperation(IData key)
            : this(key, null)
        {
        }
    }
}
