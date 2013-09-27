using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using STSdb4.General.Collections;
using STSdb4.General.Extensions;
using System.Data.SqlClient;
using System.Reflection;
using STSdb4.General.Comparers;
using System.Diagnostics;

namespace STSdb4.Data
{
    public class DataEqualityComparer : IEqualityComparer<IData>
    {
        private Func<IData, IData, bool> equals;
        private Func<IData, int> getHashCode;

        public DataType DataType { get; private set; }
        public CompareOption[] CompareOptions { get; private set; }

        public Expression<Func<IData, IData, bool>> LambdaEquals { get; private set; }
        public Expression<Func<IData, int>> LambdaGetHashCode { get; private set; }

        public DataEqualityComparer(DataType dataType, CompareOption[] compareOptions)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            dataType.CheckCompareOptions(compareOptions);

            DataType = dataType;
            CompareOptions = compareOptions;

            //prepare equals
            LambdaEquals = CreateEqualsMethod();
            equals = LambdaEquals.Compile();

            //prepare getHashCode
            LambdaGetHashCode = CreateGetHashCodeMethod();
            getHashCode = LambdaGetHashCode.Compile();
        }

        public DataEqualityComparer(DataType dataType)
            : this(dataType, dataType.GetDefaultCompareOptions())
        {
        }

        public bool Equals(IData x, IData y)
        {
            return equals(x, y);
        }

        public int GetHashCode(IData obj)
        {
            return getHashCode(obj);
        }

        private Expression<Func<IData, IData, bool>> CreateEqualsMethod()
        {
            var x = Expression.Parameter(typeof(IData), "x");
            var y = Expression.Parameter(typeof(IData), "y");

            var idataType = DataTypeUtils.GetDataType(DataType);

            var data1 = Expression.Variable(idataType, "data1");
            var data2 = Expression.Variable(idataType, "data2");
            var equ = Expression.Variable(typeof(bool), "equ");

            List<Expression> list = new List<Expression>();

            list.Add(Expression.Assign(data1, Expression.Convert(x, idataType)));
            list.Add(Expression.Assign(data2, Expression.Convert(y, idataType)));

            var exitPoint = Expression.Label(typeof(bool));

            if (DataType.IsPrimitive)
            {
                foreach (var command in GetEqualsCommands(data1, data2, equ, exitPoint, DataType, 0, CompareOptions[0], true))
                    list.Add(command);
            }
            else
            {
                for (int i = DataType.TypesCount - 1; i >= 0; i--)
                {
                    foreach (var command in GetEqualsCommands(data1, data2, equ, exitPoint, DataType[i], i, CompareOptions[i], i == 0))
                        list.Add(command);
                }
            }

            list.Add(Expression.Label(exitPoint, Expression.Constant(true)));

            var body = Expression.Block(typeof(bool), (new ParameterExpression[] { data1, data2, equ }), list);
            var lambda = Expression.Lambda<Func<IData, IData, bool>>(body, x, y);

            return lambda;
        }

        private Expression<Func<IData, int>> CreateGetHashCodeMethod()
        {
            var obj = Expression.Parameter(typeof(IData), "obj");

            var idataType = DataTypeUtils.GetDataType(DataType);

            var x = Expression.Variable(idataType, "x");
            var assign1 = Expression.Assign(x, Expression.Convert(obj, idataType));

            Expression[] values = new Expression[DataType.IsPrimitive ? 1 : DataType.TypesCount];

            if (DataType.IsPrimitive)
                values[0] = GetHashCodeCommand(x, DataType, 0);
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                    values[i] = GetHashCodeCommand(x, DataType[i], i);
            }

            var result = Expression.Variable(typeof(int), "result");

            var xor = values[0];

            if (DataType.IsSlotes)
            {
                for (int i = 1; i < DataType.TypesCount; i++)
                    xor = Expression.ExclusiveOr(xor, values[i]);
            }

            var assign2 = Expression.Assign(result, xor);

            List<Expression> list = new List<Expression>();

            var exitPoint = Expression.Label(typeof(int));
            list.Add(assign1);
            list.Add(assign2);
            list.Add(Expression.Label(exitPoint, result));

            var body = Expression.Block(typeof(int), new ParameterExpression[] { x, result }, list);

            var lambda = Expression.Lambda<Func<IData, int>>(body, obj);

            //public int GetHashCode(IData obj)
            //{
            //    var x = (Data<byte[], string, double>)obj;
            //    return BigEndianByteArrayEqualityComparer.Instance.GetHashCode(x.Slot0) ^ x.Slot1.GetHashCode() ^ x.Slot2.GetHashCode();
            //}

