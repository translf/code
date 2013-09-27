using STSdb4.General.Comparers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace STSdb4.Data
{
    public class DataComparer : IComparer<IData>
    {
        private Func<IData, IData, int> compare;

        public DataType DataType { get; private set; }
        public CompareOption[] CompareOptions { get; private set; }

        public Expression<Func<IData, IData, int>> LambdaCompare { get; private set; }

        public DataComparer(DataType dataType, CompareOption[] compareOptions)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            dataType.CheckCompareOptions(compareOptions);

            DataType = dataType;
            CompareOptions = compareOptions;

            //prepare compare
            LambdaCompare = CreateCompareMethod();
            compare = LambdaCompare.Compile();
        }

        public DataComparer(DataType dataType)
            : this(dataType, dataType.GetDefaultCompareOptions())
        {
        }

        private Expression<Func<IData, IData, int>> CreateCompareMethod()
        {
            var x = Expression.Parameter(typeof(IData), "x");
            var y = Expression.Parameter(typeof(IData), "y");

            var idataType = DataTypeUtils.GetDataType(DataType);

            var data1 = Expression.Variable(idataType, "data1");
            var data2 = Expression.Variable(idataType, "data2");
            var cmp = Expression.Variable(typeof(int), "cmp");

            List<Expression> list = new List<Expression>();

            list.Add(Expression.Assign(data1, Expression.Convert(x, idataType)));
            list.Add(Expression.Assign(data2, Expression.Convert(y, idataType)));

            var exitPoint = Expression.Label(typeof(int));

            if (DataType.IsPrimitive)
            {
                foreach (var command in GetCompareCommands(data1, data2, cmp, exitPoint, DataType, 0, CompareOptions[0], true))
                    list.Add(command);
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                {
                    foreach (var command in GetCompareCommands(data1, data2, cmp, exitPoint, DataType[i], i, CompareOptions[i], i == DataType.TypesCount - 1))
                        list.Add(command);
                }
            }

            list.Add(Expression.Label(exitPoint, Expression.Constant(0)));

            var body = Expression.Block(typeof(int), (new ParameterExpression[] { data1, data2, cmp }), list);
            var lambda = Expression.Lambda<Func<IData, IData, int>>(body, x, y);

            return lambda;
        }

        public int Compare(IData x, IData y)
        {
            return compare(x, y);
        }

        private static IEnumerable<Expression> GetCompareCommands(ParameterExpression data1, ParameterExpression data2, ParameterExpression cmp, LabelTarget exitPoint, DataType slotType, int slotIndex, CompareOption compareOption, bool isLastCompare)
        {
            var field1 = Expression.Field(data1, String.Format("Slot{0}", slotIndex));
            var field2 = Expression.Field(data2, String.Format("Slot{0}", slotIndex));

            var invertCompare = compareOption.SortOrder == SortOrder.Descending;

            if (slotType == DataType.Boolean)
            {
                //if (field1 != field2)
                //{
                //    if (!field1)
                //        return -1;
                //    else
                //        return 1;
                //}

                int less = !invertCompare ? -1 : 1;
                int greater = !invertCompare ? 1 : -1;

                yield return Expression.IfThen(Expression.NotEqual(field1, field2),
                                Expression.IfThenElse(Expression.Not(field1),
                                    Expression.Return(exitPoint, Expression.Constant(less)),
                                    Expression.Return(exitPoint, Expression.Constant(greater))));
            }
            else if (slotType == DataType.ByteArray)
            {
                Debug.Assert(compareOption.ByteOrder != ByteOrder.Unspecified);

                var order = compareOption.ByteOrder;
                var comparerType = (order == ByteOrder.BigEndian) ? typeof(BigEndianByteArrayComparer) : typeof(LittleEndianByteArrayComparer);
                var instance = Expression.Field(null, comparerType, "Instance");
                var compare = comparerType.GetMethod("Compare", new Type[] { typeof(byte[]), typeof(byte[]) });
                var call = !invertCompare ? Expression.Call(instance, compare, field1, field2) : Expression.Call(instance, compare, field2, field1);

                if (!isLastCompare)
                {
                    //cmp = BigEndianByteArrayComparer.Instance.Compare(field1, field2);
                    //if (cmp != 0)
                    //    return cmp;

                    yield return Expression.Assign(cmp, call);
                    yield return Expression.IfThen(Expression.NotEqual(cmp, Expression.Constant(0)),
                                    Expression.Return(exitPoint, cmp));
                }
                else
                {
                    //return BigEndianByteArrayComparer.Instance.Compare(field1, field2); 

                    yield return Expression.Return(exitPoint, call);
                }
            }
            else if (slotType == DataType.Char)
            {
                var int1 = Expression.Convert(field1, typeof(int));
                var int2 = Expression.Convert(field2, typeof(int));

                var substract = !invertCompare ? Expression.Subtract(int1, int2) : Expression.Subtract(int2, int1);

                if (!isLastCompare)
                {
                    //cmp = (int)field1 - (int)field2;
                    //if (cmp != 0)
                    //    return cmp;

                    yield return Expression.Assign(cmp, substract);
                    yield return Expression.IfThen(Expression.NotEqual(cmp, Expression.Constant(0)),
                                    Expression.Return(exitPoint, cmp));
                }
                else
                {
                    //return field1 - field2;

                    yield return Expression.Return(exitPoint, substract);
                }
            }
            else if (slotType == DataType.DateTime)
            {
                //long ticks1 = field1.Ticks;
                //long ticks2 = field2.Ticks;
                //if (ticks1 < ticks2)
                //    return -1;
                //else if (ticks1 > ticks2)
                //    return 1;

                var ticks1 = Expression.Variable(typeof(long));
                var ticks2 = Expression.Variable(typeof(long));

                var assign1 = Expression.Assign(ticks1, Expression.Property(field1, "Ticks"));
                var assign2 = Expression.Assign(ticks2, Expression.Property(field2, "Ticks"));

                int less = !invertCompare ? -1 : 1;
                int greater = !invertCompare ? 1 : -1;

                var _if = Expression.IfThenElse(Expression.LessThan(ticks1, ticks2),
                                Expression.Return(exitPoint, Expression.Constant(less)),
                                Expression.IfThen(Expression.GreaterThan(ticks1, ticks2),
                                    Expression.Return(exitPoint, Expression.Constant(greater))));

                yield return Expression.Block(new ParameterExpression[] { ticks1, ticks2 }, assign1, assign2, _if);
            }
            else if (slotType == DataType.Decimal)
            {
                var type = typeof(Comparer<>).MakeGenericType(typeof(decimal));
                var _default = Expression.Property(null, type, "Default");
                var compare = type.GetProperty("Default").PropertyType.GetMethod("Compare", new Type[] { typeof(decimal), typeof(decimal) });
                var call = !invertCompare ? Expression.Call(_default, compare, field1, field2) : Expression.Call(_default, compare, field2, field1);

                if (!isLastCompare)
                {
                    //cmp = Comparer<T>.Default.Compare(field1, field2);
                    //if (cmp != 0)
                    //    return cmp;

                    yield return Expression.Assign(cmp, call);
                    yield return Expression.IfThen(Expression.NotEqual(cmp, Expression.Constant(0)),
                                    Expression.Return(exitPoint, cmp));
                }
                else
                {
                    //return Comparer<T>.Default.Compare(field1, field2);

                    yield return Expression.Return(exitPoint, call);
                }
            }
            else if (slotType == DataType.String)
            {
                var type = typeof(string);
                var compare = type.GetMethod("Compare", new Type[] { typeof(string), typeof(string), typeof(bool) });
                bool optionIgnoreCase = compareOption.IgnoreCase;

                var ignoreCase = optionIgnoreCase ? Expression.Constant(optionIgnoreCase) : Expression.Constant(false);
                var call = !invertCompare ? Expression.Call(compare, field1, field2, ignoreCase) : Expression.Call(compare, field2, field1, ignoreCase);

                if (!isLastCompare)
                {
                    //cmp = String.Compare(field1, field2, ignoreCase);
                    //if (cmp != 0)
                    //    return cmp;

                    yield return Expression.Assign(cmp, call);
                    yield return Expression.IfThen(Expression.NotEqual(cmp, Expression.Constant(0)),
                                    Expression.Return(exitPoint, cmp));
                }
                else
                {
                    //return String.Compare(field1, field2, ignoreCase);

                    yield return Expression.Return(exitPoint, call);
                }
            }
            else if (slotType == DataType.SByte ||
                     slotType == DataType.Byte ||
                     slotType == DataType.Int16 ||
                     slotType == DataType.Int32 ||
                     slotType == DataType.UInt32 ||
                     slotType == DataType.UInt16 ||
                     slotType == DataType.Int64 ||
                     slotType == DataType.UInt64 ||
                     slotType == DataType.Single ||
                     slotType == DataType.Double)
            {
                //if (field1 < field2)
                //    return -1;
                //else if (field1 > field2)
                //    return 1;

                int less = !invertCompare ? -1 : 1;
                int greater = !invertCompare ? 1 : -1;

                yield return Expression.IfThenElse(Expression.LessThan(field1, field2),
                                Expression.Return(exitPoint, Expression.Constant(less)),
                                Expression.IfThen(Expression.GreaterThan(field1, field2),
                                    Expression.Return(exitPoint, Expression.Constant(greater))));
            }
            else
                throw new NotSupportedException(slotType.ToString());
        }
    }
}
