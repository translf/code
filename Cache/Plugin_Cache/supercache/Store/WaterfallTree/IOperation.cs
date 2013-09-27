using STSdb4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.WaterfallTree
{
    public interface IOperation
    {
        int Code { get; }
        IData FromKey { get; }
        IData ToKey { get; }
        bool IsPoint { get; }
        bool IsOverall { get; }
        bool IsSynchronous { get; }
    }
}
