using System;
using System.Collections.Concurrent;
using System.IO;
using STSdb4.General.Extensions;
using STSdb4.Data;
using STSdb4.Database.Index;
using STSdb4.Storage;
using STSdb4.WaterfallTree;
using System.Linq;
using STSdb4.General.IO;
using System.Management;

namespace STSdb4.Database
{
    public class StorageEngine : WTree, IStorageEngine
    {
        public StorageEngine(IHeap heap)
            : base(heap)
        {
        }

        public IIndex<IData, IData> OpenXIndex(KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor, params string[] path)
        {
            var keyType = keyDescriptor.DataType;
            bool keySupported = keyType.IsPrimitive || (keyType.IsSlotes && keyType.AreAllTypesPrimitive);
            if (!keySupported)
                throw new NotSupportedException(keyType.ToString());

            var recordType = recordDescriptor.DataType;
            bool recordSupported = recordType.IsPrimitive || (recordType.IsSlotes && recordType.AreAllTypesPrimitive);
            if (!recordSupported)
                throw new NotSupportedException(recordType.ToString());
            
            ILocator locator = Locator.Obtain(StructureType.XINDEX, keyDescriptor, recordDescriptor, path);

            return new XIndex(this, locator);
        }

        public IIndex<IData, IData> OpenXIndex(DataType keyType, DataType recordType, bool compressKeys, bool compressRecords, params string[] path)
        {
            KeyDescriptor keyDescriptor = new KeyDescriptor(keyType, compressKeys);
            RecordDescriptor recordDescriptor = new RecordDescriptor(recordType, compressRecords);

            return OpenXIndex(keyDescriptor, recordDescriptor, path);
        }

        public IIndex<IData, IData> OpenXIndex(DataType keyType, DataType recordType, params string[] path)
        {
            return OpenXIndex(keyType, recordType, true, true, path);
        }

        public override ILocator MinLocator
        {
            get { return Locator.MIN; }
        }

        protected override void Serialize(BinaryWriter writer, ILocator locator)
        {
            Locator l = (Locator)locator;
            l.Serialize(writer);
        }

        protected override ILocator Deserialize(BinaryReader reader)
        {
            ILocator dummy = Locator.Deserialize(reader);
            ILocator locator = Locator.Registrate(dummy);

            return locator;
        }

        #region XIndex Generic

        public IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(IDataTransformer<TKey> keyTransformer, IDataTransformer<TRecord> recordTransformer, CompareOption[] compareOptions, bool compressKeys, bool compressRecords, params string[] path)
        {
            var keyType = keyTransformer.DataType;
            bool keySupported = keyType.IsPrimitive || (keyType.IsSlotes && keyType.AreAllTypesPrimitive);
            if (!keySupported)
                throw new NotSupportedException(keyType.ToString());

            var recordType = recordTransformer.DataType;
            bool recordSupported = recordType.IsPrimitive || (recordType.IsSlotes && recordType.AreAllTypesPrimitive);
            if (!recordSupported)
                throw new NotSupportedException(recordType.ToString());

            Type[] keySlotTypes = keyType.IsPrimitive ? new Type[] { keyType.PrimitiveType } : keyType.Select(x => x.PrimitiveType).ToArray();
            Type[] recordSlotTypes = recordType.IsPrimitive ? new Type[] { recordType.PrimitiveType } : recordType.Select(x => x.PrimitiveType).ToArray();

            keyType.CheckCompareOptions(compareOptions);

            KeyDescriptor keyDescriptor = new KeyDescriptor(keyType, compressKeys, compareOptions);
            RecordDescriptor recordDescriptor = new RecordDescriptor(recordType, compressRecords);

            var index = OpenXIndex(keyDescriptor, recordDescriptor, path);

            return new XIndex<TKey, TRecord>(index, keyTransformer, recordTransformer);
        }

        public IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(bool compressKeys, bool compressRecords, params string[] path)
        {
            DataTransformer<TKey> keyTransformer = new DataTransformer<TKey>();
            DataTransformer<TRecord> recordTransformer = new DataTransformer<TRecord>();
            CompareOption[] options = keyTransformer.DataType.GetDefaultCompareOptions();

            return OpenXIndex<TKey, TRecord>(keyTransformer, recordTransformer, options, compressKeys, compressRecords, path);
        }

        public IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(params string[] path)
        {
            return OpenXIndex<TKey, TRecord>(true, true, path);
        }

        #endregion

        #region XIndex Primitive

        public IIndex<object[], object[]> OpenXIndexPrimitive(KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor, params string[] path)
        {
            var index = OpenXIndex(keyDescriptor, recordDescriptor, path);

            DataToObjectsTransformer keyTransformer = new DataToObjectsTransformer(keyDescriptor.DataType);
            DataToObjectsTransformer recordTransformer = new DataToObjectsTransformer(recordDescriptor.DataType);

            return new XIndex<object[], object[]>(index, keyTransformer, recordTransformer);
        }

        public IIndex<object[], object[]> OpenXIndexPrimitive(DataType keyType, DataType recordType, bool compressKeys, bool compressRecords, params string[] path)
        {
            KeyDescriptor keyDescriptor = new KeyDescriptor(keyType, compressKeys);
            RecordDescriptor recordDescriptor = new RecordDescriptor(recordType, compressRecords);

            return OpenXIndexPrimitive(keyDescriptor, recordDescriptor, path);
        }

        public IIndex<object[], object[]> OpenXIndexPrimitive(DataType keyType, DataType recordType, params string[] path)
        {
            return OpenXIndexPrimitive(keyType, recordType, true, true, path); //default: compress keys & records
        }

        #endregion

        public XFile OpenXFile(params string[] path)
        {
            var keyDescriptor = new KeyDescriptor(DataType.Int64, false);
            var recordDescriptor = new RecordDescriptor(DataType.ByteArray, false);

            ILocator p = Locator.Obtain(StructureType.XFILE, keyDescriptor, recordDescriptor, path);

            XIndex index = new XIndex(this, p);

            return new XFile(index);
        }
    }
}
