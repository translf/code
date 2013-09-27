using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace STSdb4.General.Compression
{
    public static class CountCompression
    {
        /// <summary>
        /// Compress value of count by CountCompression, and stores result in BinaryWriter
        /// </summary>
        /// <param name="count">Value for compression.</param>
        public static void Serialize(BinaryWriter writer, ulong number)
        {
            byte[] buffer = new byte[10];
            int index = 0;

            while (number >= 0x80)
            {
                buffer[index] = (byte)(number | 0x80);
                number = number >> 7;
                index++;
            }

            buffer[index] = (byte)number;
            index++;

            writer.Write(buffer, 0, index);
        }

        /// <summary>
        /// Decompress a value compressed with CountCompression by successively reading bytes from BinaryReader.
        /// </summary>       
        public static ulong Deserialize(BinaryReader reader)
        {
            ulong value = 0;
            int shift = 0;
            byte @byte;

            do
            {
                @byte = reader.ReadByte();
                var temp = (ulong)(@byte & 0x7F);
                temp <<= shift;
                value |= temp;
                shift += 7;
            } while (@byte > 0x7F);

            return value;
        }
    }
}
