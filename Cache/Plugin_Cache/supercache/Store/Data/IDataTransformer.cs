using STSdb4.WaterfallTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.Data
{
    public interface IDataTransformer<T>
    {
        IData ToIData(T item);
        T FromIData(IData data);
        DataType DataType { get; }
    }

    public interface IDataTransformer : IDataTransformer<object>
    {
    }
}
