using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.General.Collections;
using STSdb4.General.Comparers;
using System.IO;

namespace STSdb4.Data
{
    public class CompareOption : IEquatable<CompareOption>
    {
        public SortOrder SortOrder { get; private set; }
        public ByteOrder ByteOrder { get; private set; }
        public bool IgnoreCase { get; private set; }

        private CompareOption(SortOrder sortOrder, ByteOrder byteOrder, bool ignoreCase)
        {
            this.SortOrder = sortOrder;
            this.ByteOrder = byteOrder;
            this.IgnoreCase = ignoreCase;
        }

        public CompareOption(SortOrder sortOrder)
            : this(sortOrder, ByteOrder.Unspecified, false)
        {
        }

        public CompareOption(SortOrder sortOrder, ByteOrder byteOrder)
            : this(sortOrder, byteOrder, false)
        {
        }

        public CompareOption(ByteOrder byteOrder)
            : this(SortOrder.Ascending, byteOrder)
        {
        }

        public CompareOption(SortOrder sortOrder, bool ignoreCase)
            : this(SortOrder.Ascending, ByteOrder.Unspecified, ignoreCase)
        {
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)SortOrder);
            writer.Write((byte)ByteOrder);
            writer.Write(IgnoreCase);
        }

        public static CompareOption Deserialize(BinaryReader reader)
        {
            var sortOrder = (SortOrder)reader.ReadByte();
            var byteOrder = (ByteOrder)reader.ReadByte();
            var ignoreCase = reader.ReadBoolean();

            return new CompareOption(sortOrder, byteOrder, ignoreCase);
        }

        public bool Equals(CompareOption other)
        {
            return this.SortOrder == other.SortOrder && this.ByteOrder == other.ByteOrder && this.IgnoreCase == other.IgnoreCase;
        }
    }
}
