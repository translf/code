using System;
using System.IO;

namespace STSdb4.General.Persist
{
    public class EnumIndexerPersist<TEnum> : IIndexerPersist<TEnum>
        where TEnum : struct, IConvertible
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();
        
        public void Store(BinaryWriter writer, Func<int, TEnum> values, int count)
        {
            persist.Store(writer, (i) => { return ((IConvertible)values(i)).ToInt64(null); }, count);
        }

        public void Load(BinaryReader reader, Action<int, TEnum> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (TEnum)Enum.ToObject(typeof(TEnum), v)); }, count);
        }
    }
}
