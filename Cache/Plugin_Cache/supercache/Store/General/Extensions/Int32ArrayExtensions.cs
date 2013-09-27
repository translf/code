using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.General.Extensions
{
    public static class Int32ArrayExtensions
    {
        public static int GetBit(this int[] map, int bitIndex)
        {
            return (map[bitIndex >> 5] >> (bitIndex & 31)) & 1;
        }

        public static void SetBit(this int[] map, int bitIndex, int value)
        {
            int bitMask = 1 << (bitIndex & 31);
            if (value != 0)
                map[bitIndex >> 5] |= bitMask;
            else
                map[bitIndex >> 5] &= ~bitMask;
        }
    }
}
