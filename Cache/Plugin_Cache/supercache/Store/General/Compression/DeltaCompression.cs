using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using STSdb4.General.Buffers;

namespace STSdb4.General.Compression
{
    public class DeltaCompression
    {
        private const int ULONG_BITS_COUNT = 8 * sizeof(ulong);

        /// <summary>
        /// Writes a value that fit in bitsCount number of bits in array at bitIndex position
        /// </summary>
        public static void SetBits(ulong[] dest, ulong source, int bitIndex, int bitsCount)
        {
            Debug.Assert(bitsCount > 0 && bitsCount <= ULONG_BITS_COUNT);
            Debug.Assert(BitUtils.GetBitBounds(source) <= bitsCount);
            
            dest[bitIndex / ULONG_BITS_COUNT] |= source << (bitIndex % ULONG_BITS_COUNT);
            //does the number take more than one element from the array
            if (bitIndex % ULONG_BITS_COUNT + bitsCount > ULONG_BITS_COUNT)
                dest[bitIndex / ULONG_BITS_COUNT + 1] |= source >> (ULONG_BITS_COUNT - bitIndex % ULONG_BITS_COUNT);
        }

        /// <summary>
        /// returns the writed on bitIndex position value
        /// </summary>
        public static ulong GetBits(ulong[] source, int bitIndex, int bitsCount)
        {
            Debug.Assert(bitsCount > 0 && bitsCount <= ULONG_BITS_COUNT);
            
            if (bitIndex % ULONG_BITS_COUNT + bitsCount <= ULONG_BITS_COUNT)
                return (source[bitIndex / ULONG_BITS_COUNT] >> (bitIndex % ULONG_BITS_COUNT)) &
                        (UInt64.MaxValue >> (ULONG_BITS_COUNT - bitsCount));
            else
                return ((source[bitIndex / ULONG_BITS_COUNT + 1] << (ULONG_BITS_COUNT - bitIndex % ULONG_BITS_COUNT)) |
                        (source[bitIndex / ULONG_BITS_COUNT] >> (bitIndex % ULONG_BITS_COUNT))) &
                        (UInt64.MaxValue >> (ULONG_BITS_COUNT - bitsCount));
        }

        private static void CoreCompress(BinaryWriter writer, IList<long> src, int smallDeltaBits, int bigDeltaBits, int upCount, int downCount, int equalsCount, bool useOneDelta, ulong oneDeltaValue)
        {
            //store the count of elements
            CountCompression.Serialize(writer, checked((ulong)src.Count));

            if (src.Count < 2)
            {
                for (int i = 0; i < src.Count; i++)
                    writer.Write(src[i]);
                return;
            }

            ulong[] tmpData = new ulong[3 + 2 * src.Count];//+3x64 system bits
            int bitIndex = 0;

            //store if the data is monotone and if is - ascending or descending
            ulong monotoneFlag = 0;//00 - not monotone
            if (upCount == src.Count - 1 - equalsCount)
                monotoneFlag = 2;//10 - monotone and ascending
            else if (downCount == src.Count - 1 - equalsCount)
                monotoneFlag = 3;//11 - monotone and descending
            SetBits(tmpData, monotoneFlag, bitIndex, 2);
            bitIndex += 2;

            //do we have only one delta?
            SetBits(tmpData, useOneDelta ? (ulong)1 : (ulong)0, bitIndex, 1);
            bitIndex++;

            ulong useOneDeltaType = 0;

            if (useOneDelta)
            {
                //stores how much bits is the delta
                SetBits(tmpData, (ulong)bigDeltaBits, bitIndex, 7);
                bitIndex += 7;

                //store the delta
                SetBits(tmpData, oneDeltaValue, bitIndex, bigDeltaBits);
                bitIndex += bigDeltaBits;
            }
            else
            {
                //do we use only one type of delta?
                useOneDeltaType = (smallDeltaBits == bigDeltaBits) ? (ulong)1 : (ulong)0;
                SetBits(tmpData, useOneDeltaType, bitIndex, 1);
                bitIndex++;

                //store how many bits is the big delta and how many is the small delta
                SetBits(tmpData, (ulong)bigDeltaBits, bitIndex, 7);
                bitIndex += 7;
                if (useOneDeltaType == 0)
                {
                    SetBits(tmpData, (ulong)smallDeltaBits, bitIndex, 7);
                    bitIndex += 7;
                }
            }

            //store the first element
            writer.Write(src[0]);

            if (!useOneDelta)
            {
                ulong delta, sign;

                //the sequental is not monotone
                for (int i = 0; i < src.Count - 1; i++)
                {
                    long value1 = src[i];
                    long value2 = src[i + 1];

                    if (value2 >= value1)
                    {
                        delta = (ulong)(value2 - value1);
                        sign = 0;
                    }
                    else
                    {
                        delta = (ulong)(value1 - value2);
                        sign = 1;
                    }

                    //type of delta - big or small
                    int actualDeltaBits = bigDeltaBits;
                    if (useOneDeltaType == 0)
                    {

                        int deltaBits = BitUtils.GetBitBounds(delta);
                        ulong deltaType = 1;
                        if (deltaBits <= smallDeltaBits)
                        {
                            deltaType = 0;
                            actualDeltaBits = smallDeltaBits;
                        }

                        SetBits(tmpData, deltaType, bitIndex, 1);
                        bitIndex++;
                    }

                    if (monotoneFlag == 0)
                    {
                        //store the sign of delta
                        SetBits(tmpData, sign, bitIndex, 1);
                        bitIndex++;
                    }

                    //at the last, store the delta
                    SetBits(tmpData, delta, bitIndex, actualDeltaBits);
                    bitIndex += actualDeltaBits;
                }
            }

            int dataCount = (int)Math.Ceiling(bitIndex / 64.0);
            int bytesCount = sizeof(ulong) * dataCount;

            CountCompression.Serialize(writer, checked((ulong)bytesCount));
            for (int i = 0; i < dataCount; i++)
                writer.Write(tmpData[i]);
        }

