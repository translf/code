using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace STSdb4.Data
{
    public class DataToObjectsTransformer : IDataTransformer<object[]>
    {
        private Func<object[], IData> toIData;
        private Func<IData, object[]> fromIData;

        private Type Type;
        public DataType DataType { get; private set; }
        public Expression<Func<object[], IData>> LambdaToIData { get; private set; }
        public Expression<Func<IData, object[]>> LambdaFromIData { get; private set; }

        public DataToObjectsTransformer(DataType dataType)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            DataType = dataType;
            Type = DataTypeUtils.GetDataType(DataType);

            //prepare toIData
            LambdaToIData = CreateToIDataMethod();
            toIData = LambdaToIData.Compile();

            //prepare fromIData
            LambdaFromIData = CreateFromIDataMethod();
            fromIData = LambdaFromIData.Compile();
        }

        private Expression<Func<object[], IData>> CreateToIDataMethod()
        {
            var values = Expression.Parameter(typeof(object[]), "item");

            Expression[] castedValues = new Expression[DataType.IsPrimitive ? 1 : DataType.TypesCount];

            if (DataType.IsPrimitive)
            {
                var value = Expression.ArrayAccess(values, Expression.Constant(0, typeof(int)));
                castedValues[0] = Expression.Convert(value, DataType.PrimitiveType);
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                {
                    var value = Expression.ArrayAccess(values, Expression.Constant(i, typeof(int)));
                    castedValues[i] = Expression.Convert(value, DataType[i].PrimitiveType);
                }
            }

            var primitiveTypes = DataType.IsPrimitive ? new Type[] { DataType.PrimitiveType } : DataType.Select(x => x.PrimitiveType).ToArray();

            var body = Expression.New(Type.GetConstructor(primitiveTypes), castedValues);
            var lambda = Expression.Lambda<Func<object[], IData>>(body, values);

            //IData toIData(object[] item)
            //{
            //    return new Data<int, string, double>((int)item[0], (string)item[1], (double)item[2]);
            //}

            return lambda;
        }

        private Expression<Func<IData, object[]>> CreateFromIDataMethod()
        {
            var data = Expression.Parameter(typeof(IData), "data");

            var d = Expression.Variable(Type, "d");
            var assign = Expression.Assign(d, Expression.Convert(data, Type));

            Expression[] values = new Expression[DataType.IsPrimitive ? 1 : DataType.TypesCount];

            if (DataType.IsPrimitive)
            {
                var value = Expression.Field(d, String.Format("Slot{0}", 0));
                values[0] = Expression.Convert(value, typeof(object));
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                {
                    var value = Expression.Field(d, String.Format("Slot{0}", i));
                    values[i] = Expression.Convert(value, typeof(object));
                }
            }

            var newArray = Expression.NewArrayInit(typeof(object), values);

            var body = Expression.Block(typeof(object[]), new ParameterExpression[] { d }, assign, newArray);
            var lambda = Expression.Lambda<Func<IData, object[]>>(body, data);

            //object[] fromIData(IData data)
            //{
            //    Data<int, string, double> d = (Data<int, string, double>)data;
            //    return  new object[] { (object)d.Slot0, (object)d.Slot1, (object)d.Slot2 };
            //}            

            return lambda;
        }

        public IData ToIData(params object[] data)
        {
            return toIData(data);
        }

        public object[] FromIData(IData data)
        {
            return fromIData(data);
        }
    }
}
