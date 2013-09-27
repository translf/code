using STSdb4.General.Compression;
using STSdb4.Data;
using STSdb4.Database.Operations;
using STSdb4.WaterfallTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using STSdb4.General.Collections;

namespace STSdb4.Database.Index
{
    public partial class IndexPersistOperationCollection : IPersistOperationCollection
    {
        private DataPersist KeyPersist;
        private DataPersist RecordPersist;

        public IndexPersistOperationCollection(ILocator locator)
        {
            Locator = locator;

            KeyPersist = new DataPersist(Locator.KeyDescriptor.DataType);
            RecordPersist = new DataPersist(Locator.RecordDescriptor.DataType);
        }

        public void Write(BinaryWriter writer, IOperationCollection operations)
        {
            writer.Write(operations.Count);
            writer.Write(operations.IsAllMonotoneAndPoint);

            for (int i = 0; i < operations.Count; i++)
            {
                IOperation operation = operations[i];

                int operationCode = operation.Code;
                writer.Write(operationCode);

                //operation body
                switch (operationCode)
                {
                    case OperationCode.REPLACE:
                        WriteReplaceOperation(writer, (ReplaceOperation)operation);
                        break;
                    case OperationCode.DELETE:
                        WriteDeleteOperation(writer, (DeleteOperation)operation);
                        break;
                    case OperationCode.DELETE_RANGE:
                        WriteDeleteRangeOperation(writer, (DeleteRangeOperation)operation);
                        break;
                    case OperationCode.INSERT_OR_IGNORE:
                        WriteInsertOrIgnoreOperation(writer, (InsertOrIgnoreOperation)operation);
                        break;
                    case OperationCode.READ:
                        WriteReadOperation(writer, (ReadOperation)operation);
                        break;
                    case OperationCode.READ_RANGE:
                        WriteReadRangeOperation(writer, (ReadRangeOperation)operation);
                        break;
                    case OperationCode.CLEAR:
                        WriteClearOperation(writer, (ClearOperation)operation);
                        break;
                    case OperationCode.REFRESH:
                        WriteRefreshOperation(writer, (RefreshOperation)operation);
                        break;
                    case OperationCode.REFRESH_POINT:
                        WriteRefreshPointOperation(writer, (RefreshPointOperation)operation);
                        break;
                    case OperationCode.REFRESH_RANGE:
                        WriteRefreshRangeOperation(writer, (RefreshRangeOperation)operation);
                        break;
                    case OperationCode.TRY_GET:
                        WriteTryGetOperation(writer, (TryGetOperation)operation);
                        break;
                    case OperationCode.FORWARD:
                        WriteForwardOperation(writer, (ForwardOperation)operation);
                        break;
                    case OperationCode.BACKWARD:
                        WriteBackwardOperation(writer, (BackwardOperation)operation);
                        break;
                    case OperationCode.FIND_NEXT:
                        WriteFindNextOperation(writer, (FindNextOperation)operation);
                        break;
                    case OperationCode.FIND_AFTER:
                        WriteFindAfterOperation(writer, (FindAfterOperation)operation);
                        break;
                    case OperationCode.FIND_PREV:
                        WriteFindPrevOperation(writer, (FindPrevOperation)operation);
                        break;
                    case OperationCode.FIND_BEFORE:
                        WriteFindBeforeOperation(writer, (FindBeforeOperation)operation);
                        break;
                    case OperationCode.FIRST_ROW:
                        WriteFirstRowOperation(writer, (FirstRowOperation)operation);
                        break;
                    case OperationCode.LAST_ROW:
                        WriteLastRowOperation(writer, (LastRowOperation)operation);
                        break;
                    case OperationCode.COUNT:
                        WriteCountOperation(writer, (CountOperation)operation);
                        break;
                    case OperationCode.STORAGE_ENGINE_COMMIT:
                        WriteStorageEngineCommitOperation(writer, (StorageEngineCommitOperation)operation);
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public IOperationCollection Read(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            bool isAllMonotoneAndPoint = reader.ReadBoolean();

            var operations = Locator.CreateOperationCollection(count);

            for (int i = 0; i < count; i++)
            {
                int operationCode = reader.ReadInt32();

                IOperation operation;

                //operation body
                switch (operationCode)
                {
                    case OperationCode.REPLACE:
                        operation = ReadReplaceOperation(reader);
                        break;
                    case OperationCode.DELETE:
                        operation = ReadDeleteOperation(reader);
                        break;
                    case OperationCode.DELETE_RANGE:
                        operation = ReadDeleteRangeOperation(reader);
                        break;
                    case OperationCode.INSERT_OR_IGNORE:
                        operation = ReadInsertOrIgnoreOperation(reader);
                        break;
                    case OperationCode.READ:
                        operation = ReadReadOperation(reader);
                        break;
                    case OperationCode.READ_RANGE:
                        operation = ReadReadRangeOperation(reader);
                        break;
                    case OperationCode.CLEAR:
                        operation = ReadClearOperation(reader);
                        break;
                    case OperationCode.REFRESH:
                        operation = ReadRefreshOperation(reader);
                        break;
                    case OperationCode.REFRESH_POINT:
                        operation = ReadRefreshPointOperation(reader);
                        break;
                    case OperationCode.REFRESH_RANGE:
                        operation = ReadRefreshRangeOperation(reader);
                        break;
                    case OperationCode.TRY_GET:
                        operation = ReadTryGetOperation(reader);
                        break;
                    case OperationCode.FORWARD:
                        operation = ReadForwardOperation(reader);
                        break;
                    case OperationCode.BACKWARD:
                        operation = ReadBackwardOperation(reader);
                        break;
                    case OperationCode.FIND_NEXT:
                        operation = ReadFindNextOperation(reader);
                        break;
                    case OperationCode.FIND_AFTER:
                        operation = ReadFindAfterOperation(reader);
                        break;
                    case OperationCode.FIND_PREV:
                        operation = ReadFindPrevOperation(reader);
                        break;
                    case OperationCode.FIND_BEFORE:
                        operation = ReadFindBeforeOperation(reader);
                        break;
                    case OperationCode.FIRST_ROW:
                        operation = ReadFirstRowOperation(reader);
                        break;
                    case OperationCode.LAST_ROW:
                        operation = ReadLastRowOperation(reader);
                        break;
                    case OperationCode.COUNT:
                        operation = ReadCountOperation(reader);
                        break;
                    case OperationCode.STORAGE_ENGINE_COMMIT:
                        operation = ReadStorageEngineCommitOperation(reader);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                operations.Add(operation);
            }

            return operations;
        }

        public ILocator Locator { get; private set; }
    }
}