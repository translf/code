using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using STSdb4.General.Compression;
using STSdb4.Data;
using STSdb4.WaterfallTree;

namespace STSdb4.WaterfallTree
{
    public class RecordDescriptor : DataDescriptor
    {
        public RecordDescriptor(DataType dataType, bool compressData)
            : base(dataType, compressData)
        {
        }

        public void Serialize(BinaryWriter writer)
        {
            DataType.Serialize(writer);
            writer.Write(CompressData);
        }

        public static RecordDescriptor Deserialize(BinaryReader reader)
        {
            var dataType = DataType.Deserialize(reader);
            var compressData = reader.ReadBoolean();

            return new RecordDescriptor(dataType, compressData);
        }
    }
}
