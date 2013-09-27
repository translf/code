using System.Collections;
using System.Collections.Generic;
using STSdb4.Data;
using STSdb4.WaterfallTree;

namespace STSdb4.Database
{
    public class XIndex<TKey, TRecord> : IIndex<TKey, TRecord>
    {
        public IIndex<IData, IData> Index { get; private set; }
        public IDataTransformer<TKey> KeyTransformer { get; private set; }
        public IDataTransformer<TRecord> RecordTransformer { get; private set; }

        internal XIndex(IIndex<IData, IData> index, IDataTransformer<TKey> keyTransformer, IDataTransformer<TRecord> recordTransformer)
        {
            Index = index;
            KeyTransformer = keyTransformer;
            RecordTransformer = recordTransformer;
        }

        #region IIndex Membres

        public ILocator Locator
        {
            get { return Index.Locator; }
        }

        public void Execute(IOperation operation)
        {
            Index.Execute(operation);
        }

        public void Execute(IOperationCollection operations)
        {
            Index.Execute(operations);
        }

        public void Flush()
        {
            Index.Flush();
        }

        #endregion

        #region IIndex<TKey, TRecord> Membres

        public TRecord this[TKey key]
        {
            get
            {
                IData ikey = KeyTransformer.ToIData(key);
                IData irec = Index[ikey];
                
                return RecordTransformer.FromIData(irec);
            }
            set
            {
                IData ikey = KeyTransformer.ToIData(key);
                IData irec = RecordTransformer.ToIData(value);

                Index[ikey] = irec;
            }
        }

        public void Replace(TKey key, TRecord record)
        {
            IData ikey = KeyTransformer.ToIData(key);
            IData irec = RecordTransformer.ToIData(record);

            Index.Replace(ikey, irec);
        }

        public void InsertOrIgnore(TKey key, TRecord record)
        {
            IData ikey = KeyTransformer.ToIData(key);
            IData irec = RecordTransformer.ToIData(record);

            Index.InsertOrIgnore(ikey, irec);
        }

        public void Delete(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            Index.Delete(ikey);
        }

        public void Delete(TKey fromKey, TKey toKey)
        {
            IData ifrom = KeyTransformer.ToIData(fromKey);
            IData ito = KeyTransformer.ToIData(toKey);

            Index.Delete(ifrom, ito);
        }

        public void Clear()
        {
            Index.Clear();
        }

        public bool Exists(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            return Index.Exists(ikey);
        }

        public bool TryGet(TKey key, out TRecord record)
        {
            IData ikey = KeyTransformer.ToIData(key);

            IData irec;
            if (!Index.TryGet(ikey, out irec))
            {
                record = default(TRecord);
                return false;
            }

            record = RecordTransformer.FromIData(irec);

            return true;
        }

        public TRecord Find(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            IData irec = Index.Find(ikey);
            if (irec == null)
                return default(TRecord);

            TRecord record = RecordTransformer.FromIData(irec);

            return record;
        }

        public TRecord TryGetOrDefault(TKey key, TRecord defaultRecord)
        {
            IData ikey = KeyTransformer.ToIData(key);
            IData idefaultRec = RecordTransformer.ToIData(defaultRecord);
            IData irec = Index.TryGetOrDefault(ikey, idefaultRec);

            TRecord record = RecordTransformer.FromIData(irec);

            return record;
        }

        public KeyValuePair<TKey, TRecord>? FindNext(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            KeyValuePair<IData, IData>? kv = Index.FindNext(ikey);
            if (!kv.HasValue)
                return null;

            TKey k = KeyTransformer.FromIData(kv.Value.Key);
            TRecord r = RecordTransformer.FromIData(kv.Value.Value);

            return new KeyValuePair<TKey, TRecord>(k, r);
        }

        public KeyValuePair<TKey, TRecord>? FindAfter(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            KeyValuePair<IData, IData>? kv = Index.FindAfter(ikey);
            if (!kv.HasValue)
                return null;

            TKey k = KeyTransformer.FromIData(kv.Value.Key);
            TRecord r = RecordTransformer.FromIData(kv.Value.Value);

            return new KeyValuePair<TKey, TRecord>(k, r);
        }

