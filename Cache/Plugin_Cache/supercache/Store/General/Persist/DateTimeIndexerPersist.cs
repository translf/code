using System;
using System.IO;
using System.Diagnostics;

namespace STSdb4.General.Persist
{
    public class DateTimeIndexerPersist : IIndexerPersist<DateTime>
    {
        private static readonly long MILLISECOND = 10000;
        private static readonly long SECOND = 1000 * MILLISECOND;
        private static readonly long MINUTE = 60 * SECOND;
        private static readonly long HOUR = 60 * MINUTE;
        private static readonly long DAY = 24 * HOUR;

        private readonly Int64IndexerPersist persist = new Int64IndexerPersist(new long[] { MILLISECOND, SECOND, MINUTE, HOUR, DAY });

        public void Store(BinaryWriter writer, Func<int, DateTime> values, int count)
        {      
            persist.Store(writer, (i) => { return values(i).Ticks; }, count);
        }

        public void Load(BinaryReader reader, Action<int, DateTime> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, new DateTime(v)); }, count);
        }
    }
}