        public static void CoreCompress(BinaryWriter writer, IList<long> src, DeltaCompression.Helper helper)
        {
            CoreCompress(writer, src, helper.SmallDeltaBits, helper.BigDeltaBits, helper.UpCount, helper.DownCount, helper.EqualsCount, helper.UseOneDelta, helper.OneDeltaValue);
        }

        public static IList<long> CoreDecompress(BinaryReader reader)
        {
            int resLength = (int)CountCompression.Deserialize(reader);
            IList<long> res = new List<long>(resLength) ;

            if (resLength < 2)
            {
                if (resLength == 1)
                    res.Add(reader.ReadInt64());
                return res;
            }

            //read the first element
            res.Add(reader.ReadInt64());

            int bytesCount = (int)CountCompression.Deserialize(reader);
            ulong[] tmpData = new ulong[(int)Math.Ceiling(bytesCount / 8.0)];
            for (int j = 0; j < tmpData.Length; j++)
                tmpData[j] = reader.ReadUInt64();

            int bitIndex = 0, i;

            //is data monote?
            ulong monotoneFlag = GetBits(tmpData, bitIndex, 2);
            bitIndex += 2;

            //have we only one delta?
            bool useOneDelta = GetBits(tmpData, bitIndex, 1) == 1;
            bitIndex++;

            int smallDeltaBits = 0, bigDeltaBits = 0;
            long delta = 0;
            ulong useOneDeltaType = 0, sign;

            if (useOneDelta)
            {
                //how many bits is the delta, what is it value?
                bigDeltaBits = (int)GetBits(tmpData, bitIndex, 7);
                bitIndex += 7;

                delta = (long)GetBits(tmpData, bitIndex, bigDeltaBits);
                bitIndex += bigDeltaBits;
            }
            else
            {
                //how many types of delta we use - one or two. What are they?
                useOneDeltaType = GetBits(tmpData, bitIndex, 1);
                bitIndex++;

                bigDeltaBits = (int)GetBits(tmpData, bitIndex, 7);
                bitIndex += 7;

                if (useOneDeltaType == 0)
                {
                    smallDeltaBits = (int)GetBits(tmpData, bitIndex, 7);
                    bitIndex += 7;
                }
            }

            if (useOneDelta)
            {
                sign = monotoneFlag & 1;
                if (sign == 0)
                {
                    for (i = 1; i < resLength; i++)
                        res.Add(res[i - 1] + delta);
                }
                else
                {
                    for (i = 1; i < resLength; i++)
                        res.Add(res[i - 1] - delta);
                }
            }
            else
            {
                for (i = 1; i < resLength; i++)
                {
                    int actualDeltaBits = bigDeltaBits;
                    if (useOneDeltaType == 0)
                    {
                        ulong deltaType = GetBits(tmpData, bitIndex, 1);
                        bitIndex++;
                        if (deltaType == 0)
                            actualDeltaBits = smallDeltaBits;
                    }

                    if (monotoneFlag == 0)
                    {
                        sign = GetBits(tmpData, bitIndex, 1);
                        bitIndex++;
                    }
                    else
                        sign = monotoneFlag & 1;

                    delta = (long)GetBits(tmpData, bitIndex, actualDeltaBits);
                    bitIndex += actualDeltaBits;
                    res.Add(res[i - 1] + ((sign == 0) ? delta : -delta));
                }
            }

            return res;
        }

