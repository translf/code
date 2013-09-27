using STSdb4.Data;
using STSdb4.WaterfallTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STSdb4.Database
{
    public interface IStorageEngine : IDisposable
    {
        IOperationCollection Execute(IOperationCollection operations);

        IIndex<IData, IData> OpenXIndex(KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor, params string[] path);
        IIndex<IData, IData> OpenXIndex(DataType keyType, DataType recordType, bool compressKeys, bool compressRecords, params string[] path);
        IIndex<IData, IData> OpenXIndex(DataType keyType, DataType recordType, params string[] path);

        IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(IDataTransformer<TKey> keyTransformer, IDataTransformer<TRecord> recordTransformer, CompareOption[] compareOptions, bool compressKeys, bool compressRecords, params string[] path);
        IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(bool compressKeys, bool compressRecords, params string[] path);
        IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(params string[] path);

        IIndex<object[], object[]> OpenXIndexPrimitive(KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor, params string[] path);
        IIndex<object[], object[]> OpenXIndexPrimitive(DataType keyType, DataType recordType, bool compressKeys, bool compressRecords, params string[] path);
        IIndex<object[], object[]> OpenXIndexPrimitive(DataType keyType, DataType recordType, params string[] path);

        XFile OpenXFile(params string[] path);

        void Commit();
        void Close();
    }
}
