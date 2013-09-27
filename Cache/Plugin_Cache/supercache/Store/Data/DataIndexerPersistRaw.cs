using STSdb4.General.Persist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STSdb4.Data
{
    public class DataIndexerPersistRaw : IIndexerPersist<IData>
    {
        public DataType DataType { get; private set; }
        public DataPersist Persist { get; private set; }

        public DataIndexerPersistRaw(DataType dataType)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            DataType = dataType;
            Persist = new DataPersist(dataType);
        }

        public void Store(BinaryWriter writer, Func<int, IData> values, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var data = values(i);
                Persist.Write(writer, data);
            }
        }

        public void Load(BinaryReader reader, Action<int, IData> values, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var data = Persist.Read(reader);
                values(i, data);
            }
        }
    }
}
