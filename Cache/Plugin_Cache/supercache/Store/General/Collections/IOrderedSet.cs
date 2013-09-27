using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.General.Collections
{
    public interface IOrderedSet<TKey, TValue> : IDictionary<TKey, TValue>
    {
        IComparer<TKey> Comparer { get; set; }
        IEqualityComparer<TKey> EqualityComparer { get; set; }

        void AddOrdered(KeyValuePair<TKey, TValue>[] orderedAndUnique, int index, int count);
        bool Remove(TKey from, bool hasFrom, TKey to, bool hasTo);
        void InternalCopyTo(KeyValuePair<TKey, TValue>[] array, out bool isOrdered);

        KeyValuePair<TKey, TValue> First { get; }
        KeyValuePair<TKey, TValue> Last { get; }

        IEnumerable<KeyValuePair<TKey, TValue>> Forward(TKey from, bool hasFrom, TKey to, bool hasTo);
        IEnumerable<KeyValuePair<TKey, TValue>> Backward(TKey to, bool hasTo, TKey from, bool hasFrom);
    }
}