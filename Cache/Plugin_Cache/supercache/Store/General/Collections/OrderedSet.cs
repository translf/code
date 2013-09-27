using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using STSdb4.General.Patches;
using STSdb4.General.Extensions;
using STSdb4.General.Comparers;

namespace STSdb4.General.Collections
{
    public class OrderedSet<TKey, TValue> : IOrderedSet<TKey, TValue>
    {
        protected ListPatch<KeyValuePair<TKey, TValue>> list;
        protected Dictionary<TKey, TValue> dictionary;
        protected SortedSet<KeyValuePair<TKey, TValue>> set;

        protected IComparer<TKey> comparer;
        protected IEqualityComparer<TKey> equalityComparer;
        protected KeyValuePairComparer<TKey, TValue> kvComparer;

        protected OrderedSet(IComparer<TKey> comparer, IEqualityComparer<TKey> equalityComparer, ListPatch<KeyValuePair<TKey, TValue>> list)
        {
            this.comparer = comparer;
            this.equalityComparer = equalityComparer;
            kvComparer = new KeyValuePairComparer<TKey, TValue>(comparer);

            this.list = list;
        }

        protected OrderedSet(IComparer<TKey> comparer, IEqualityComparer<TKey> equalityComparer, SortedSet<KeyValuePair<TKey, TValue>> set)
        {
            this.comparer = comparer;
            this.equalityComparer = equalityComparer;
            kvComparer = new KeyValuePairComparer<TKey, TValue>(comparer);

            this.set = set;
        }

        protected OrderedSet(IComparer<TKey> comparer, IEqualityComparer<TKey> equalityComparer, int capacity)
            : this(comparer, equalityComparer, new ListPatch<KeyValuePair<TKey, TValue>>(capacity))
        {
        }

        public OrderedSet(IComparer<TKey> comparer, IEqualityComparer<TKey> equalityComparer)
            : this(comparer, equalityComparer, 4)
        {
        }

        private void TransformListToTree()
        {
            set = new SortedSet<KeyValuePair<TKey, TValue>>(kvComparer);
            set.ConstructFromSortedArray(list.Array, 0, list.Count);
            list = null;
        }

        protected void TransformDictionaryToTree()
        {
            set = new SortedSet<KeyValuePair<TKey, TValue>>(dictionary, kvComparer);
            dictionary = null;
        }

        private void TransformListToDictionary()
        {
            dictionary = new Dictionary<TKey, TValue>(list.Capacity, EqualityComparer);

            foreach (var kv in list)
                dictionary.Add(kv.Key, kv.Value);

            list = null;
        }

        /// <summary>
        /// clear all data and set ordered set to default list mode
        /// </summary>
        private void Reset()
        {
            list = new ListPatch<KeyValuePair<TKey, TValue>>();
            dictionary = null;
            set = null;
        }

        private bool FindIndexes(KeyValuePair<TKey, TValue> from, bool hasFrom, KeyValuePair<TKey, TValue> to, bool hasTo, out int idxFrom, out int idxTo)
        {
            idxFrom = 0;
            idxTo = list.Count - 1;
            Debug.Assert(list.Count > 0);

            if (hasFrom)
            {
                int cmp = Comparer.Compare(from.Key, list[list.Count - 1].Key);
                if (cmp > 0)
                    return false;
                if (cmp == 0)
                {
                    idxFrom = idxTo;
                    return true;
                }
            }

            if (hasTo)
            {
                int cmp = Comparer.Compare(to.Key, list[0].Key);
                if (cmp < 0)
                    return false;
                if (cmp == 0)
                {
                    idxTo = idxFrom;
                    return true;
                }
            }

            if (hasFrom && Comparer.Compare(from.Key, list[0].Key) > 0)
            {
                idxFrom = list.BinarySearch(from, 1, list.Count - 1, kvComparer);
                if (idxFrom < 0)
                    idxFrom = ~idxFrom;
            }

            if (hasTo && Comparer.Compare(to.Key, list[list.Count - 1].Key) < 0)
            {
                idxTo = list.BinarySearch(to, idxFrom, list.Count - idxFrom, kvComparer);
                if (idxTo < 0)
                    idxTo = ~idxTo - 1;
            }

            Debug.Assert(0 <= idxFrom);
            Debug.Assert(idxFrom <= idxTo);
            Debug.Assert(idxTo <= list.Count - 1);

            return true;
        }


        #region IOrderedSet<TKey,TValue> Members

