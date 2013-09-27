using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.SuperCache.Engine
{
    public abstract class BaseCache
    {
        protected internal const string KeyExpiration = "Expiration";

        public abstract void Add<K>(string Category, K Key, object Data);
        public abstract void Add<K, V>(string Category, IEnumerable<KeyValuePair<K, V>> Items, DateTime? ExpirationDate);
        public abstract void Add<K>(string Category, K Key, object Data, DateTime? ExpirationDate);
        public abstract List<KeyValuePair<K, V>> Get<K, V>(string Category, IEnumerable<K> Keys);
        public abstract V Get<K, V>(string Category, K Key);
    }
}
