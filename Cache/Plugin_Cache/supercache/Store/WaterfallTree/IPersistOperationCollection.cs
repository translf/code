using STSdb4.General.Persist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.WaterfallTree
{
    public interface IPersistOperationCollection : IPersist<IOperationCollection>
    {
        ILocator Locator { get; }
    }
}
