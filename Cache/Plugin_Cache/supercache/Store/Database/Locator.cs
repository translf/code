using System;
using System.Collections.Generic;
using System.IO;
using STSdb4.General.Compression;
using STSdb4.General.Persist;
using STSdb4.Data;
using STSdb4.Database.Index;
using STSdb4.Database.Index.Templates;
using STSdb4.WaterfallTree;
using STSdb4.General.Buffers;
using System.Collections.Concurrent;

namespace STSdb4.Database
{
    public class Locator : ILocator
    {
        private StructureDescriptor descriptor;

        private bool hashCodeBuilded = false;
        private int hashCode = 0;

        private bool serializationBuilded;
        private byte[] serializationData;

        private readonly string[] Path;

        protected static readonly ConcurrentDictionary<ILocator, ILocator> Register = new ConcurrentDictionary<ILocator, ILocator>();

        public const char SEPARATOR = '\\';
        public static readonly Locator MIN = new Locator(STSdb4.Database.StructureType.RESERVED, StructureDescriptor.Empty);

        public Locator(int structureType, StructureDescriptor descriptor, params string[] path)
        {
            StructureType = structureType;
            this.descriptor = descriptor;
            Path = path;

            PersistKey = SentinelPersistKey.Instance;
        }

        private static ILocator Create(int structType, KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor, params string[] path)
        {
            if (!STSdb4.Database.StructureType.IsValid(structType))
                throw new ArgumentException("Invalid structType");

            StructureDescriptor descriptor = new StructureDescriptor(keyDescriptor, recordDescriptor);
            descriptor.Encode();

            return new Locator(structType, descriptor, path);
        }

        public static ILocator Obtain(int structType, KeyDescriptor keyDescriptor, RecordDescriptor recordDescriptor, params string[] path)
        {
            ILocator locator = Locator.Create(structType, keyDescriptor, recordDescriptor, path);

            return Registrate(locator);
        }

        public static ILocator Registrate(ILocator locator)
        {
            if (Register.Count > 1048576)
                Register.Clear();

            if (Object.ReferenceEquals(locator, MIN)) //not included in the register
                return MIN;

            //the function is called only if the path does not exist in the register. 
            //In this case, prepare the new locator before adding it to the dictionary.
            return Register.GetOrAdd(locator, (p) =>
            {
                ((Locator)p).Prepare();
                return p;
            });
        }

        /// <summary>
        /// Build:
        /// - Apply
        /// - PersistDataContainer
        /// - PersistOperations
        /// - PersistKey
        /// - KeyComparer
        /// - KeyEqualityComparer 
        /// 
        /// instances from StructType, keySlotTypes & recordSlotTypes
        /// </summary>
        protected virtual void BuildMembers()
        {
            //apply
            switch (StructureType)
            {
                case STSdb4.Database.StructureType.XINDEX: Apply = new XIndexApply(this); break;
                case STSdb4.Database.StructureType.XFILE: Apply = new XStreamApply(this); break;
            }

            //comparer & equality comparer
            KeyComparer = new DataComparer(KeyDescriptor.DataType, KeyDescriptor.CompareOptions);
            KeyEqualityComparer = new DataEqualityComparer(KeyDescriptor.DataType, KeyDescriptor.CompareOptions);

            bool compressKeys = KeyDescriptor.CompressData;
            bool compressRecords = RecordDescriptor.CompressData;

            if (compressKeys || compressRecords)
                PersistDataContainer = new IndexPersistDataContainer(this, KeyDescriptor.DataType, RecordDescriptor.DataType, compressKeys, compressRecords);
            else
                PersistDataContainer = new IndexPersistDataContainerRaw(this, KeyDescriptor.DataType, RecordDescriptor.DataType);

            PersistOperations = new IndexPersistOperationCollection(this);
            PersistKey = new DataPersist(KeyDescriptor.DataType);
        }

        /// <summary>
        /// Prepare KeyType, RecordType, Apply, Persist, KeyComparer & KeyEqualityComparer from the StructureType and descriptor
        /// </summary>
        public void Prepare()
        {
            //if (Object.ReferenceEquals(this, Path.MIN))
            //    return;

            if (!descriptor.IsDecoded)
                descriptor.Decode();

            BuildMembers();
        }

        private void InternalSerialize(BinaryWriter writer)
        {
            //StructureType
            writer.Write(checked((byte)StructureType));

            if (Object.ReferenceEquals(this, Locator.MIN))
                return;

            //descriptor
            descriptor.Serialize(writer);

            //Items
            CountCompression.Serialize(writer, checked((ulong)Path.Length));
            for (int i = 0; i < Path.Length; i++)
                writer.Write(Path[i]);
        }

