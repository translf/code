using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Collections.Concurrent;
using STSdb4.WaterfallTree;
using STSdb4.Database;
using STSdb4.Data;
using STSdb4.Remote;
using STSdb4.General.Extensions;
using STSdb4.Database.Operations;
using STSdb4.General.Communication;

namespace STSdb4.Remote
{
    public class StorageEngineClient : IStorageEngine
    {
        public readonly ClientConnection ClientConnection;
        
        public static readonly ILocator XIndexMIN = Locator.Obtain(STSdb4.Database.StructureType.XINDEX, new KeyDescriptor(DataType.Boolean, false), new RecordDescriptor(DataType.Boolean, false), "");

        public StorageEngineClient(string machineName = "localhost", int port = 7182)
        {
            ClientConnection = new ClientConnection(machineName, port);
            ClientConnection.Start();
        }

        public IOperationCollection Execute(IOperationCollection operations)
        {
            MemoryStream ms = new MemoryStream();

            Message msg = new Message(operations);
            msg.Serialize(new BinaryWriter(ms));

            Packet packet = new Packet(ms);
            ClientConnection.Send(packet);

            packet.Wait();
            msg = Message.Deserialize(new BinaryReader(packet.Response));

            return msg.Operations;
        }

        public void Commit()
        {
            OperationCollection oprs = new OperationCollection(StorageEngineClient.XIndexMIN, 1);
            oprs.Add(new StorageEngineCommitOperation());
            Execute(oprs);
        }

        #region XIndexRemote

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

            return new XIndexRemote(this, locator);
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

        #endregion

        #region XIndex Generic

        public IIndex<TKey, TRecord> OpenXIndex<TKey, TRecord>(IDataTransformer<TKey> keyTransformer, IDataTransformer<TRecord> recordTransformer, CompareOption[] compareOptions, bool compressKeys, bool compressRecords, params string[] path)
        {
            DataType keyType = keyTransformer.DataType;
            DataType recordType = recordTransformer.DataType;

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
            return OpenXIndexPrimitive(keyType, recordType, true, true, path);
        }

        #endregion

        public XFile OpenXFile(params string[] path)
        {
            var keyDescriptor = new KeyDescriptor(DataType.Int64, false);
            var recordDescriptor = new RecordDescriptor(DataType.ByteArray, false);

            ILocator p = Locator.Obtain(StructureType.XFILE, keyDescriptor, recordDescriptor, path);

            XIndexRemote index = new XIndexRemote(this, p);

            return new XFile(index);
        }

        #region IDisposable Members

        private volatile bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ClientConnection.Stop();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        ~StorageEngineClient()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        #endregion
    }
}
