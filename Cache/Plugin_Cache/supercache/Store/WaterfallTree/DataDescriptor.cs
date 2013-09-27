using STSdb4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STSdb4.WaterfallTree
{
    public class DataDescriptor
    {
        public DataType DataType { get; private set; }
        public bool CompressData { get; private set; }

        public DataDescriptor(DataType dataType, bool compress)
        {
            DataType = dataType;
            CompressData = compress;
        }
    }
}