        public void Serialize(BinaryWriter writer)
        {
            if (!serializationBuilded) //+3% db performance with the flag
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    InternalSerialize(new BinaryWriter(ms));
                    serializationData = ms.ToArray();
                    serializationBuilded = true;
                }
            }

            writer.Write(serializationData);
        }

        public static Locator Deserialize(BinaryReader reader)
        {
            //StructureType
            int structureType = reader.ReadByte();

            if (structureType == Locator.MIN.StructureType)
                return Locator.MIN;

            //descriptor
            var descriptor = StructureDescriptor.Deserialize(reader);

            //Items
            string[] items = new string[CountCompression.Deserialize(reader)];
            for (int i = 0; i < items.Length; i++)
                items[i] = reader.ReadString();

            return new Locator(structureType, descriptor, items);
        }

        #region IPath Members

        public int StructureType { get; private set; }

        public string Name
        {
            get { return String.Join(SEPARATOR.ToString(), Path); }
        }

        public KeyDescriptor KeyDescriptor
        {
            get { return descriptor.KeyDescriptor; }
        }

        public RecordDescriptor RecordDescriptor
        {
            get { return descriptor.RecordDescriptor; }
        }

        public IOperationCollection CreateOperationCollection(int capacity)
        {
            return new OperationCollection(this, capacity);
        }

        public IDataContainer CreateDataContainer()
        {
            const int MAX_RECORDS = 128 * 1024;

            var data = new IndexRecordSet(KeyComparer, KeyEqualityComparer);
            data.MAX_RECORDS = MAX_RECORDS;

            return data;
        }

        public IApply Apply { get; private set; }
        public IPersistDataContainer PersistDataContainer { get; private set; }
        public IPersistOperationCollection PersistOperations { get; private set; }
        public IPersist<IData> PersistKey { get; private set; }
        public IComparer<IData> KeyComparer { get; private set; }
        public IEqualityComparer<IData> KeyEqualityComparer { get; private set; }

        public int CompareTo(ILocator other)
        {
            if (Object.ReferenceEquals(other, null))
                throw new ArgumentNullException("other");

            if (Object.ReferenceEquals(this, other))
                return 0;

            //if (Object.ReferenceEquals(this, Locator.MIN))
            //    return -1;
            //if (Object.ReferenceEquals(other, Locator.MIN))
            //    return 1;

            Locator path = (Locator)other;
            int cmp;

            int minLength = Math.Min(Path.Length, path.Path.Length);
            for (int i = 0; i < minLength; i++)
            {
                cmp = Path[i].CompareTo(path.Path[i]);
                //cmp = string.CompareOrdinal(Items[i], other.Items[i]);
                if (cmp != 0)
                    return cmp;
            }

            cmp = Path.Length.CompareTo(path.Path.Length);
            if (cmp != 0)
                return cmp;

            cmp = this.StructureType.CompareTo(other.StructureType);
            if (cmp != 0)
                return cmp;

            return this.descriptor.CompareTo(path.descriptor);
        }

        public bool Equals(ILocator other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            if (this.StructureType != other.StructureType)
                return false;

            Locator locator = (Locator)other;

            if (!this.descriptor.Equals(locator.descriptor))
                return false;

            if (Path.Length != locator.Path.Length)
                return false;

            for (int i = 0; i < Path.Length; i++)
                if (Path[i] != locator.Path[i])
                    return false;

            return true;
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Locator))
                return false;

            return Equals((Locator)obj);
        }

        public string this[int index]
        {
            get { return Path[index]; }
        }

        public int Length
        {
            get { return Path.Length; }
        }

        public override int GetHashCode()
        {
            if (!hashCodeBuilded)
            {
                HashCodeBuilder builder = new HashCodeBuilder();

                //StructureType
                builder.Append(StructureType);

                //descriptor
                builder.Append(descriptor);

                //Items
                for (int i = 0; i < Path.Length; i++)
                    builder.Append(Path[i]);

                hashCode = builder.GetHashCode();
                hashCodeBuilded = true;
            }

            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Locator x, Locator y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;

            if (Object.ReferenceEquals(x, null))
                return false;

            return x.Equals(y);
        }

        public static bool operator !=(Locator x, Locator y)
        {
            return !(x == y);
        }

        public static implicit operator string(Locator locator)
        {
            return locator.ToString();
        }
    }
}
