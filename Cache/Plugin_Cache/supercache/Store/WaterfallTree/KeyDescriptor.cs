using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using STSdb4.General.Compression;
using STSdb4.General.Persist;
using STSdb4.Data;
using STSdb4.WaterfallTree;
using STSdb4.General.Comparers;

namespace STSdb4.WaterfallTree
{
    public class KeyDescriptor : DataDescriptor
    {
        private CompareOption[] compareOptions;
        public bool AreDefaultCompareOptions { get; private set; }

        public KeyDescriptor(DataType dataType, bool compressData, CompareOption[] compareOptions = null)
            : base(dataType, compressData)
        {
            this.compareOptions = compareOptions;
            AreDefaultCompareOptions = compareOptions == null;
        }

        public void Serialize(BinaryWriter writer)
        {
            DataType.Serialize(writer);
            writer.Write(CompressData);
            writer.Write(AreDefaultCompareOptions);

            if (!AreDefaultCompareOptions)
            {
                for (int i = 0; i < compareOptions.Length; i++)
                    compareOptions[i].Serialize(writer);
            }
        }

        public static KeyDescriptor Deserialize(BinaryReader reader)
        {
            DataType dataType = DataType.Deserialize(reader);
            bool compressData = reader.ReadBoolean();
            bool hasDefaultCompareOptions = reader.ReadBoolean();

            CompareOption[] compareOptions = null;

            if (!hasDefaultCompareOptions)
            {
                compareOptions = new CompareOption[dataType.IsPrimitive ? 1 : dataType.TypesCount];

                for (int i = 0; i < compareOptions.Length; i++)
                    compareOptions[i] = CompareOption.Deserialize(reader);
            }

            return new KeyDescriptor(dataType, compressData, compareOptions);
        }

        public CompareOption[] CompareOptions
        {
            get
            {
                if (compareOptions == null)
                    compareOptions = DataType.GetDefaultCompareOptions();

                return compareOptions;
            }
        }
    }
}
