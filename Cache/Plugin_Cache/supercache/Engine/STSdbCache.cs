using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.Database;
using fastJSON;
using System.IO;

namespace Com.SuperCache.Engine
{
    public class STSdbCache : BaseCache
    {
        private string dataPath;
        private static IStorageEngine memoryInstance = null;
        private static object syncRoot = new object();
        private bool isMemory = false;

        public STSdbCache(string DataPath)
        {
            dataPath = DataPath;
            if (!dataPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                dataPath += Path.DirectorySeparatorChar;

            isMemory = string.IsNullOrEmpty(DataPath);
        }

        public override void Add<K>(string Category, K Key, object Data)
        {
            Add(Category, Key, Data, null);
        }

        private IStorageEngine Engine
        {
            get
            {
                if (isMemory)
                {
                    lock (syncRoot)
                    {
                        if (memoryInstance == null)
                            memoryInstance = STSdb.FromMemory();
                    }
                    return memoryInstance;
                }
                else
                    return STSdb.FromFile(GetFile(false), GetFile(true));
            }
        }

        private string GetExpirationTable(string Category)
        {
            return KeyExpiration + "_" + Category;
        }

        public override void Add<K, V>(string Category, IEnumerable<KeyValuePair<K, V>> Items, DateTime? ExpirationDate)
        {
            lock (syncRoot)
            {
                var engine = Engine;
                var table = engine.OpenXIndex<K, string>(Category);
                Items.ForEach(i =>
                    {
                        var key = i.Key;
                        var data = i.Value;
                        //will only serialize object other than string
                        var result = typeof(V) == typeof(string) ? data as string : JSON.Instance.ToJSON(data);
                        table[key] = result;
                        table.Flush();

                        //specify expiration
                        var expiration = engine.OpenXIndex<K, DateTime>(GetExpirationTable(Category));
                        //default 30 mins to expire from now
                        var expirationDate = ExpirationDate == null || ExpirationDate <= DateTime.Now ? DateTime.Now.AddMinutes(30) : (DateTime)ExpirationDate;
                        expiration[key] = expirationDate;
                        expiration.Flush();
                    });
                engine.Commit();

                //only dispose disk-based engine
                if (!isMemory)
                    engine.Dispose();
            }
        }

        public override void Add<K>(string Category, K Key, object Data, DateTime? ExpirationDate)
        {
            Add<K, object>(Category, new List<KeyValuePair<K, object>> { new KeyValuePair<K, object>(Key, Data) }, ExpirationDate);
        }

        private string GetFile(bool IsData)
        {
            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);
            return dataPath + "SuperCache." + (IsData ? "dat" : "sys");
        }

        public override List<KeyValuePair<K, V>> Get<K, V>(string Category, IEnumerable<K> Keys)
        {
            var result = new List<KeyValuePair<K, V>>();
            lock (syncRoot)
            {
                var engine = Engine;
                var table = engine.OpenXIndex<K, string>(Category);
                var expiration = engine.OpenXIndex<K, DateTime>(GetExpirationTable(Category));
                var isCommitRequired = false;

                Keys.ForEach(key =>
                    {
                        string buffer;
                        V value;
                        if (table.TryGet(key, out buffer))
                        {
                            //will only deserialize object other than string
                            value = typeof(V) == typeof(string) ? (V)(object)buffer : JSON.Instance.ToObject<V>(buffer);
                            DateTime expirationDate;
                            //get expiration date
                            if (expiration.TryGet(key, out expirationDate))
                            {
                                //expired
                                if (expirationDate < DateTime.Now)
                                {
                                    value = default(V);
                                    table.Delete(key);
                                    table.Flush();
                                    expiration.Delete(key);
                                    expiration.Flush();
                                    isCommitRequired = true;
                                }
                            }
                        }
                        else
                            value = default(V);

                        result.Add(new KeyValuePair<K, V>(key, value));
                    });

                //only need to commit write actions
                if (isCommitRequired)
                    engine.Commit();

                //only dispose disk-based engine
                if (!isMemory)
                    engine.Dispose();
            }
            return result;
        }

        public override V Get<K, V>(string Category, K Key)
        {
            var buffer = Get<K, V>(Category, new K[] { Key });
            var result = buffer.FirstOrDefault();
            return result.Value;
        }
    }
}
