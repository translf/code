using System;
using System.Diagnostics;
using System.IO;
using STSdb4.General.Compression;
using STSdb4.General.Extensions;
using STSdb4.General.Comparers;
using STSdb4.WaterfallTree;

namespace STSdb4.Database
{
    public class StructureDescriptor : IComparable<StructureDescriptor>, IEquatable<StructureDescriptor>
    {
        public static readonly StructureDescriptor Empty = new StructureDescriptor(new byte[] { });

        public byte[] Raw { get; private set; }
        public KeyDescriptor KeyDescriptor { get; private set; }
        public RecordDescriptor RecordDescriptor { get; private set; }

        public bool IsEncoded { get; private set; }
        public bool IsDecoded { get; private set; }

        public StructureDescriptor(KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor)
        {
            KeyDescriptor = keyDescriptor;
            RecordDescriptor = recordDescriptor;
            IsEncoded = false;
            IsDecoded = true;
        }

        public StructureDescriptor(byte[] raw)
        {
            Raw = raw;
            IsEncoded = true;
            IsDecoded = false;
        }

        public void Encode()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(ms);

                KeyDescriptor.Serialize(writer);
                RecordDescriptor.Serialize(writer);
                Raw = ms.ToArray();
                IsEncoded = true;
            }
        }

        public void Decode()
        {
            using (MemoryStream ms = new MemoryStream(Raw))
            {
                BinaryReader reader = new BinaryReader(ms);
                KeyDescriptor = KeyDescriptor.Deserialize(reader);
                RecordDescriptor = RecordDescriptor.Deserialize(reader);
                IsDecoded = true;
            }
        }

        public void Serialize(BinaryWriter writer)
        {
            CountCompression.Serialize(writer, checked((ulong)Raw.Length));
            writer.Write(Raw);
        }

        public static StructureDescriptor Deserialize(BinaryReader reader)
        {
            byte[] raw = reader.ReadBytes((int)CountCompression.Deserialize(reader));
            return new StructureDescriptor(raw);
        }

        public int CompareTo(StructureDescriptor other)
        {
            Debug.Assert(IsEncoded);

            return BigEndianByteArrayComparer.Instance.Compare(this.Raw, other.Raw);
        }

        public bool Equals(StructureDescriptor other)
        {
            Debug.Assert(IsEncoded);

            return BigEndianByteArrayEqualityComparer.Instance.Equals(this.Raw, other.Raw);
        }

        public override int GetHashCode()
        {
            Debug.Assert(IsEncoded);

            return Raw.GetHashCodeEx();
        }
    }
}
