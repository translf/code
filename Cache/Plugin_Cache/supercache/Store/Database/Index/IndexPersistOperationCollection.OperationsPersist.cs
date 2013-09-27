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
    public partial class IndexPersistOperationCollection
    {
        private void WriteReplaceOperation(BinaryWriter writer, ReplaceOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            RecordPersist.Write(writer, operation.Record);
        }

        private ReplaceOperation ReadReplaceOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);
            IData record = RecordPersist.Read(reader);

            return new ReplaceOperation(key, record);
        }

        private void WriteDeleteOperation(BinaryWriter writer, DeleteOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
        }

        private DeleteOperation ReadDeleteOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);

            return new DeleteOperation(key);
        }

        private void WriteDeleteRangeOperation(BinaryWriter writer, DeleteRangeOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            KeyPersist.Write(writer, operation.ToKey);
        }

        private DeleteRangeOperation ReadDeleteRangeOperation(BinaryReader reader)
        {
            IData from = KeyPersist.Read(reader);
            IData to = KeyPersist.Read(reader);

            return new DeleteRangeOperation(from, to);
        }

        private void WriteInsertOrIgnoreOperation(BinaryWriter writer, InsertOrIgnoreOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            RecordPersist.Write(writer, operation.Record);
        }

        private InsertOrIgnoreOperation ReadInsertOrIgnoreOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);
            IData record = RecordPersist.Read(reader);

            return new InsertOrIgnoreOperation(key, record);
        }

        private void WriteReadOperation(BinaryWriter writer, ReadOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            writer.Write(operation.Handle);
        }

        private ReadOperation ReadReadOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);
            long handle = reader.ReadInt64();

            return new ReadOperation(key, handle);
        }

        private void WriteReadRangeOperation(BinaryWriter writer, ReadRangeOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            KeyPersist.Write(writer, operation.ToKey);
            writer.Write(operation.Handle);
        }

        private ReadRangeOperation ReadReadRangeOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);
            IData to = KeyPersist.Read(reader);
            long handle = reader.ReadInt64();

            return new ReadRangeOperation(key, to, handle);
        }

        private void WriteClearOperation(BinaryWriter writer, ClearOperation operation)
        {
        }

        private ClearOperation ReadClearOperation(BinaryReader reader)
        {
            return new ClearOperation();
        }

        private void WriteRefreshOperation(BinaryWriter writer, RefreshOperation operation)
        {
        }

        private RefreshOperation ReadRefreshOperation(BinaryReader reader)
        {
            return new RefreshOperation();
        }

        private void WriteRefreshPointOperation(BinaryWriter writer, RefreshPointOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
        }

        private RefreshPointOperation ReadRefreshPointOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);

            return new RefreshPointOperation(key);
        }

        private void WriteRefreshRangeOperation(BinaryWriter writer, RefreshRangeOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            KeyPersist.Write(writer, operation.ToKey);
        }

        private RefreshRangeOperation ReadRefreshRangeOperation(BinaryReader reader)
        {
            IData from = KeyPersist.Read(reader);
            IData to = KeyPersist.Read(reader);

            return new RefreshRangeOperation(from, to);
        }

        private void WriteTryGetOperation(BinaryWriter writer, TryGetOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);

            writer.Write(operation.Record != null);
            if (operation.Record != null)
                RecordPersist.Write(writer, operation.Record);
        }

        private TryGetOperation ReadTryGetOperation(BinaryReader reader)
        {
            IData key = KeyPersist.Read(reader);
            IData record = reader.ReadBoolean() ? RecordPersist.Read(reader) : null;

            return new TryGetOperation(key, record);
        }

        private void WriteForwardOperation(BinaryWriter writer, ForwardOperation operation)
        {
            writer.Write(operation.PageCount);

            writer.Write(operation.FromKey != null);
            if (operation.FromKey != null)
                KeyPersist.Write(writer, operation.FromKey);

            writer.Write(operation.ToKey != null);
            if (operation.ToKey != null)
                KeyPersist.Write(writer, operation.ToKey);

            writer.Write(operation.List != null);
            if (operation.List != null)
                SerializeList(writer, operation.List, operation.List.Count);
        }

        private ForwardOperation ReadForwardOperation(BinaryReader reader)
        {
            int pageCount = reader.ReadInt32();
            IData from = reader.ReadBoolean() ? KeyPersist.Read(reader) : null;
            IData to = reader.ReadBoolean() ? KeyPersist.Read(reader) : null;
            List<KeyValuePair<IData, IData>> list = reader.ReadBoolean() ? DeserializeList(reader) : null;

            return new ForwardOperation(pageCount, from, to, list);
        }

        private void WriteBackwardOperation(BinaryWriter writer, BackwardOperation operation)
        {
            writer.Write(operation.PageCount);

            writer.Write(operation.FromKey != null);
            if (operation.FromKey != null)
                KeyPersist.Write(writer, operation.FromKey);

            writer.Write(operation.ToKey != null);
            if (operation.ToKey != null)
                KeyPersist.Write(writer, operation.ToKey);

            writer.Write(operation.List != null);
            if (operation.List != null)
                SerializeList(writer, operation.List, operation.List.Count);
        }

        private BackwardOperation ReadBackwardOperation(BinaryReader reader)
        {
            int pageCount = reader.ReadInt32();
            IData from = reader.ReadBoolean() ? KeyPersist.Read(reader) : null;
            IData to = reader.ReadBoolean() ? KeyPersist.Read(reader) : null;
            List<KeyValuePair<IData, IData>> list = reader.ReadBoolean() ? DeserializeList(reader) : null;

            return new BackwardOperation(pageCount, from, to, list);
        }

        private void WriteFindNextOperation(BinaryWriter writer, FindNextOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            writer.Write(operation.KeyValue.HasValue);

            if (operation.KeyValue.HasValue)
            {
                KeyPersist.Write(writer, operation.KeyValue.Value.Key);
                RecordPersist.Write(writer, operation.KeyValue.Value.Value);
            }
        }

        private FindNextOperation ReadFindNextOperation(BinaryReader reader)
        {
            IData from = KeyPersist.Read(reader);

            bool hasValues = (reader.ReadBoolean());
            IData key = hasValues ? KeyPersist.Read(reader) : null;
            IData rec = hasValues ? RecordPersist.Read(reader) : null;

            return new FindNextOperation(from, new KeyValuePair<IData, IData>(key, rec));
        }

        private void WriteFindAfterOperation(BinaryWriter writer, FindAfterOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);
            writer.Write(operation.KeyValue.HasValue);

            if (operation.KeyValue.HasValue)
            {
                KeyPersist.Write(writer, operation.KeyValue.Value.Key);
                RecordPersist.Write(writer, operation.KeyValue.Value.Value);
            }
        }

        private FindAfterOperation ReadFindAfterOperation(BinaryReader reader)
        {
            IData from = KeyPersist.Read(reader);

            bool hasValues = (reader.ReadBoolean());
            IData key = hasValues ? KeyPersist.Read(reader) : null;
            IData rec = hasValues ? RecordPersist.Read(reader) : null;

            return new FindAfterOperation(from, new KeyValuePair<IData, IData>(key, rec));
        }

        private void WriteFindPrevOperation(BinaryWriter writer, FindPrevOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);

            writer.Write(operation.KeyValue.HasValue);
            if (operation.KeyValue.HasValue)
            {
                KeyPersist.Write(writer, operation.KeyValue.Value.Key);
                RecordPersist.Write(writer, operation.KeyValue.Value.Value);
            }
        }

        private FindPrevOperation ReadFindPrevOperation(BinaryReader reader)
        {
            IData from = KeyPersist.Read(reader);

            bool hasValues = (reader.ReadBoolean());
            IData key = hasValues ? KeyPersist.Read(reader) : null;
            IData rec = hasValues ? RecordPersist.Read(reader) : null;

            return new FindPrevOperation(from, new KeyValuePair<IData, IData>(key, rec));
        }

        private void WriteFindBeforeOperation(BinaryWriter writer, FindBeforeOperation operation)
        {
            KeyPersist.Write(writer, operation.FromKey);

            writer.Write(operation.KeyValue.HasValue);
            if (operation.KeyValue.HasValue)
            {
                KeyPersist.Write(writer, operation.KeyValue.Value.Key);
                RecordPersist.Write(writer, operation.KeyValue.Value.Value);
            }
        }

        private FindBeforeOperation ReadFindBeforeOperation(BinaryReader reader)
        {
            IData from = KeyPersist.Read(reader);
            
            bool hasValues = (reader.ReadBoolean());
            IData key = hasValues ? KeyPersist.Read(reader) : null;
            IData rec = hasValues ? RecordPersist.Read(reader) : null;

            return new FindBeforeOperation(from, new KeyValuePair<IData, IData>(key, rec));
        }

        private void WriteFirstRowOperation(BinaryWriter writer, FirstRowOperation operation)
        {
            writer.Write(operation.Row.HasValue);
            if (operation.Row.HasValue)
            {
                KeyPersist.Write(writer, operation.Row.Value.Key);
                RecordPersist.Write(writer, operation.Row.Value.Value);
            }
        }

        private FirstRowOperation ReadFirstRowOperation(BinaryReader reader)
        {
            bool hasValues = (reader.ReadBoolean());
            IData key = hasValues ? KeyPersist.Read(reader) : null;
            IData rec = hasValues ? RecordPersist.Read(reader) : null;

            return new FirstRowOperation(new KeyValuePair<IData, IData>(key, rec));
        }

        private void WriteLastRowOperation(BinaryWriter writer, LastRowOperation operation)
        {
            writer.Write(operation.Row.HasValue);
            if (operation.Row.HasValue)
            {
                KeyPersist.Write(writer, operation.Row.Value.Key);
                RecordPersist.Write(writer, operation.Row.Value.Value);
            }
        }

        private LastRowOperation ReadLastRowOperation(BinaryReader reader)
        {
            bool hasValues = (reader.ReadBoolean());
            IData key = hasValues ? KeyPersist.Read(reader) : null;
            IData rec = hasValues ? RecordPersist.Read(reader) : null;

            return new LastRowOperation(new KeyValuePair<IData, IData>(key, rec));
        }

        private void WriteCountOperation(BinaryWriter writer, CountOperation operation)
        {
            writer.Write(operation.Count);
        }

        private CountOperation ReadCountOperation(BinaryReader reader)
        {
            return new CountOperation(reader.ReadInt64());
        }

        private void WriteStorageEngineCommitOperation(BinaryWriter writer, StorageEngineCommitOperation operation)
        {
        }

        private StorageEngineCommitOperation ReadStorageEngineCommitOperation(BinaryReader reader)
        {
            return new StorageEngineCommitOperation();
        }

        private void SerializeList(BinaryWriter writer, List<KeyValuePair<IData, IData>> list, int count)
        {
            writer.Write(count);

            foreach (var kv in list)
            {
                KeyPersist.Write(writer, kv.Key);
                RecordPersist.Write(writer, kv.Value);
            }
        }

        private List<KeyValuePair<IData, IData>> DeserializeList(BinaryReader reader)
        {
            int count = reader.ReadInt32();

            List<KeyValuePair<IData, IData>> list = new List<KeyValuePair<IData, IData>>(count);
            for (int i = 0; i < count; i++)
            {
                IData key = KeyPersist.Read(reader);
                IData rec = RecordPersist.Read(reader);
                list.Add(new KeyValuePair<IData, IData>(key, rec));
            }

            return list;
        }
    }
}
