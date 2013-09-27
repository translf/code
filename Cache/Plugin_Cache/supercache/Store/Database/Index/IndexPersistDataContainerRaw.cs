using STSdb4.General.Collections;
using STSdb4.Data;
using STSdb4.WaterfallTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STSdb4.Database.Index
{
    public class IndexPersistDataContainerRaw : IPersistDataContainer
    {
        private DataPersist keyPersist;
        private DataPersist recordPersist;

        public DataType KeyType { get; private set; }
        public DataType RecordType { get; private set; }

        public IndexPersistDataContainerRaw(ILocator locator, DataType keyType, DataType recordType)
        {
            Locator = locator;

            KeyType = keyType;
            RecordType = recordType;

            keyPersist = new DataPersist(keyType);
            recordPersist = new DataPersist(recordType);
        }

        public void Write(BinaryWriter writer, IDataContainer item)
        {
            var set = (IOrderedSet<IData, IData>)item;

            var rows = new KeyValuePair<IData, IData>[set.Count];
            bool isOrdered;
            set.InternalCopyTo(rows, out isOrdered);

            writer.Write(set.Count);
            writer.Write(isOrdered);

            for (int i = 0; i < rows.Length; i++)
            {
                var row = rows[i];
                keyPersist.Write(writer, row.Key);
                recordPersist.Write(writer, row.Value);
            }
        }

        public IDataContainer Read(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            bool isOrdered = reader.ReadBoolean();

            var data = Locator.CreateDataContainer();
            var set = (IOrderedSet<IData, IData>)data;

            if (!isOrdered)
            {
                for (int i = 0; i < count; i++)
                {
                    IData key = keyPersist.Read(reader);
                    IData record = recordPersist.Read(reader);
                    set.Add(key, record);
                }
            }
            else
            {
                KeyValuePair<IData, IData>[] orderedArray = new KeyValuePair<IData, IData>[count];
                for (int i = 0; i < orderedArray.Length; i++)
                {
                    IData key = keyPersist.Read(reader);
                    IData record = recordPersist.Read(reader);
                    orderedArray[i] = new KeyValuePair<IData, IData>(key, record);
                }

                set.AddOrdered(orderedArray, 0, orderedArray.Length);
            }

            return data;
        }

        public ILocator Locator { get; private set; }
    }
}