        public class Helper
        {
            private int[] deltasBits = new int[ULONG_BITS_COUNT + 1];
            private long oldValue;
            private ulong delta;
            private int oneDeltaSign;
            public int BigDeltaBits { get; private set; }
            public int UpCount { get; private set; }
            public int DownCount { get; private set; }
            public int EqualsCount { get; private set; }
            public ulong OneDeltaValue { get; private set; }
            public bool UseOneDelta { get; private set; }
            public int Count { get; private set; }
            
            public Helper()
            {
                UseOneDelta = true;
            }

            public void AddValue(long value)
            {
                if (Count > 1)
                {
                    if (value > oldValue)
                    {
                        delta = (ulong)(value - oldValue);
                        UpCount++;
                        if (UseOneDelta)
                        {
                            if (oneDeltaSign != 1 || delta != OneDeltaValue)
                                UseOneDelta = false;
                        }
                    }
                    else if (value < oldValue)
                    {
                        delta = (ulong)(oldValue - value);
                        DownCount++;
                        if (UseOneDelta)
                        {
                            if (oneDeltaSign != -1 || delta != OneDeltaValue)
                                UseOneDelta = false;
                        }
                    }
                    else
                    {
                        delta = 0;
                        EqualsCount++;
                        if (UseOneDelta)
                        {
                            if (oneDeltaSign != 0 || delta != OneDeltaValue)
                                UseOneDelta = false;
                        }
                    }

                    int deltaBit = BitUtils.GetBitBounds(delta);
                    deltasBits[deltaBit]++;

                    if (deltaBit > BigDeltaBits)
                        BigDeltaBits = deltaBit;
                }
                else if (Count == 1)
                {
                    if (value > oldValue)
                    {
                        OneDeltaValue = delta = (ulong)(value - oldValue);
                        oneDeltaSign = 1;
                        UpCount++;
                    }
                    else if (value < oldValue)
                    {
                        OneDeltaValue = delta = (ulong)(oldValue - value);
                        oneDeltaSign = -1;
                        DownCount++;
                    }
                    else
                    {
                        OneDeltaValue = delta = 0;
                        oneDeltaSign = 0;
                        EqualsCount++;
                    }

                    BigDeltaBits = BitUtils.GetBitBounds(delta);
                    deltasBits[BigDeltaBits]++;
                }

                oldValue = value;
                Count++;
            }

            public int SmallDeltaBits
            {
                get
                {
                    //looking for optimal definition of small delta
                    int res = BigDeltaBits;
                    long sum = 0, minSum = (Count - 1) * BigDeltaBits;
                    for (int i = 1; i < BigDeltaBits; i++)
                    {
                        sum += deltasBits[i];
                        long currentSum = sum * i + (Count - 1 - sum) * BigDeltaBits + Count - 1;
                        if (currentSum < minSum)
                        {
                            res = i;
                            minSum = currentSum;
                        }
                    }
                    return res;
                }
            }
        }
    }
}
