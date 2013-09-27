using System;
using System.IO;
using STSdb4.General.Extensions;

namespace STSdb4.General.Persist
{
    public class BooleanIndexerPersist : IIndexerPersist<Boolean>
    {
        public void Store(BinaryWriter writer, Func<int, bool> values, int count)
        {
            byte[] buffer = new byte[(int)Math.Ceiling(count / 8.0)];

            for (int i = 0; i < count; i++)
                buffer.SetBit(i, values(i) ? 1 : 0);

            writer.Write(buffer);
        }

        public void Load(BinaryReader reader, Action<int, bool> values, int count)
        {
            byte[] buffer = reader.ReadBytes((int)Math.Ceiling(count / 8.0));

            for (int i = 0; i < count; i++)
                values(i, buffer.GetBit(i) == 0 ? false : true);
        }
    }
}