        public KeyValuePair<TKey, TRecord>? FindPrev(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            KeyValuePair<IData, IData>? kv = Index.FindPrev(ikey);
            if (!kv.HasValue)
                return null;

            TKey k = KeyTransformer.FromIData(kv.Value.Key);
            TRecord r = RecordTransformer.FromIData(kv.Value.Value);

            return new KeyValuePair<TKey, TRecord>(k, r);
        }

        public KeyValuePair<TKey, TRecord>? FindBefore(TKey key)
        {
            IData ikey = KeyTransformer.ToIData(key);

            KeyValuePair<IData, IData>? kv = Index.FindBefore(ikey);
            if (!kv.HasValue)
                return null;

            TKey k = KeyTransformer.FromIData(kv.Value.Key);
            TRecord r = RecordTransformer.FromIData(kv.Value.Value);

            return new KeyValuePair<TKey, TRecord>(k, r);
        }

        public IEnumerable<KeyValuePair<TKey, TRecord>> Forward()
        {
            foreach (var kv in Index.Forward())
            {
                TKey key = KeyTransformer.FromIData(kv.Key);
                TRecord rec = RecordTransformer.FromIData(kv.Value);

                yield return new KeyValuePair<TKey, TRecord>(key, rec);
            }
        }

        public IEnumerable<KeyValuePair<TKey, TRecord>> Forward(TKey from, bool hasFrom, TKey to, bool hasTo)
        {
            IData ifrom = hasFrom ? KeyTransformer.ToIData(from) : null;
            IData ito = hasTo ? KeyTransformer.ToIData(to) : null;

            foreach (var kv in Index.Forward(ifrom, hasFrom, ito, hasTo))
            {
                TKey key = KeyTransformer.FromIData(kv.Key);
                TRecord rec = RecordTransformer.FromIData(kv.Value);

                yield return new KeyValuePair<TKey, TRecord>(key, rec);
            }
        }

        public IEnumerable<KeyValuePair<TKey, TRecord>> Backward()
        {
            foreach (var kv in Index.Backward())
            {
                TKey key = KeyTransformer.FromIData(kv.Key);
                TRecord rec = RecordTransformer.FromIData(kv.Value);

                yield return new KeyValuePair<TKey, TRecord>(key, rec);
            }
        }

        public IEnumerable<KeyValuePair<TKey, TRecord>> Backward(TKey to, bool hasTo, TKey from, bool hasFrom)
        {
            IData ito = hasTo ? KeyTransformer.ToIData(to) : null;
            IData ifrom = hasFrom ? KeyTransformer.ToIData(from) : null;
            
            foreach (var kv in Index.Backward(ito, hasTo, ifrom, hasFrom))
            {
                TKey key = KeyTransformer.FromIData(kv.Key);
                TRecord rec = RecordTransformer.FromIData(kv.Value);

                yield return new KeyValuePair<TKey, TRecord>(key, rec);
            }
        }

        public KeyValuePair<TKey, TRecord> FirstRow
        {
            get
            {
                KeyValuePair<IData, IData> kv = Index.FirstRow;

                TKey key = KeyTransformer.FromIData(kv.Key);
                TRecord rec = RecordTransformer.FromIData(kv.Value);

                return new KeyValuePair<TKey, TRecord>(key, rec);
            }
        }

        public KeyValuePair<TKey, TRecord> LastRow
        {
            get
            {
                KeyValuePair<IData, IData> kv = Index.LastRow;

                TKey key = KeyTransformer.FromIData(kv.Key);
                TRecord rec = RecordTransformer.FromIData(kv.Value);

                return new KeyValuePair<TKey, TRecord>(key, rec);
            }
        }

        public long Count()
        {
            return Index.Count();
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey, TRecord>> Members

        public IEnumerator<KeyValuePair<TKey, TRecord>> GetEnumerator()
        {
            return Forward().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
