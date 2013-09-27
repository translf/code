using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.WaterfallTree;
using STSdb4.Data;

namespace STSdb4.Database.Operations
{
    public class OverallOperation : IOperation
    {
        public OverallOperation(int action)
        {
            Code = action;
        }

        public int Code { get; private set; }

        public IData FromKey 
        { 
            get { return null; } 
        }

        public IData ToKey 
        { 
            get { return null; } 
        }

        public bool IsPoint
        {
            get { return false; }
        }

        public bool IsOverall
        {
            get { return true; }
        }

        public bool IsSynchronous { get; protected set; }
    }

    public class ClearOperation : OverallOperation
    {
        public ClearOperation()
            : base(OperationCode.CLEAR)
        {
            base.IsSynchronous = false;
        }
    }

    public class RefreshOperation : OverallOperation
    {
        public RefreshOperation()
            : base(OperationCode.REFRESH)
        {
            base.IsSynchronous = false;
        }
    }

    public class FirstRowOperation : OverallOperation
    {
        public KeyValuePair<IData, IData>? Row;

        public FirstRowOperation(KeyValuePair<IData, IData>? row)
            : base(OperationCode.FIRST_ROW)
        {
            Row = row;
            base.IsSynchronous = true;
        }

        public FirstRowOperation()
            : this(null)
        {
        }
    }

    public class LastRowOperation : OverallOperation
    {
        public KeyValuePair<IData, IData>? Row;

        public LastRowOperation(KeyValuePair<IData, IData>? row)
            : base(OperationCode.LAST_ROW)
        {
            Row = row;
            base.IsSynchronous = true;
        }

        public LastRowOperation()
            : this(null)
        {
        }
    }

    public class CountOperation : OverallOperation
    {
        public long Count;

        public CountOperation(long count)
            : base(OperationCode.COUNT)
        {
            Count = count;
            base.IsSynchronous = true;
        }

        public CountOperation()
            : this(0)
        {
        }
    }

    public class StorageEngineCommitOperation : OverallOperation
    {
        public StorageEngineCommitOperation()
            : base(OperationCode.STORAGE_ENGINE_COMMIT)
        {
            base.IsSynchronous = true;
        }
    }

    public class ExceptionOperation : OverallOperation
    {
        public readonly string Exception;

        public ExceptionOperation(string exception)
            :base(OperationCode.EXCEPTION)
        {
            Exception = exception;
            base.IsSynchronous = true;
        }
    }
}
