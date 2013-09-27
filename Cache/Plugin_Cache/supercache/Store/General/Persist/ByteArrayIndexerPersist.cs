using System;
using System.IO;
using System.Collections.Generic;

namespace STSdb4.General.Persist
{
    public class ByteArrayIndexerPersist : IIndexerPersist<Byte[]>
    {
        public void Store(BinaryWriter writer, Func<int, byte[]> values, int count)
        {
            int[] lengths = new int[count];

            for (int i = 0; i < count; i++)
            {
                byte[] value = values(i);

                if (value == null)
                    lengths[i] = -1;
                else
                    lengths[i] = value.Length;
            }

            Int32IndexerPersist lengthsPersist = new Int32IndexerPersist();
            lengthsPersist.Store(writer, (idx) => { return lengths[idx]; }, count);

            for (int i = 0; i < count; i++)
            {
                byte[] value = values(i);

                if (value == null)
                    continue;
             
                writer.Write(value);
            }
        }

        public void Load(BinaryReader reader, Action<int, byte[]> values, int count)
        {
            int[] lengths = new int[count];

            Int32IndexerPersist lengthsPersist = new Int32IndexerPersist();
            lengthsPersist.Load(reader, (idx, value) => { lengths[idx] = value; }, count);

            for (int i = 0; i < count; i++)
            {
                if (lengths[i] == -1)
                    values(i, null);
                else
                    values(i, reader.ReadBytes(lengths[i]));
            }
        }
    }
}
