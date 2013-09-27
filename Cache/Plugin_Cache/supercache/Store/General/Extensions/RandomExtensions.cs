using STSdb4.General.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.General.Extensions
{
    public enum KeysType
    {
        Sequential,
        Random
    }
    
    public static class RandomExtensions
    {
        /// <summary>
        /// Generates random flow of rows.
        /// </summary>
        public static IEnumerable<KeyValuePair<byte[], byte[]>> Flow(this Random random, long COUNT, int KEY_LENGTH, int REC_LENGTH, KeysType keys, ByteOrder byteOrder)
        {
            if (KEY_LENGTH < 8)
                throw new ArgumentException("KEY_LENGTH < 8");

            switch (keys)
            {
                case KeysType.Random:
                    {
                        for (long i = 0; i < COUNT; i++)
                        {
                            byte[] key = new byte[KEY_LENGTH];
                            random.NextBytes(key);

                            byte[] rec = new byte[REC_LENGTH];
                            random.NextBytes(rec);

                            yield return new KeyValuePair<byte[], byte[]>(key, rec);
                        }
                    }
                    break;

                case KeysType.Sequential:
                    {
                        switch (byteOrder)
                        {
                            case ByteOrder.LittleEndian:
                                {
                                    for (long i = 0; i < COUNT; i++)
                                    {
                                        byte[] key = new byte[KEY_LENGTH];

                                        var b = BitConverter.GetBytes(i);
                                        key[0] = b[0];
                                        key[1] = b[1];
                                        key[2] = b[2];
                                        key[3] = b[3];
                                        key[4] = b[4];
                                        key[5] = b[5];
                                        key[6] = b[6];
                                        key[7] = b[7];

                                        byte[] rec = new byte[REC_LENGTH];
                                        random.NextBytes(rec);

                                        yield return new KeyValuePair<byte[], byte[]>(key, rec);
                                    }
                                }
                                break;

                            case ByteOrder.BigEndian:
                                {
                                    for (long i = 0; i < COUNT; i++)
                                    {
                                        byte[] key = new byte[KEY_LENGTH];

                                        var b = BitConverter.GetBytes(i);
                                        key[KEY_LENGTH - 1] = b[0];
                                        key[KEY_LENGTH - 2] = b[1];
                                        key[KEY_LENGTH - 3] = b[2];
                                        key[KEY_LENGTH - 4] = b[3];
                                        key[KEY_LENGTH - 5] = b[4];
                                        key[KEY_LENGTH - 6] = b[5];
                                        key[KEY_LENGTH - 7] = b[6];
                                        key[KEY_LENGTH - 8] = b[7];

                                        byte[] rec = new byte[REC_LENGTH];
                                        random.NextBytes(rec);

                                        yield return new KeyValuePair<byte[], byte[]>(key, rec);
                                    }
                                }
                                break;

                            default:
                                throw new NotSupportedException(byteOrder.ToString());
                        }
                    }
                    break;

                default:
                    throw new NotSupportedException(keys.ToString());
            }
        }
    }
}
