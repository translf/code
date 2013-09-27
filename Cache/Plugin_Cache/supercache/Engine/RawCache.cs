using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.Database;
using fastJSON;
using System.IO;

namespace Com.SuperCache.Engine
{
    public class RawCache : BaseCache
    {
        private string dataPath;
        private static Dictionary<string, object> memoryData = new Dictionary<string, object>();
        private static Dictionary<string, DateTime?> memoryExpiration = new Dictionary<string, DateTime?>();
        private static object syncRoot = new object();
        private bool isMemory = false;

        public RawCache(string DataPath)
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

        private string GetExpirationTable(string Category)
        {
            return KeyExpiration + "_" + Category;
        }

        public override void Add<K, V>(string Category, IEnumerable<KeyValuePair<K, V>> Items, DateTime? ExpirationDate)
        {
            lock (syncRoot)
            {
                Items.ForEach(i =>
                    {
                        var key = i.Key;
                        var data = i.Value;

                        if (isMemory)
                        {
                            var memKey = GetKey(Category, key.ToString());
                            memoryData[memKey] = data;
                            memoryExpiration[memKey] = ExpirationDate;
                        }
                        else
                        {
                            //will only serialize object other than string
                            var result = typeof(V) == typeof(string) ? data as string : JSON.Instance.ToJSON(data);
                            File.WriteAllText(GetFile(key.ToString(), true), result);

                            //specify expiration
                            //default 30 mins to expire from now
                            var expirationDate = ExpirationDate == null || ExpirationDate <= DateTime.Now ? DateTime.Now.AddMinutes(30) : (DateTime)ExpirationDate;
                            File.WriteAllText(GetFile(key.ToString(), false), expirationDate.ToString());
                        }
                    });
            }
        }

        public override void Add<K>(string Category, K Key, object Data, DateTime? ExpirationDate)
        {
            Add<K, object>(Category, new List<KeyValuePair<K, object>> { new KeyValuePair<K, object>(Key, Data) }, ExpirationDate);
        }

        private string GetFile(string FileName, bool IsData)
        {
            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);
            return dataPath + "SuperCache_" + FileName.NormalizeFileName() + "." + (IsData ? "dat" : "exp");
        }

        private string GetKey(string Category, string Key)
        {
            return Category + "_" + Key;
        }

        public override List<KeyValuePair<K, V>> Get<K, V>(string Category, IEnumerable<K> Keys)
        {
            var result = new List<KeyValuePair<K, V>>();
            lock (syncRoot)
            {
                Keys.ForEach(key =>
                    {
                        string buffer;
                        V value;
                        if (isMemory)
                        {
                            var memKey = GetKey(Category, key.ToString());
                            object memBuffer;
                            if (memoryData.TryGetValue(memKey, out memBuffer))
                            {
                                value = (V)memBuffer;
                                DateTime? expirationDate;
                                if (memoryExpiration.TryGetValue(memKey, out expirationDate))
                                {
                                    //expired
                                    if (expirationDate != null && (DateTime)expirationDate < DateTime.Now)
                                    {
                                        value = default(V);
                                        memoryData.Remove(memKey);
                                        memoryExpiration.Remove(memKey);
                                    }
                                }
                            }
                            else
                                value = default(V);
                        }
                        else
                        {
                            var dataFilePath = GetFile(key.ToString(), true);
                            if (File.Exists(dataFilePath))
                            {
                                buffer = File.ReadAllText(dataFilePath);

                                //will only deserialize object other than string
                                value = typeof(V) == typeof(string) ? (V)(object)buffer : JSON.Instance.ToObject<V>(buffer);
                                DateTime expirationDate;
                                var expirationFilePath = GetFile(key.ToString(), false);
                                if (File.Exists(expirationFilePath))
                                {
                                    buffer = File.ReadAllText(expirationFilePath);
                                    expirationDate = Convert.ToDateTime(buffer);
                                    //expired
                                    if (expirationDate < DateTime.Now)
                                    {
                                        value = default(V);
                                        File.Delete(dataFilePath);
                                        File.Delete(expirationFilePath);
                                    }
                                }
                            }
                            else
                                value = default(V);
                        }

                        result.Add(new KeyValuePair<K, V>(key, value));
                    });
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
