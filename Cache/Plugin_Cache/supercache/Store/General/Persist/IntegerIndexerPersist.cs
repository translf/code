using System;
using System.IO;
using System.Collections.Generic;
using STSdb4.General.Compression;

namespace STSdb4.General.Persist
{
    public class Int64IndexerPersist : IIndexerPersist<Int64>
    {
        private long[] factors;

        /// <summary>
        /// This contructor gets the factors in ascending order
        /// </summary>
        public Int64IndexerPersist(long[] factors)
        {
            this.factors = factors;
        }

        public Int64IndexerPersist()
            : this(new long[0])
        {
        }

        public void Store(BinaryWriter writer, Func<int, long> values, int count)
        {
            List<long> list = new List<long>(count);

            int index = factors.Length - 1;
            for (int i = 0; i < count; i++)
            {
                long value = values(i);
                list.Add(value);

                while (index >= 0)
                {
                    if (value % factors[index] == 0)
                        break;
                    else
                        index--;
                }
            }

            long factor = index >= 0 ? factors[index] : 1;

            DeltaCompression.Helper helper = new DeltaCompression.Helper();
            for (int i = 0; i < count; i++)
            {
                list[i] = list[i] / factor;
                helper.AddValue(list[i]);
            }

            CountCompression.Serialize(writer, checked((ulong)factor));
            DeltaCompression.CoreCompress(writer, list, helper);
        }

        public void Load(BinaryReader reader, Action<int, long> values, int count)
        {
            long factor = (long)CountCompression.Deserialize(reader);
            List<long> rawValues = (List<long>)DeltaCompression.CoreDecompress(reader);

            for (int i = 0; i < count; i++)
                values(i, factor * rawValues[i]);
        }
    }

    public class UInt64IndexerPersist : IIndexerPersist<UInt64>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();
        
        public void Store(BinaryWriter writer, Func<int, ulong> values, int count)
        {
            persist.Store(writer, (i) => { return (long)values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, ulong> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (ulong)v); }, count);
        }
    }

    public class Int32IndexerPersist : IIndexerPersist<Int32>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, int> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, int> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (int)v); }, count);
        }
    }

    public class UInt32IndexerPersist : IIndexerPersist<UInt32>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, uint> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, uint> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (uint)v); }, count);
        }
    }

    public class Int16IndexerPersist : IIndexerPersist<Int16>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, short> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, short> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (short)v); }, count);
        }
    }

    public class UInt16IndexerPersist : IIndexerPersist<UInt16>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, ushort> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, ushort> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (ushort)v); }, count);
        }
    }

    public class ByteIndexerPersist : IIndexerPersist<Byte>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, byte> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, byte> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (byte)v); }, count);
        }
    }

    public class SByteIndexerPersist : IIndexerPersist<SByte>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, sbyte> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, sbyte> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (sbyte)v); }, count);
        }
    }

    public class CharIndexerPersist : IIndexerPersist<Char>
    {
        private readonly Int64IndexerPersist persist = new Int64IndexerPersist();

        public void Store(BinaryWriter writer, Func<int, char> values, int count)
        {
            persist.Store(writer, (i) => { return values(i); }, count);
        }

        public void Load(BinaryReader reader, Action<int, char> values, int count)
        {
            persist.Load(reader, (i, v) => { values(i, (char)v); }, count);
        }
    }
}
