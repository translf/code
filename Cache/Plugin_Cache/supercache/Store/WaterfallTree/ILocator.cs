using STSdb4.General.Persist;
using STSdb4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.WaterfallTree
{
    public interface ILocator : IComparable<ILocator>, IEquatable<ILocator>
    {
        int StructureType { get; }
        string Name { get; }

        KeyDescriptor KeyDescriptor { get; }
        RecordDescriptor RecordDescriptor { get; }

        IOperationCollection CreateOperationCollection(int capacity);
        IDataContainer CreateDataContainer();

        IApply Apply { get; }
        IPersistDataContainer PersistDataContainer { get; }
        IPersistOperationCollection PersistOperations { get; }
        IPersist<IData> PersistKey { get; }
        IComparer<IData> KeyComparer { get; }
        IEqualityComparer<IData> KeyEqualityComparer { get; }
    }
}
