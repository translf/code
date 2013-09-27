using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.Database;
//using fastJSON;
using System.IO;

namespace Com.SuperCache.Engine
{
    public enum CacheProviders
    {
        Default = 1,
        Raw = 2
    }

    public class CacheEngine
    {
        private BaseCache cacheProvider = null;

        public CacheEngine(string DataPath): this(CacheProviders.Default, DataPath)
        {
        }

        public CacheEngine(CacheProviders Provider, string DataPath)
        {
            switch (Provider)
            {
                case CacheProviders.Default:
                    cacheProvider = new STSdbCache(DataPath);
                    break;
                case CacheProviders.Raw:
                    cacheProvider = new RawCache(DataPath);
                    break;
                default:
                    break;
            }
        }

        public void Add<K>(string Category, K Key, object Data)
        {
            cacheProvider.Add<K>(Category, Key, Data);
        }

        public void Add<K, V>(string Category, IEnumerable<KeyValuePair<K, V>> Items, DateTime? ExpirationDate)
        {
            cacheProvider.Add<K, V>(Category, Items, ExpirationDate);
        }

        public void Add<K>(string Category, K Key, object Data, DateTime? ExpirationDate)
        {
            cacheProvider.Add<K, object>(Category, new List<KeyValuePair<K, object>> { new KeyValuePair<K, object>(Key, Data) }, ExpirationDate);
        }

        public List<KeyValuePair<K, V>> Get<K, V>(string Category, IEnumerable<K> Keys)
        {
            return cacheProvider.Get<K, V>(Category, Keys);
        }

        public V Get<K, V>(string Category, K Key)
        {
            return cacheProvider.Get<K, V>(Category, Key);
        }
    }
}