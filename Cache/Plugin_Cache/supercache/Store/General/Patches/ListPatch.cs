using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace STSdb4.General.Patches
{
    public class ListPatch<T> : IList<T>
    {
        private static T[] emptyArray;

        static ListPatch()
        {
            emptyArray = new T[0];
        }

        public const int DEFAULT_CAPACITY = 4;
        public T[] Array { get; private set; }
        public int Count { get; private set; }
        public int Version { get; private set; }

        public ListPatch(T[] array)
        {
            Set(array);
        }

        public ListPatch(int capacity)
        {
            Array = new T[capacity];
        }

        public ListPatch()
            : this(DEFAULT_CAPACITY)
        {
        }

        public ListPatch(IEnumerable<T> collection)
            :this()
        {
            InsertRange(0, collection);
        }

        public void Set(T[] array)
        {
            Array = array;
            Count = array.Length;
            Version++;
        }

        private void EnsureCapacity(int min)
        {
            if (Array.Length >= min)
                return;

            int cap = (Array.Length == 0) ? 4 : (Array.Length * 2);
            if (cap < min)
                cap = min;

            Capacity = cap;
        }

        public int BinarySearch(T item, int index, int length, IComparer<T> comparer)
        {
            return System.Array.BinarySearch<T>(Array, index, length, item, comparer);
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return BinarySearch(item, 0, Count, comparer);
        }

        public int BinarySearch(T item)
        {
            return BinarySearch(item, Comparer<T>.Default);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > Count)
                throw new ArgumentOutOfRangeException("startIndex");

            if ((count < 0) || (startIndex > Count - count))
                throw new ArgumentOutOfRangeException("startIndex");

            if (match == null)
                throw new ArgumentOutOfRangeException("match");

            int num = startIndex + count;

            for (int i = startIndex; i < num; i++)
            {
                if (match(this.Array[i]))
                    return i;
            }

            return -1;
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return FindIndex(startIndex, Count - startIndex, match);
        }

        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, Count, match);
        }

        public IEnumerable<T> Forward()
        {
            return this;
        }

        public IEnumerable<T> Backward()
        {
            for (int i = Count - 1; i >= 0; i--)
                yield return Array[i];
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            ListPatch<T> list = collection as ListPatch<T>;
            int count = list != null ? list.Count : collection.Count();
            if (count == 0)
                return;

            EnsureCapacity(Count + count);
            System.Array.Copy(Array, index, Array, index + count, Count - index);

            if (list != null)
                System.Array.Copy(list.Array, 0, Array, index, count);
            else
            {
                foreach (var x in collection)
                    Array[index++] = x;
            }

            Count += count;
            Version++;
        }

        public void AddRange(T[] array, int index, int count)
        {
            EnsureCapacity(Count + count);
            System.Array.Copy(array, index, this.Array, Count, count);
            Count += count;
            Version++;
        }

        public void AddRange(ListPatch<T> list, int index, int count)
        {
            AddRange(list.Array, index, count);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            InsertRange(Count, collection);
        }

        public int Capacity
        {
            get
            {
                return Array.Length;
            }
            set
            {
                if (value == Array.Length)
                    return;

                if (value < Count)
                    throw new ArgumentOutOfRangeException(value.ToString());

                if (value == 0)
                {
                    Array = emptyArray;
                    return;
                }

                T[] tmpArray = new T[value];
                if (Count > 0)
                    System.Array.Copy(Array, 0, tmpArray, 0, Count);

                Array = tmpArray;
            }
        }

        /// <summary>
        /// Splits the list into two parts, where the right part contains count elements.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>the right part of the list</returns>
        public ListPatch<T> Split(int count)
        {
            ListPatch<T> list = new ListPatch<T>(Capacity);
            System.Array.Copy(this.Array, Count - count, list.Array, 0, count);
            list.Count = count;
            Count-= count;
            Version++;

            return list;
        }

        #region IList<T> Members

        public int IndexOf(T item)
        {
            return System.Array.IndexOf<T>(this.Array, item, 0, Count);
        }

        public void Insert(int index, T item)
        {
            if (index > Count)
                throw new ArgumentOutOfRangeException("index");

            if (Count == Capacity)
                EnsureCapacity(Count + 1);

            if (index < Count)
                System.Array.Copy(Array, index, Array, index + 1, Count - index);

            Array[index] = item;
            Count++;
            Version++;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count)
                throw new ArgumentOutOfRangeException("index");

            Count--;
            if (index < Count)
                System.Array.Copy(Array, index + 1, Array, index, Count - index);

            Array[Count] = default(T);
            Version++;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException(index.ToString());
                
                return Array[index];
            }
            set
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException(index.ToString());

                Array[index] = value;
                Version++;
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            if (Count == Capacity)
                EnsureCapacity(Count + 1);

            Array[Count++] = item;
            Version++;
        }

        public void Clear()
        {
            if (Count == 0)
                return;

            System.Array.Clear(Array, 0, Count);
            Count = 0;
            Version++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                for (int j = 0; j < Count; j++)
                {
                    if (Array[j] == null)
                        return true;
                }

                return false;
            }

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < Count; i++)
            {
                if (comparer.Equals(Array[i], item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            System.Array.Copy(Array, 0, array, arrayIndex, Count);
            Version++;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public bool RemoveRange(int index, int count)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("ïndex");

            if (count < 0)
                throw new ArgumentOutOfRangeException("count");

            if (count > 0)
            {
                Count -= count;
                if (index < Count)
                    System.Array.Copy(Array, index + count, Array, index, Count - index);

                System.Array.Clear(Array, Count, count);
                Version++;

                return true;
            }

            return false;
        }

        public bool Remove(T fromKey, T toKey, IComparer<T> comparer)
        {
            int cmp = comparer.Compare(fromKey, toKey);
            if (cmp > 0)
                throw new ArgumentException();

            int from = BinarySearch(fromKey, comparer);
            int fromIdx = from;
            if (fromIdx < 0)
            {
                fromIdx = ~fromIdx;
                if (fromIdx == Count)
                    return false;
            }

            int to = BinarySearch(toKey, fromIdx, Count - fromIdx, comparer);
            int toIdx = to;
            if (toIdx < 0)
            {
                if (from == to)
                    return false;

                toIdx = ~toIdx - 1;
            }

            int count = toIdx - fromIdx + 1;
            if (count == 0)
                return false;

            return RemoveRange(fromIdx, count);
        }

        #endregion

        public void Sort()
        {
            Sort(Comparer<T>.Default);
        }

        public void Sort(IComparer<T> comparer)
        {
            Sort(0, Count, comparer);
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            System.Array.Sort(this.Array, index, count, comparer);
            Version++;
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return Array[i];
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
