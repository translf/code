using STSdb4.General.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSdb4.Data
{
    public class DataToStringTransformer : IDataTransformer<string>
    {
        private Func<string, IData> toIData;
        private Func<IData, string> fromIData;

        private Type Type;
        public DataType DataType { get; private set; }
        public IFormatProvider[] Providers { get; private set; }
        public char[] Delimiters { get; private set; }

        public Expression<Func<string, IData>> LambdaToIData { get; private set; }
        public Expression<Func<IData, string>> LambdaFromIData { get; private set; }

        public DataToStringTransformer(DataType dataType, IFormatProvider[] providers, char[] delimiters)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            if (dataType.IsPrimitive && providers.Length != 1)
                throw new ArgumentException("providers");
            if (dataType.IsSlotes && providers.Length != dataType.TypesCount)
                throw new ArgumentException("providers");
            
            DataType = dataType;
            Providers = providers;
            Delimiters = delimiters;

            Type = DataTypeUtils.GetDataType(dataType);

            //prepare toIData
            LambdaToIData = CreateToIDataMethod();
            toIData = LambdaToIData.Compile();

            //prepare fromIData
            LambdaFromIData = CreateFromIDataMethod();
            fromIData = LambdaFromIData.Compile();
        }

        public DataToStringTransformer(DataType dataType, char[] delimiters)
            : this(dataType, GetDefaultProviders(dataType), delimiters)
        {
        }

        public DataToStringTransformer(DataType dataType)
            : this(dataType, new char[] { ';' })
        {
        }

        public static IFormatProvider GetDefaultProvider(DataType type)
        {
            if (!type.IsPrimitive)
                throw new NotSupportedException(type.ToString());
            
            if (type == DataType.Single ||
                type == DataType.Double ||
                type == DataType.Decimal)
            {
                NumberFormatInfo numberFormat = new NumberFormatInfo();
                numberFormat.CurrencyDecimalSeparator = ".";

                return numberFormat;
            }
            else if (type == DataType.DateTime)
            {
                DateTimeFormatInfo dateTimeFormat = new DateTimeFormatInfo();
                dateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
                dateTimeFormat.ShortTimePattern = "HH:mm:ss.fff";
                dateTimeFormat.LongDatePattern = dateTimeFormat.ShortDatePattern;
                dateTimeFormat.LongTimePattern = dateTimeFormat.ShortTimePattern;

                return dateTimeFormat;
            }
            else
                return null;
        }

        public static IFormatProvider[] GetDefaultProviders(DataType type)
        {
            if (type.IsPrimitive)
                return new IFormatProvider[] { GetDefaultProvider(type) };

            if (type.IsSlotes && type.AreAllTypesPrimitive)
                return type.Select(x => GetDefaultProvider(x)).ToArray();

            throw new NotSupportedException(type.ToString());
        }

        private Expression<Func<IData, string>> CreateFromIDataMethod()
        {
            List<Expression> list = new List<Expression>();

            var data = Expression.Parameter(typeof(IData), "data");

            var d = Expression.Variable(Type, "d");
            var assignData = Expression.Assign(d, Expression.Convert(data, Type));
            list.Add(assignData);

            var stringBuilder = Expression.Variable(typeof(StringBuilder), "stringBuilder");
            var assignStringBuilder = Expression.Assign(stringBuilder, Expression.New(typeof(StringBuilder).GetConstructor(new Type[] { })));
            list.Add(assignStringBuilder);

            if (DataType.IsPrimitive)
            {
                list.Add(GetAppendCommand(d, DataType, 0, stringBuilder, null));
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                {
                    list.Add(GetAppendCommand(d, DataType[i], i, stringBuilder, Providers[i]));

                    if (i < DataType.TypesCount - 1)
                    {
                        var apendMethodDelemiter = typeof(StringBuilder).GetMethod("Append", new Type[] { typeof(char) });
                        var callAppendDelemiter = Expression.Call(stringBuilder, apendMethodDelemiter, Expression.Constant(Delimiters[0]));
                        list.Add(callAppendDelemiter);
                    }
                }
            }

            var exitPoint = Expression.Label(typeof(string));
            list.Add(Expression.Label(exitPoint, Expression.Call(stringBuilder, typeof(object).GetMethod("ToString"))));

            var body = Expression.Block(new ParameterExpression[] { d, stringBuilder }, list);
            var func = Expression.Lambda<Func<IData, string>>(body, new ParameterExpression[] { data });

            //public string FromIData(IData data)
            //{
            //    Data<string, double> d = (Data<string, double, byte[]>)data;
            //    StringBuilder stringBuilder = new StringBuilder();

            //    stringBuilder.Append(d.Slot0.ToString(Providers[0]);
            //    stringBuilder.Append(Delimiter);

            //    stringBuilder.Append(d.Slot1.ToString(Providers[1]);
            //    stringBuilder.Append(Delimiter);

            //    stringBuilder.Append(ByteArrayExtensions.ToHex(d.Slot3);

            //    return stringBuilder.ToString();
            //}

            return func;
        }

        private static Expression GetAppendCommand(ParameterExpression data, DataType slotType, int slotIndex, ParameterExpression stringBuilder, IFormatProvider provider)
        {
            var slot = Expression.Field(data, "Slot" + slotIndex);
            MethodCallExpression callToString;

            if (slotType == DataType.ByteArray)
            {
                var toHexMethod = typeof(ByteArrayExtensions).GetMethod("ToHex", new Type[] { typeof(byte[]) });
                callToString = Expression.Call(toHexMethod, slot);
            }
            else
            {
                var toStringProvider = slotType.PrimitiveType.GetMethod("ToString", new Type[] { typeof(IFormatProvider) });
                callToString = Expression.Call(slot, toStringProvider, Expression.Constant(provider, typeof(IFormatProvider)));
            }

            var apendMethod = typeof(StringBuilder).GetMethod("Append", new Type[] { typeof(String) });
            var callAppend = Expression.Call(stringBuilder, apendMethod, callToString);

            //    stringBuilder.Append(d.Slot0.ToString(Providers[0]);
            //or
            //    stringBuilder.Append(ByteArrayExtensions.ToHex(d.Slot3);

            return callAppend;
        }

        private Expression<Func<string, IData>> CreateToIDataMethod()
        {
            List<Expression> list = new List<Expression>();

            var stringParam = Expression.Parameter(typeof(string), "item");
            var stringArray = Expression.Variable(typeof(string[]), "stringArray");

            var splitMethod = typeof(string).GetMethod("Split", new Type[] { typeof(char[]) });
            var callSplit = Expression.Call(stringParam, splitMethod, new Expression[] { Expression.Constant(Delimiters) });

            var assignArray = Expression.Assign(stringArray, callSplit);
            list.Add(assignArray);

            var data = Expression.Variable(Type, "data");
            var newData = Expression.New(Type.GetConstructor(new Type[] { }));
            var assignData = Expression.Assign(data, newData);
            list.Add(assignData);

            if (DataType.IsPrimitive)
            {
                list.Add(GetParseCommand(data, DataType, 0, stringArray, Providers[0]));
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                    list.Add(GetParseCommand(data, DataType[i], i, stringArray, Providers[i]));
            }

            var exitPoint = Expression.Label(Type);
            list.Add(Expression.Label(exitPoint, data));

            var body = Expression.Block(new ParameterExpression[] { data, stringArray }, list);
            var func = Expression.Lambda<Func<string, IData>>(body, new ParameterExpression[] { stringParam });

            //public IData ToIData(string item)
            //{
            //    string[] stringArray = item.Split(Delimiters);
            //    var data = new Data<string, double, byte[]>();

            //    data.Slot0 = stringArray[0];
            //    data.Slot1 = Double.Parse(stringArray[1], Providers[1]);
            //    data.Slot2 = StringExtensions.ParseHex(stringArray[2]);

            //    return data;
            //}
                        
            return func;
        }

        private static Expression GetParseCommand(ParameterExpression data, DataType slotType, int slotIndex, ParameterExpression stringArray, IFormatProvider provider)
        {
            var slot = Expression.Field(data, "Slot" + slotIndex);
            var sValue = Expression.ArrayAccess(stringArray, Expression.Constant(slotIndex));
            Expression value;

            if (slotType == DataType.String)
            {
                value = sValue;
            }
            else if (slotType == DataType.ByteArray)
            {
                var hexParse = typeof(StringExtensions).GetMethod("ParseHex", new Type[] { typeof(string) });
                value = Expression.Call(hexParse, sValue);
            }
            else if (slotType == DataType.Char)
            {
                var parseMethod = slotType.PrimitiveType.GetMethod("Parse", new Type[] { typeof(string) });
                value = Expression.Call(parseMethod, sValue);
            }
            else
            {
                var parseMethod = slotType.PrimitiveType.GetMethod("Parse", new Type[] { typeof(string), typeof(IFormatProvider) });
                value = Expression.Call(parseMethod, sValue, Expression.Constant(provider, typeof(IFormatProvider)));
            }

            //    data.Slot1 = Double.Parse(stringArray[1], Providers[1]);
            //or
            //    data.Slot2 = StringExtensions.ParseHex(stringArray[2]);

            return Expression.Assign(slot, value);
        }

        public IData ToIData(string data)
        {
            return toIData(data);
        }

        public string FromIData(IData data)
        {
            return fromIData(data);
        }
    }
}