        public IComparer<TKey> Comparer
        {
            get { return comparer; }
            set
            {
                throw new NotSupportedException();
            }
        }

        public IEqualityComparer<TKey> EqualityComparer 
        {
            get { return equalityComparer; }
            set
            {
                throw new NotSupportedException();
            }
        }

        public KeyValuePair<TKey, TValue> First
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("The set is empty.");

                if (list != null)
                    return list[0];

                if (dictionary != null)
                    TransformDictionaryToTree();

                return set.Min;
            }
        }

        public KeyValuePair<TKey, TValue> Last
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("The set is empty.");

                if (list != null)
                    return list[list.Count - 1];

                if (dictionary != null)
                    TransformDictionaryToTree();

                return set.Max;
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> Forward(TKey from, bool hasFrom, TKey to, bool hasTo)
        {
            if (hasFrom && hasTo && comparer.Compare(from, to) > 0)
                throw new ArgumentException("from > to");

            if (Count == 0)
                yield break;

            KeyValuePair<TKey, TValue> fromKey = new KeyValuePair<TKey, TValue>(from, default(TValue));
            KeyValuePair<TKey, TValue> toKey = new KeyValuePair<TKey, TValue>(to, default(TValue));

            if (list != null)
            {
                int idxFrom;
                int idxTo;
                if (!FindIndexes(fromKey, hasFrom, toKey, hasTo, out idxFrom, out idxTo))
                    yield break;

                for (int i = idxFrom; i <= idxTo; i++)
                    yield return list[i];
            }
            else
            {
                if (dictionary != null)
                    TransformDictionaryToTree();

                var enumerable = hasFrom || hasTo ? set.GetViewBetween(fromKey, toKey, hasFrom, hasTo) : set;

                foreach (var x in enumerable)
                    yield return x;
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> Backward(TKey to, bool hasTo, TKey from, bool hasFrom)
        {
            if (hasFrom && hasTo && comparer.Compare(from, to) > 0)
                throw new ArgumentException("from > to");

            if (Count == 0)
                yield break;

            KeyValuePair<TKey, TValue> fromKey = new KeyValuePair<TKey, TValue>(from, default(TValue));
            KeyValuePair<TKey, TValue> toKey = new KeyValuePair<TKey, TValue>(to, default(TValue));

            if (list != null)
            {
                int idxFrom;
                int idxTo;
                if (!FindIndexes(fromKey, hasFrom, toKey, hasTo, out idxFrom, out idxTo))
                    yield break;

                for (int i = idxTo; i >= idxFrom; i--)
                    yield return list[i];
            }
            else
            {
                if (dictionary != null)
                    TransformDictionaryToTree();

                var enumerable = hasFrom || hasTo ? set.GetViewBetween(fromKey, toKey, hasFrom, hasTo) : set;

                foreach (var x in enumerable.Reverse())
                    yield return x;
            }
        }
        
        public IOrderedSet<TKey, TValue> InternalSplit(int count)
        {
            if (list != null)
                return new OrderedSet<TKey, TValue>(Comparer, EqualityComparer, list.Split(count));

            if (dictionary != null)
                TransformDictionaryToTree();

            return new OrderedSet<TKey, TValue>(Comparer, EqualityComparer, set.Split(count));
        }

        /// <summary>
        /// All keys in the input set must be less than all keys in the current set || all keys in the input set must be greater than all keys in the current set.
        /// </summary>
        public void InternalMerge(IOrderedSet<TKey, TValue> set)
        {
            if (set.Count == 0)
                return;

            if (this.Count == 0)
            {
                foreach (var x in set) //set.Forward()
                    list.Add(x);

                return;
            }

            Debug.Assert(comparer.Compare(this.Last.Key, set.First.Key) < 0 || comparer.Compare(this.First.Key, set.Last.Key) > 0);

            if (list != null)
            {
                int idx = kvComparer.Compare(set.Last, list[0]) < 0 ? 0 : list.Count;
                list.InsertRange(idx, set);
            }
            else if (dictionary != null)
            {
                foreach (var kv in set)
                    dictionary.Add(kv.Key, kv.Value); //there should be no exceptions
            }
            else //if (set != null)
            {
                foreach (var kv in set)
                    this.set.Add(kv);
            }
        }

        #endregion

        #region IDictionary<TKey,TValue> Members

        public void Add(TKey key, TValue value)
        {
            KeyValuePair<TKey, TValue> kv = new KeyValuePair<TKey, TValue>(key, value);
            if (set != null)
            {
                set.Replace(kv);
                return;
            }

            if (dictionary != null)
            {
                dictionary[kv.Key] = kv.Value;
                return;
            }

            if (list.Count == 0)
                list.Add(kv);
            else
            {
                var last = list[list.Count - 1];
                int cmp = kvComparer.Compare(last, kv);

                if (cmp > 0)
                {
                    TransformListToDictionary();
                    dictionary[kv.Key] = kv.Value;
                }
                else if (cmp < 0)
                    list.Add(kv);
                else
                    list[list.Count - 1] = kv;
            }
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return TryGetValue(key, out value);
        }

        public ICollection<TKey> Keys
        {
            get { throw new NotSupportedException(); }
        }

        public bool Remove(TKey key)
        {
            KeyValuePair<TKey, TValue> template = new KeyValuePair<TKey, TValue>(key, default(TValue));

            if (list != null)
                TransformListToDictionary();

            if (dictionary != null)
            {
                bool res = dictionary.Remove(key);
                if (dictionary.Count == 0)
                    Reset();

                return res;
            }
            else
            {
                bool res = set.Remove(template);
                if (set.Count == 0)
                    Reset();

                return res;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            KeyValuePair<TKey, TValue> template = new KeyValuePair<TKey, TValue>(key, default(TValue));

            if (list != null)
            {
                int idx = list.BinarySearch(template, kvComparer);
                if (idx >= 0)
                {
                    value = list[idx].Value;
                    return true;
                }
            }
            else if (dictionary != null)
                return dictionary.TryGetValue(template.Key, out value);
            else
            {
                KeyValuePair<TKey, TValue> kv;
                if (set.TryGetValue(template, out kv))
                {
                    value = kv.Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        public ICollection<TValue> Values
        {
            get { throw new NotSupportedException(); }
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!TryGetValue(key, out value))
                    throw new KeyNotFoundException("The key was not found.");

                return value;
            }
            set
            {
                Add(key, value);
            }
        }

        #endregion

        public void AddOrdered(KeyValuePair<TKey, TValue>[] orderedAndUnique, int index, int count)
        {
            if (orderedAndUnique.Length == 0)
                return;
            
            if (set != null)
            {
                for (int i = 0; i < count; i++)
                {
                    var kv = orderedAndUnique[index + i];
                    set.Replace(kv);
                }

                return;
            }

            if (dictionary != null)
            {
                for (int i = 0; i < count; i++)
                {
                    var kv = orderedAndUnique[index + i];
                    dictionary[kv.Key] = kv.Value;
                }

                return;
            }

            if (list.Count == 0 || Comparer.Compare(list[list.Count - 1].Key, orderedAndUnique[index].Key) < 0)
            {
                list.AddRange(orderedAndUnique, index, count);
                return;
            }

            ListPatch<KeyValuePair<TKey, TValue>> tmp = new ListPatch<KeyValuePair<TKey, TValue>>(list.Count + count);
            tmp.AddRange(orderedAndUnique.Skip(index).Take(count).Merge(list, kvComparer));
            list = tmp;
        }

        public void InternalCopyTo(KeyValuePair<TKey, TValue>[] array, out bool isOrdered)
        {
            CopyTo(array, 0);
            isOrdered = dictionary == null;
        }

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Reset();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (list != null)
            {
                list.CopyTo(array, arrayIndex);
                return;
            }

            if (dictionary != null)
            {
                foreach (var kv in dictionary)
                    array[arrayIndex++] = kv;

                return;
            }

            set.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                if (list != null)
                    return list.Count;

                if (dictionary != null)
                    return dictionary.Count;

                return set.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool Remove(TKey from, bool hasFrom, TKey to, bool hasTo)
        {
            if (Count == 0)
                return false;

            if (!hasFrom && !hasTo)
            {
                Clear();
                return true;
            }

            if (list != null)
                TransformListToTree();
            else if (dictionary != null)
                TransformDictionaryToTree();

            KeyValuePair<TKey, TValue> fromKey = hasFrom ? new KeyValuePair<TKey, TValue>(from, default(TValue)) : set.Min;
            KeyValuePair<TKey, TValue> toKey = hasTo ? new KeyValuePair<TKey, TValue>(to, default(TValue)) : set.Max;

            bool res = set.Remove(fromKey, toKey);
            if (set.Count == 0)
                Reset();

            return res;
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Forward(default(TKey), false, default(TKey), false).GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
