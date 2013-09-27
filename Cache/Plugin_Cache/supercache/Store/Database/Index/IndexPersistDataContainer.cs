using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using STSdb4.General.Collections;
using STSdb4.General.Compression;
using STSdb4.General.Persist;
using STSdb4.Data;
using STSdb4.Database.Operations;
using STSdb4.WaterfallTree;
using System.Diagnostics;

namespace STSdb4.Database.Index.Templates
{
    public class IndexPersistDataContainer : IPersistDataContainer
    {
        private IIndexerPersist<IData> keyIndexerPersist;
        private IIndexerPersist<IData> recordIndexerPersist;

        public DataType KeyType { get; private set; }
        public DataType RecordType { get; private set; }

        public bool CompressKeys { get; private set; }
        public bool CompressRecords { get; private set; }

        public IndexPersistDataContainer(ILocator locator, DataType keyType, DataType recordType, bool compressKeys, bool compressRecords)
        {
            Locator = locator;

            KeyType = keyType;
            RecordType = recordType;

            CompressKeys = compressKeys;
            CompressRecords = compressRecords;

            if (compressKeys)
                keyIndexerPersist = new DataIndexerPersist(keyType);
            else
                keyIndexerPersist = new DataIndexerPersistRaw(keyType);

            if (compressRecords)
                recordIndexerPersist = new DataIndexerPersist(recordType);
            else
                recordIndexerPersist = new DataIndexerPersistRaw(recordType);
        }

        public void Write(BinaryWriter writer, IDataContainer item)
        {
            var set = (IOrderedSet<IData, IData>)item;
            
            var rows = new KeyValuePair<IData, IData>[set.Count];
            bool isOrdered;
            set.InternalCopyTo(rows, out isOrdered);

            CountCompression.Serialize(writer, checked((ulong)set.Count));
            writer.Write(isOrdered);

            Action[] actions = new Action[2];
            MemoryStream[] streams = new MemoryStream[2];

            actions[0] = () =>
            {
                streams[0] = new MemoryStream();
                keyIndexerPersist.Store(new BinaryWriter(streams[0]), (idx) => { return rows[idx].Key; }, rows.Length);
            };

            actions[1] = () =>
            {
                streams[1] = new MemoryStream();
                recordIndexerPersist.Store(new BinaryWriter(streams[1]), (idx) => { return rows[idx].Value; }, rows.Length);
            };

            Parallel.Invoke(actions);

            foreach (var str in streams)
            {
                using (str)
                {
                    CountCompression.Serialize(writer, checked((ulong)str.Length));
                    writer.Write(str.GetBuffer(), 0, (int)str.Length);
                }
            }
        }

        public IDataContainer Read(BinaryReader reader)
        {
            int count = (int)CountCompression.Deserialize(reader);
            bool isOrdered = reader.ReadBoolean();

            IData[] keys = new IData[count];
            IData[] records = new IData[count];

            Action[] actions = new Action[2];
            byte[][] buffers = new byte[2][];

            for (int i = 0; i < buffers.Length; i++)
                buffers[i] = reader.ReadBytes((int)CountCompression.Deserialize(reader));

            actions[0] = () =>
            {
                using (MemoryStream ms = new MemoryStream(buffers[0]))
                    keyIndexerPersist.Load(new BinaryReader(ms), (idx, value) => { keys[idx] = value; }, count);
            };

            actions[1] = () =>
            {
                using (MemoryStream ms = new MemoryStream(buffers[1]))
                    recordIndexerPersist.Load(new BinaryReader(ms), (idx, value) => { records[idx] = value; }, count);
            };

            Parallel.Invoke(actions);

            var data = Locator.CreateDataContainer();
            var set = (IOrderedSet<IData, IData>)data;

            if (!isOrdered)
            {
                for (int i = 0; i < count; i++)
                    set.Add(keys[i], records[i]);
            }
            else
            {
                KeyValuePair<IData, IData>[] orderedArray = new KeyValuePair<IData, IData>[count];
                for (int i = 0; i < orderedArray.Length; i++)
                    orderedArray[i] = new KeyValuePair<IData, IData>(keys[i], records[i]);

                set.AddOrdered(orderedArray, 0, orderedArray.Length);
            }

            return data;
        }

        public ILocator Locator { get; private set; }
    }
}
