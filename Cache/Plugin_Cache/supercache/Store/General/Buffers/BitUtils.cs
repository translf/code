using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace STSdb4.General.Buffers
{
    public static class BitUtils
    {
        private const uint M5 = 0x55555555, M3 = 0x33333333, M0F = 0xF0F0F0F, MFF = 0xFF00FF;
        private const uint M033333 = 0xDB6DB6DB, M011111 = 0x49249249, M030707 = 0xC71C71C7;
        private static byte[] bits_in_16bits;

        static BitUtils()
        {
            bits_in_16bits = new byte[1 << 16];
            for (int i = 0; i < bits_in_16bits.Length; i++)
                bits_in_16bits[i] = (byte)GetBitCountParallel(i);
        }

        public static int GetBitCountParallel(int a)
        {
            a = (int)(a & M5) + (int)((a >> 1) & M5);
            a = (int)(a & M3) + (int)((a >> 2) & M3);
            a = (int)(a & M0F) + (int)((a >> 4) & M0F);
            a = (int)(a & MFF) + (int)((a >> 8) & MFF);
            return (int)(a & UInt16.MaxValue) + (int)((a >> 16) & UInt16.MaxValue);
        }

        public static int GetBitCountParallel(uint a)
        {
            a = (a & M5) + ((a >> 1) & M5);
            a = (a & M3) + ((a >> 2) & M3);
            a = (a & M0F) + ((a >> 4) & M0F);
            a = (a & MFF) + ((a >> 8) & MFF);
            return (int)((a & UInt16.MaxValue) + ((a >> 16) & UInt16.MaxValue));
        }

        public static int GetBitCount(int a)
        {
            return bits_in_16bits[a & UInt16.MaxValue] + bits_in_16bits[(a >> 16) & UInt16.MaxValue];
        }

        public static int GetBitCount(uint a)
        {
            return bits_in_16bits[a & UInt16.MaxValue] + bits_in_16bits[(a >> 16) & UInt16.MaxValue];
        }

        public static long ComposeLong(int low, int high)
        {
            return (long)((((ulong)((uint)high)) << 32) | (uint)low);
        }

        public static void DecomposeLong(long value, out int low, out int high)
        {
            ulong uval = (ulong)value;
            low = (int)(uval & UInt32.MaxValue);
            high = (int)((uval >> 32) & UInt32.MaxValue);
        }

        public static int GetBitBounds(ulong value)
        {
            if (value > uint.MaxValue)
                return (value > 0) ? (int)Math.Ceiling(Math.Log(value + 1.0, 2)) : 1;
            else if (value > 0)
            {
                int bits;
                for (bits = 0; value > 0; value >>= 1, ++bits) ;
                return bits;
            }
            else
                return 1;
        }

        public static int GetBit(byte map, int bitIndex)
        {
            return (map >> (bitIndex & 7)) & 1;
        }

        public static byte SetBit(byte map, int bitIndex, int value)
        {
            int bitMask = 1 << (bitIndex & 7);
            if (value != 0)
                return map |= (byte)bitMask;
            else
                return map &= (byte)(~bitMask);
        }

        public static int GetBitCount(this int[] map, int fromBitIndex, int bitCount, int value)
        {
            if (bitCount <= 0)
                throw new ArgumentException("bitCount");

            int mapIndex = fromBitIndex >> 5;
            int bitIndex = fromBitIndex & 31;
            int data = map[mapIndex] >> bitIndex;
            if (fromBitIndex + bitCount > (map.Length << 5))
            {
                bitCount = (map.Length << 5) - fromBitIndex;
                if (bitCount <= 0)
                    return 0;
            }
            int count = bitCount;
            int res = 0, bitMask;

            if (bitIndex > 0)
            {
                if (bitIndex + bitCount < 32)
                {
                    bitMask = (1 << bitCount) - 1;
                    data &= bitMask;
                    bitCount = 0;
                }
                else
                    bitCount -= 32 - bitIndex;

                res += GetBitCount(data);
                mapIndex++;
            }

            while (bitCount >= 32)
            {
                res += GetBitCount(map[mapIndex]);
                mapIndex++;
                bitCount -= 32;
            }

            if (bitCount > 0)
            {
                bitMask = (1 << bitCount) - 1;
                res += GetBitCount(map[mapIndex] & bitMask);
            }

            if (value != 0)
                return res;

            return count - res;
        }

        public static int GetBitCount(this byte[] map, int fromBitIndex, int bitCount, int value)
        {
            if (bitCount <= 0)
                throw new ArgumentException("bitCount");

            int mapIndex = fromBitIndex >> 3;
            int bitIndex = fromBitIndex & 7;
            int data = map[mapIndex] >> bitIndex;
            if (fromBitIndex + bitCount > (map.Length << 3))
            {
                bitCount = (map.Length << 3) - fromBitIndex;
                if (bitCount <= 0)
                    return 0;
            }
            int count = bitCount;
            int res = 0, bitMask;

            if (bitIndex > 0)
            {
                if (bitIndex + bitCount < 8)
                {
                    bitMask = (1 << bitCount) - 1;
                    data &= bitMask;
                    bitCount = 0;
                }
                else
                    bitCount -= 8 - bitIndex;

                res += GetBitCount(data);
                mapIndex++;
            }

            while (bitCount >= 8)
            {
                res += GetBitCount(map[mapIndex]);
                mapIndex++;
                bitCount -= 8;
            }

            if (bitCount > 0)
            {
                bitMask = (1 << bitCount) - 1;
                res += GetBitCount(map[mapIndex] & bitMask);
            }

            if (value != 0)
                return res;

            return count - res;
        }

        public static void FillBits(this int[] map, int fromBitIndex, int bitCount, int value)
        {
            if (bitCount <= 0)
                throw new ArgumentException("bitCount");

            if ((long)fromBitIndex + bitCount - 1 > int.MaxValue)
                throw new ArgumentException("fromBitIndex + bitCount - 1 > int.MaxValue");

            int mapIndex = fromBitIndex >> 5;
            int bitIndex = fromBitIndex & 31;
            if (fromBitIndex + bitCount > (map.Length << 5))
            {
                bitCount = (map.Length << 5) - fromBitIndex;
                if (bitCount <= 0)
                    return;
            }

            if (bitIndex > 0)
            {
                int bitMask = (1 << bitIndex) - 1;

                if (bitIndex + bitCount < 32)
                {
                    int mask2 = (-1) << (bitIndex + bitCount);
                    bitMask |= mask2;
                    bitCount = 0;
                }
                else
                    bitCount -= 32 - bitIndex;

                if (value != 0)
                    map[mapIndex] |= ~bitMask;
                else
                    map[mapIndex] &= bitMask;

                mapIndex++;
                bitIndex = 0;
            }

            int v = value != 0 ? -1 : 0;

            while (bitCount >= 32)
            {
                map[mapIndex] = v;
                mapIndex++;
                bitCount -= 32;
            }

            if (bitCount > 0)
            {
                int bitMask = (1 << bitCount) - 1;

                if (value != 0)
                    map[mapIndex] |= bitMask;
                else
                    map[mapIndex] &= ~bitMask;
            }
        }

        public static int FindFirstBit(this byte[] map, int fromBitIndex, int bitCount, int value)
        {
            if (bitCount <= 0)
                throw new ArgumentException("bitCount");

            if ((long)fromBitIndex + bitCount - 1 > int.MaxValue)
                throw new ArgumentException("fromBitIndex + bitCount - 1 > int.MaxValue");

            int mapIndex = fromBitIndex >> 3;
            int bitIndex = fromBitIndex & 7;
            int data = map[mapIndex] >> bitIndex;
            if (value == 0)
                data = ~data;
            if (fromBitIndex + bitCount > (map.Length << 3))
                bitCount = (map.Length << 3) - fromBitIndex;

            while (data == 0)
            {
                bitCount -= 8 - bitIndex;
                mapIndex++;
                if (bitCount <= 0)
                    return -1;

                bitIndex = 0;
                data = map[mapIndex];
                if (value == 0)
                    data = ~data;
            }

            while ((data & 1) == 0)
            {
                if (--bitCount <= 0)
                    return -1;

                bitIndex++;
                data >>= 1;
            }

            return (mapIndex << 3) + bitIndex;
        }

        public static int FindFirstBit(this int[] map, int fromBitIndex, int bitCount, int value)
        {
            if (bitCount <= 0)
                throw new ArgumentException("bitCount");

            if ((long)fromBitIndex + bitCount - 1 > int.MaxValue)
                throw new ArgumentException("fromBitIndex + bitCount - 1 > int.MaxValue");

            int mapIndex = fromBitIndex >> 5;
            int bitIndex = fromBitIndex & 31;
            int data = map[mapIndex] >> bitIndex;
            if (value == 0)
                data = ~data;
            if (fromBitIndex + bitCount > (map.Length << 5))
                bitCount = (map.Length << 5) - fromBitIndex;

            while (data == 0)
            {
                bitCount -= 32 - bitIndex;
                mapIndex++;
                if (bitCount <= 0)
                    return -1;

                bitIndex = 0;
                data = map[mapIndex];
                if (value == 0)
                    data = ~data;
            }

            while ((data & 1) == 0)
            {
                if (--bitCount <= 0)
                    return -1;

                bitIndex++;
                data >>= 1;
            }

            return (mapIndex << 5) + bitIndex;
        }
    }
}
