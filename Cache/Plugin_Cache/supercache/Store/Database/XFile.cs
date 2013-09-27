using STSdb4.Data;
using System;

namespace STSdb4.Database
{
    public class XFile : XStream
    {
        public XFile(IIndex<IData, IData> index)
            : base(index)
        {
        }
    }
}
