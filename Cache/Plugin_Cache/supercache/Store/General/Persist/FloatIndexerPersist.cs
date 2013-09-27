using System;
using System.Collections.Generic;
using System.IO;
using STSdb4.General.Compression;
using STSdb4.General.Mathematics;

namespace STSdb4.General.Persist
{
    public class SingleIndexerPersist : IIndexerPersist<Single>
    {
        private int GetMaxDigits(Func<int, float> values, int count)
        {
            int maxDigits = 0;
            for (int i = 0; i < count; i++)
            {
                float value = values(i);
                int digits = MathUtils.GetDigits(value);
                if (digits < 0)
                    return -1;

                if (digits > maxDigits)
                    maxDigits = digits;
            }
            return maxDigits;
        }

        public void Store(BinaryWriter writer, Func<int, float> values, int count)
        {
            DeltaCompression.Helper helper = null;
            List<long> rawValues = null;
            int maxDigits;

            try
            {
                maxDigits = GetMaxDigits(values, count);
                if (maxDigits >= 0)
                {
                    helper = new DeltaCompression.Helper();
                    rawValues = new List<long>(count);

                    double koef = Math.Pow(10, maxDigits);
                    for (int i = 0; i < count; i++)
                    {
                        float value = values(i);
                        long v = checked((long)Math.Round(value * koef));
                        helper.AddValue(v);
                        rawValues.Add(v);
                    }
                }
            }
            catch (OverflowException)
            {
                maxDigits = -1;
            }

            writer.Write((sbyte)maxDigits);
            if (maxDigits >= 0)
                DeltaCompression.CoreCompress(writer, rawValues, helper);
            else
            {
                for (int i = 0; i < count; i++)
                    writer.Write(values(i));
            }
        }

        public void Load(BinaryReader reader, Action<int, float> values, int count)
        {
            int digits = reader.ReadSByte();
            if (digits >= 0)
            {
                double koef = Math.Pow(10, digits);
                List<long> rawValues = (List<long>)DeltaCompression.CoreDecompress(reader);
                for (int i = 0; i < count; i++)
                    values(i, (float)Math.Round(rawValues[i] / koef, digits));
            }
            else //native read
            {
                for (int i = 0; i < count; i++)
                    values(i, reader.ReadSingle());
            }
        }
    }

    public class DoubleIndexerPersist : IIndexerPersist<Double>
    {
        private int GetMaxDigits(Func<int, double> values, int count)
        {
            int maxDigits = 0;
            for (int i = 0; i < count; i++)
            {
                double value = values(i);
                int digits = MathUtils.GetDigits(value);
                if (digits < 0)
                    return -1;

                if (digits > maxDigits)
                    maxDigits = digits;
            }
            return maxDigits;
        }

        public void Store(BinaryWriter writer, Func<int, double> values, int count)
        {
            DeltaCompression.Helper helper = null;
            List<long> rawValues = null;
            int maxDigits;

            try
            {
                maxDigits = GetMaxDigits(values, count);
                if (maxDigits >= 0)
                {
                    helper = new DeltaCompression.Helper();
                    rawValues = new List<long>(count);

                    double koef = Math.Pow(10, maxDigits);
                    for (int i = 0; i < count; i++)
                    {
                        double value = values(i);
                        long v = checked((long)Math.Round(value * koef));
                        helper.AddValue(v);
                        rawValues.Add(v);
                    }
                }
            }
            catch (OverflowException)
            {
                maxDigits = -1;
            }

            writer.Write((sbyte)maxDigits);
            if (maxDigits >= 0)
                DeltaCompression.CoreCompress(writer, rawValues, helper);
            else
            {
                for (int i = 0; i < count; i++)
                    writer.Write(values(i));
            }
        }

        public void Load(BinaryReader reader, Action<int, double> values, int count)
        {
            int digits = reader.ReadSByte();
            if (digits >= 0)
            {
                double koef = Math.Pow(10, digits);
                List<long> rawValues = (List<long>)DeltaCompression.CoreDecompress(reader);
                for (int i = 0; i < count; i++)
                    values(i, (double)Math.Round(rawValues[i] / koef, digits));
            }
            else //native read
            {
                for (int i = 0; i < count; i++)
                    values(i, reader.ReadDouble());
            }
        }
    }

    public class DecimalIndexerPersist : IIndexerPersist<Decimal>
    {
        private int GetMaxDigits(Func<int, decimal> values, int count)
        {
            int maxDigits = 0;
            for (int i = 0; i < count; i++)
            {
                decimal value = values(i);
                int digits = MathUtils.GetDigits(value);
                if (digits > maxDigits)
                    maxDigits = digits;
            }
            return maxDigits;
        }

        #region IIndexerPersist<decimal> Members

        public void Store(BinaryWriter writer, Func<int, decimal> values, int count)
        {
            DeltaCompression.Helper helper = null;
            List<long> rawValues = null;
            int maxDigits;

            try
            {
                maxDigits = GetMaxDigits(values, count);
                if (maxDigits <= 15)
                {
                    helper = new DeltaCompression.Helper();
                    rawValues = new List<long>(count);

                    decimal koef = (decimal)Math.Pow(10, maxDigits);
                    for (int i = 0; i < count; i++)
                    {
                        decimal value = values(i);
                        long v = checked((long)Math.Round(value * koef));
                        helper.AddValue(v);
                        rawValues.Add(v);
                    }
                }
                else
                    maxDigits = -1;
            }
            catch (OverflowException)
            {
                maxDigits = -1;
            }

            writer.Write((sbyte)maxDigits);
            if (maxDigits >= 0)
                DeltaCompression.CoreCompress(writer, rawValues, helper);
            else
            {
                for (int i = 0; i < count; i++)
                    writer.Write(values(i));
            }
        }

        public void Load(BinaryReader reader, Action<int, decimal> values, int count)
        {
            int digits = reader.ReadSByte();
            if (digits >= 0)
            {
                double koef = Math.Pow(10, digits);
                List<long> rawValues = (List<long>)DeltaCompression.CoreDecompress(reader);
                for (int i = 0; i < count; i++)
                    values(i, (decimal)Math.Round(rawValues[i] / koef, digits));
            }
            else //native read
            {
                for (int i = 0; i < count; i++)
                    values(i, reader.ReadDecimal());
            }
        }

        #endregion
    }
}
