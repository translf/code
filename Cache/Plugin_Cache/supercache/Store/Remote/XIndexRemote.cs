using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.Database;
using STSdb4.Data;
using STSdb4.WaterfallTree;
using System.Collections;
using STSdb4.Database.Operations;
using STSdb4.General.Collections;
using STSdb4.Remote;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace STSdb4.Remote
{
    public class XIndexRemote : IIndex<IData, IData>
    {
        private int PageCapacity = 100000;
        private IOperationCollection operations;

        public readonly StorageEngineClient StorageEngine;

        internal XIndexRemote(StorageEngineClient storageEngine, ILocator locator)
        {
            StorageEngine = storageEngine;
            Locator = locator;

            operations = locator.CreateOperationCollection(100 * 1024);
        }

        ~XIndexRemote()
        {
            Flush();
        }

        private void InternalExecute(IOperation operation)
        {
            if (operations.Capacity == 0)
            {
                OperationCollection oprs = new OperationCollection(Locator, 1);
                oprs.Add(operation);

                var result = StorageEngine.Execute(oprs);
                SetResult(operations, result);

                return;
            }

            operations.Add(operation);
            if (operations.Count == operations.Capacity || operation.IsSynchronous)
                Flush();
        }

        #region IIndex Membres

        public ILocator Locator { get; private set; }

        public void Execute(IOperation operation)
        {
            InternalExecute(operation);
        }

        public void Execute(IOperationCollection operations)
        {
            foreach (var operation in operations)
                Execute(operation);
        }

        public void Flush()
        {
            if (operations.Count == 0)
                return;

            var result = StorageEngine.Execute(operations);
            SetResult(operations, result);

            operations.Clear();
        }

        #endregion

        #region IIndex<IKey, IRecord>

        public IData this[IData key]
        {
            get
            {
                IData record;
                if (!TryGet(key, out record))
                    throw new KeyNotFoundException(key.ToString());

                return record;
            }
            set
            {
                Replace(key, value);
            }
        }

        public void Replace(IData key, IData record)
        {
            Execute(new ReplaceOperation(key, record));
        }

        public void InsertOrIgnore(IData key, IData record)
        {
            Execute(new InsertOrIgnoreOperation(key, record));
        }

        public void Delete(IData key)
        {
            Execute(new DeleteOperation(key));
        }

        public void Delete(IData fromKey, IData toKey)
        {
            Execute(new DeleteRangeOperation(fromKey, toKey));
        }

        public void Clear()
        {
            Execute(new ClearOperation());
        }

        public bool Exists(IData key)
        {
            IData record;

            return TryGet(key, out record);
        }

        public bool TryGet(IData key, out IData record)
        {
            var operation = new TryGetOperation(key);
            Execute(operation);

            record = operation.Record;

            return record != null;
        }

        public IData Find(IData key)
        {
            IData record;
            TryGet(key, out record);

            return record;
        }

        public IData TryGetOrDefault(IData key, IData defaultRecord)
        {
            IData record;
            if (!TryGet(key, out record))
                return defaultRecord;

            return record;
        }

        public KeyValuePair<IData, IData>? FindNext(IData key)
        {
            var operation = new FindNextOperation(key);
            Execute(operation);

            return operation.KeyValue;
        }

        public KeyValuePair<IData, IData>? FindAfter(IData key)
        {
            var operation = new FindAfterOperation(key);
            Execute(operation);

            return operation.KeyValue;
        }

        public KeyValuePair<IData, IData>? FindPrev(IData key)
        {
            var operation = new FindPrevOperation(key);
            Execute(operation);

            return operation.KeyValue;
        }

        public KeyValuePair<IData, IData>? FindBefore(IData key)
        {
            var operation = new FindBeforeOperation(key);
            Execute(operation);

            return operation.KeyValue;
        }

        public IEnumerable<KeyValuePair<IData, IData>> Forward()
        {
            return Forward(default(IData), false, default(IData), false);
        }

        public IEnumerable<KeyValuePair<IData, IData>> Forward(IData from, bool hasFrom, IData to, bool hasTo)
        {
            if (hasFrom && hasTo && Locator.KeyComparer.Compare(from, to) > 0)
                throw new ArgumentException("from > to");

            from = hasFrom ? from : default(IData);
            to = hasTo ? to : default(IData);

            List<KeyValuePair<IData, IData>> records = null;
            IData nextKey = null;

            var operation = new ForwardOperation(PageCapacity, from, to, null);
            Execute(operation);

            records = operation.List;
            nextKey = records != null && records.Count == PageCapacity ? records[records.Count - 1].Key : null;

            while (records != null)
            {
                Task task = null;
                List<KeyValuePair<IData, IData>> _records = null;

                int returnCount = nextKey != null ? records.Count - 1 : records.Count;

                if (nextKey != null)
                {
                    task = Task.Factory.StartNew(() =>
                    {
                        var _operation = new ForwardOperation(PageCapacity, nextKey, to, null);
                        Execute(_operation);

                        _records = _operation.List;
                        nextKey = _records != null && _records.Count == PageCapacity ? _records[_records.Count - 1].Key : null;
                    });
                }

                for (int i = 0; i < returnCount; i++)
                    yield return records[i];

                records = null;

                if (task != null)
                    task.Wait();

                if (_records != null)
                    records = _records;
            }
        }

        public IEnumerable<KeyValuePair<IData, IData>> Backward()
        {
            return Backward(default(IData), false, default(IData), false);
        }

        public IEnumerable<KeyValuePair<IData, IData>> Backward(IData to, bool hasTo, IData from, bool hasFrom)
        {
            if (hasFrom && hasTo && Locator.KeyComparer.Compare(from, to) > 0)
                throw new ArgumentException("from > to");

            from = hasFrom ? from : default(IData);
            to = hasTo ? to : default(IData);

            List<KeyValuePair<IData, IData>> records = null;
            IData nextKey = null;

            var operation = new BackwardOperation(PageCapacity, to, from, null);
            Execute(operation);

            records = operation.List;
            nextKey = records != null && records.Count == PageCapacity ? records[records.Count - 1].Key : null;

            while (records != null)
            {
                Task task = null;
                List<KeyValuePair<IData, IData>> _records = null;

                int returnCount = nextKey != null ? records.Count - 1 : records.Count;

                if (nextKey != null)
                {
                    task = Task.Factory.StartNew(() =>
                    {
                        var _operation = new BackwardOperation(PageCapacity, nextKey, from, null);
                        Execute(_operation);

                        _records = _operation.List;
                        nextKey = _records != null && _records.Count == PageCapacity ? _records[_records.Count - 1].Key : null;
                    });
                }

                for (int i = 0; i < returnCount; i++)
                    yield return records[i];

                records = null;

                if (task != null)
                    task.Wait();

                if (_records != null)
                    records = _records;
            }
        }

        public KeyValuePair<IData, IData> FirstRow
        {
            get
            {
                var operation = new FirstRowOperation();
                Execute(operation);

                return operation.Row.Value;
            }
        }

        public KeyValuePair<IData, IData> LastRow
        {
            get
            {
                var operation = new LastRowOperation();
                Execute(operation);

                return operation.Row.Value;
            }
        }

        public long Count()
        {
            var operation = new CountOperation();
            Execute(operation);

            return operation.Count;
        }

        public IEnumerator<KeyValuePair<IData, IData>> GetEnumerator()
        {
            return Forward().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        private void SetResult(IOperationCollection operations, IOperationCollection resultOperations)
        {
            var operation = operations[operations.Count - 1];
            if (!operation.IsSynchronous)
                return;

            var resultOperation = resultOperations[resultOperations.Count - 1];

            try
            {
                switch (operation.Code)
                {
                    case OperationCode.TRY_GET:
                        ((TryGetOperation)operation).Record = ((TryGetOperation)resultOperation).Record;
                        break;
                    case OperationCode.FORWARD:
                        ((ForwardOperation)operation).List = ((ForwardOperation)resultOperation).List;
                        break;
                    case OperationCode.BACKWARD:
                        ((BackwardOperation)operation).List = ((BackwardOperation)resultOperation).List;
                        break;
                    case OperationCode.FIND_NEXT:
                        ((FindNextOperation)operation).KeyValue = ((FindNextOperation)resultOperation).KeyValue;
                        break;
                    case OperationCode.FIND_AFTER:
                        ((FindAfterOperation)operation).KeyValue = ((FindAfterOperation)resultOperation).KeyValue;
                        break;
                    case OperationCode.FIND_PREV:
                        ((FindPrevOperation)operation).KeyValue = ((FindPrevOperation)resultOperation).KeyValue;
                        break;
                    case OperationCode.FIND_BEFORE:
                        ((FindBeforeOperation)operation).KeyValue = ((FindBeforeOperation)resultOperation).KeyValue;
                        break;
                    case OperationCode.FIRST_ROW:
                        ((FirstRowOperation)operation).Row = ((FirstRowOperation)resultOperation).Row;
                        break;
                    case OperationCode.LAST_ROW:
                        ((LastRowOperation)operation).Row = ((LastRowOperation)resultOperation).Row;
                        break;
                    case OperationCode.COUNT:
                        ((CountOperation)operation).Count = ((CountOperation)resultOperation).Count;
                        break;
                    case OperationCode.STORAGE_ENGINE_COMMIT:
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw new Exception(((ExceptionOperation)resultOperation).Exception);
            }
        }
    }
}