            return lambda;
        }

        private static Expression GetHashCodeCommand(ParameterExpression data, DataType slotType, int slotIndex)
        {
            var value = Expression.Field(data, String.Format("Slot{0}", slotIndex));
            if (slotType == DataType.ByteArray)
            {
                //+10% speed on direct invoke ByteArrayExtensions.GetHashCodeEx(value), instead via BigEndianByteArrayEqualityComparer or LittleEndianByteArrayEqualityComparer
                var method = typeof(ByteArrayExtensions).GetMethod("GetHashCodeEx", new Type[] { typeof(byte[]) });
                return Expression.Call(method, value);
            }
            else
            {
                var method = slotType.PrimitiveType.GetMethod("GetHashCode");
                return Expression.Call(value, method);
            }
        }

        private static IEnumerable<Expression> GetEqualsCommands(ParameterExpression data1, ParameterExpression data2, ParameterExpression equ, LabelTarget exitPoint, DataType slotType, int slotIndex, CompareOption compareOption, bool isLastEqual)
        {
            var field1 = Expression.Field(data1, String.Format("Slot{0}", slotIndex));
            var field2 = Expression.Field(data2, String.Format("Slot{0}", slotIndex));

            if (slotType == DataType.ByteArray)
            {
                Debug.Assert(compareOption.ByteOrder != ByteOrder.Unspecified);

                var order = compareOption.ByteOrder;
                var equalityComparerType = (order == ByteOrder.BigEndian) ? typeof(BigEndianByteArrayEqualityComparer) : typeof(LittleEndianByteArrayEqualityComparer);
                var instance = Expression.Field(null, equalityComparerType, "Instance");
                var equals = equalityComparerType.GetMethod("Equals", new Type[] { typeof(byte[]), typeof(byte[]) });
                var call = Expression.Call(instance, equals, field1, field2);

                if (!isLastEqual)
                {
                    //equ = BigEndianByteArrayEqualityComparer.Instance.Equals(field1, field2);
                    //if (equ != false)
                    //    return equ;

                    yield return Expression.Assign(equ, call);
                    yield return Expression.IfThen(Expression.NotEqual(equ, Expression.Constant(false)),
                                    Expression.Return(exitPoint, equ));
                }
                else
                {
                    // return BigEndianByteArrayEqualityComparer.Instance.Equals(field1, field2);

                    yield return Expression.Return(exitPoint, call);
                }
            }
            else if (slotType == DataType.Char)
            {
                if (!isLastEqual)
                {
                    //if (field1 != field2)
                    //    return false;

                    yield return Expression.IfThen(Expression.NotEqual(field1, field2),
                        Expression.Return(exitPoint, Expression.Constant(false)));
                }
                else
                {
                    //return field1 == field2;

                    yield return Expression.Return(exitPoint, Expression.Equal(field1, field2));
                }
            }
            else if (slotType == DataType.String)
            {
                bool optionIgnoreCase = compareOption.IgnoreCase;
                var type = typeof(String);

                if (!optionIgnoreCase)
                {
                    var equals = type.GetMethod("Equals", new Type[] { typeof(string), typeof(string) });

                    if (!isLastEqual)
                    {
                        //if (!String.Equals(field1, field2))
                        //     return false;

                        yield return Expression.IfThen(Expression.Not(Expression.Call(equals, field1, field2)),
                                        Expression.Return(exitPoint, Expression.Constant(false)));
                    }
                    else
                    {
                        //return String.Equals(field1, field2);

                        yield return Expression.Return(exitPoint, Expression.Call(equals, field1, field2));
                    }
                }
                else
                {
                    var compare = type.GetMethod("Compare", new Type[] { typeof(string), typeof(string), typeof(bool) });

                    if (!isLastEqual)
                    {
                        //equ = String.Compare(field1, field2, ignoreCase) == 0
                        //if (!equ)
                        //    return false;

                        yield return Expression.Assign(equ, Expression.Equal(Expression.Call(compare, field1, field2, Expression.Constant(optionIgnoreCase)), Expression.Constant(0)));
                        yield return Expression.IfThen(Expression.Not(equ),
                                        Expression.Return(exitPoint, Expression.Constant(false)));
                    }
                    else
                    {
                        //return String.Compare(field1, field2, ignoreCase) == 0;

                        yield return Expression.Return(exitPoint, Expression.Equal(Expression.Call(compare, field1, field2, Expression.Constant(optionIgnoreCase)), Expression.Constant(0)));
                    }
                }
            }
            else if (slotType == DataType.Boolean ||
                    slotType == DataType.SByte ||
                    slotType == DataType.Byte ||
                    slotType == DataType.Int16 ||
                    slotType == DataType.Int32 ||
                    slotType == DataType.UInt32 ||
                    slotType == DataType.UInt16 ||
                    slotType == DataType.Int64 ||
                    slotType == DataType.UInt64 ||
                    slotType == DataType.Single ||
                    slotType == DataType.Double ||
                    slotType == DataType.DateTime ||
                    slotType == DataType.Decimal)
            {
                if (!isLastEqual)
                {
                    //if (field1 != field2)
                    //    return false;

                    yield return Expression.IfThen(Expression.NotEqual(field1, field2),
                        Expression.Return(exitPoint, Expression.Constant(false)));
                }
                else
                {
                    //return field1 == field2

                    yield return Expression.Return(exitPoint, Expression.Equal(field1, field2));
                }
            }
            else
                throw new NotSupportedException(slotType.ToString());
        }
    }
}
