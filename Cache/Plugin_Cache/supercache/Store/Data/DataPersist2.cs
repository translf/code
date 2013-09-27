using STSdb4.General.Compression;
using STSdb4.General.Extensions;
using STSdb4.General.Persist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace STSdb4.Data
{
    //public class DataPersist2 : IPersist<IData>
    //{
    //    private Action<BinaryWriter, IData> write;
    //    private Func<BinaryReader, IData> read;

    //    private Type Type;
    //    public DataType DataType { get; private set; }

    //    public Expression<Action<BinaryWriter, IData>> LambdaWrite { get; private set; }
    //    public Expression<Func<BinaryReader, IData>> LambdaRead { get; private set; }

    //    public DataPersist2(DataType dataType)
    //    {
    //        DataType = dataType;
    //        Type = DataTypeUtils.GetDataType(dataType);

    //        DataTypeUtils.CheckDataType(DataType);

    //        LambdaWrite = CreateWriteMethod();
    //        write = LambdaWrite.Compile();

    //        LambdaRead = CreateReadMethod();
    //        read = LambdaRead.Compile();
    //    }

    //    private Expression<Action<BinaryWriter, IData>> CreateWriteMethod()
    //    {
    //        var writer = Expression.Parameter(typeof(BinaryWriter), "writer");
    //        var item = Expression.Parameter(typeof(IData), "item");

    //        var data = Expression.Variable(Type, "data");
    //        var assign = Expression.Assign(data, Expression.Convert(item, Type));

    //        var body = Expression.Block((new ParameterExpression[] { data }), assign, BuildWrite(writer, data, DataType));
    //        var lambda = Expression.Lambda<Action<BinaryWriter, IData>>(body, writer, item);

    //        return lambda;
    //    }

    //    private Expression BuildWrite(Expression writer, Expression data, DataType dataType)
    //    {
    //        if (dataType.IsPrimitive)
    //            return GetWriteCommand(writer, data, dataType);

    //        if (dataType.IsKeyValuePair)
    //        {
    //            return Expression.Block(
    //                BuildWrite(writer, Expression.PropertyOrField(data, "Key"), dataType[0]),
    //                BuildWrite(writer, Expression.PropertyOrField(data, "Value"), dataType[1])
    //                );
    //        }

    //        var isNotNull = Expression.NotEqual(data, Expression.Constant(null));

    //        if (dataType.IsArray || dataType.IsList)
    //        {
    //            return Expression.Block(
    //                Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), isNotNull),
    //                Expression.IfThen(isNotNull,
    //                Expression.Block(
    //                    Expression.Call(typeof(CountCompression).GetMethod("Serialize"), writer,
    //                        Expression.ConvertChecked(dataType.IsArray ? (Expression)Expression.ArrayLength(data) : Expression.Property(data, "Count"), typeof(ulong)
    //                    )),
    //                        data.For(i =>
    //                            BuildWrite(writer, dataType.IsArray ? Expression.ArrayAccess(data, i) : data.This(i), dataType[0]),
    //                            Expression.Label()
    //                ))));
    //        }

    //        if (dataType.IsDictionary)
    //        {
    //            var kv = Expression.Variable((typeof(KeyValuePair<,>)).MakeGenericType(DataTypeUtils.GetSlotDataType(dataType[0]), DataTypeUtils.GetSlotDataType(dataType[1])));

    //            return Expression.Block(
    //                Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), isNotNull),
    //                Expression.IfThen(isNotNull,
    //                Expression.Block(
    //                    Expression.Call(typeof(CountCompression).GetMethod("Serialize"), writer, Expression.ConvertChecked(Expression.Property(data, "Length"), typeof(ulong))),
    //                    data.ForEach(current =>
    //                    {
    //                        return Expression.Block(new ParameterExpression[] { kv },
    //                            Expression.Assign(kv, current),
    //                            BuildWrite(writer, Expression.PropertyOrField(kv, "Key"), dataType[0]),
    //                            BuildWrite(writer, Expression.PropertyOrField(kv, "Value"), dataType[1])
    //                        );
    //                    },
    //                    Expression.Label())
    //                )));
    //        }

    //        if (dataType.IsSlotes)
    //        {
    //            List<ParameterExpression> variables = new List<ParameterExpression>();
    //            List<Expression> list = new List<Expression>();

    //            for (int i = 0; i < dataType.TypesCount; i++)
    //            {
    //                if (dataType[i].IsPrimitive || dataType[i].IsKeyValuePair)
    //                    list.Add(BuildWrite(writer, Expression.Field(data, String.Format("Slot{0}", i)), dataType[i]));
    //                else
    //                {
    //                    var @var = Expression.Variable(DataTypeUtils.GetSlotDataType(dataType[i]));
    //                    variables.Add(var);
    //                    list.Add(Expression.Assign(var, Expression.Field(data, String.Format("Slot{0}", i))));
    //                    list.Add(BuildWrite(writer, var, dataType[i]));
    //                }
    //            }
    //            return Expression.Block(variables,
    //                Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), isNotNull),
    //                Expression.IfThen(isNotNull,
    //                Expression.Block(list)
    //                ));
    //        }

    //        throw new NotSupportedException(dataType.ToString());
    //    }

    //    private static Expression GetWriteCommand(Expression writer, Expression dataSlot, DataType slotType)
    //    {
    //        if (slotType == DataType.Boolean ||
    //            slotType == DataType.Char ||
    //            slotType == DataType.SByte ||
    //            slotType == DataType.Byte ||
    //            slotType == DataType.Int16 ||
    //            slotType == DataType.Int32 ||
    //            slotType == DataType.UInt32 ||
    //            slotType == DataType.UInt16 ||
    //            slotType == DataType.Int64 ||
    //            slotType == DataType.UInt64 ||
    //            slotType == DataType.Single ||
    //            slotType == DataType.Double ||
    //            slotType == DataType.Decimal)
    //        {
    //            MethodInfo writeAny = typeof(BinaryWriter).GetMethod("Write", new Type[] { slotType.PrimitiveType });
    //            return Expression.Call(writer, writeAny, dataSlot);
    //        }
    //        else if (slotType == DataType.DateTime)
    //        {
    //            MethodInfo writeLong = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(long) });
    //            return Expression.Call(writer, writeLong, Expression.PropertyOrField(dataSlot, "Ticks"));
    //        }
    //        else if (slotType == DataType.String)
    //        {
    //            var writeBool = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) });
    //            var writeString = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(string) });

    //            return Expression.IfThenElse(
    //                Expression.Equal(dataSlot, Expression.Constant(null)),
    //                Expression.Call(writer, writeBool, Expression.Constant(false)),
    //                Expression.Block(Expression.Call(writer, writeBool, Expression.Constant(true)), Expression.Call(writer, writeString, dataSlot))
    //                );
    //        }
    //        else if (slotType == DataType.ByteArray)
    //        {
    //            var writeByteArray = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(byte[]) });

    //            //if (buffer == null)
    //            //    writer.Write(false);
    //            //else
    //            //{
    //            //    writer.Write(true);
    //            //    CountCompression.Serialize(writer, checked((long)buffer.Length));
    //            //    writer.Write(Buffer);
    //            //}

    //            var call1 = Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), Expression.Constant(false));
    //            var call2 = Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), Expression.Constant(true));
    //            var call3 = Expression.Call(typeof(CountCompression).GetMethod("Serialize"), writer, Expression.ConvertChecked(Expression.Property(dataSlot, "Length"), typeof(ulong)));

    //            return Expression.IfThenElse(Expression.Equal(dataSlot, Expression.Constant(null)),
    //                    call1,
    //                    Expression.Block(call2, call3, Expression.Call(writer, writeByteArray, dataSlot)));
    //        }
    //        else
    //            throw new NotSupportedException(slotType.ToString());
    //    }

    //    public void Write(BinaryWriter writer, IData item)
    //    {
    //        write(writer, item);
    //    }

    //    private Expression<Func<BinaryReader, IData>> CreateReadMethod()
    //    {
    //        var reader = Expression.Parameter(typeof(BinaryReader), "reader");

    //        var body = Expression.Block(Type, BuildRead(reader, DataType));

    //        var lambda = Expression.Lambda<Func<BinaryReader, IData>>(body, reader);

    //        return lambda;
    //    }

    //    private Expression BuildRead(Expression reader, DataType dataType)
    //    {
    //        if (dataType.IsPrimitive)
    //            return GetReadCommand(reader, dataType);

    //        if (dataType.IsKeyValuePair)
    //            return Expression.New(DataTypeUtils.GetSlotDataType(dataType).GetConstructor(new Type[] { DataTypeUtils.GetSlotDataType(dataType[0]), DataTypeUtils.GetSlotDataType(dataType[1]) }), BuildRead(reader, dataType[0]), BuildRead(reader, dataType[1]));

    //        var isNull = Expression.Equal(Expression.Call(reader, typeof(BinaryReader).GetMethod("Read" + typeof(bool).Name)), Expression.Constant(false));

    //        if (dataType.IsSlotes)
    //        {
    //            List<Expression> list = new List<Expression>();
    //            var data = Expression.Variable(DataTypeUtils.GetDataType(dataType), "data");
    //            var exitPoint = Expression.Label(DataTypeUtils.GetDataType(dataType));

    //            list.Add(Expression.Assign(data, Expression.New(DataTypeUtils.GetDataType(dataType).GetConstructor(new Type[] { }))));

    //            for (int i = 0; i < dataType.TypesCount; i++)
    //            {
    //                var field = Expression.Field(data, String.Format("Slot{0}", i));
    //                list.Add(Expression.Assign(field, BuildRead(reader, dataType[i])));
    //            }

    //            list.Add(Expression.Label(exitPoint, data));
    //            return Expression.Block(DataTypeUtils.GetDataType(dataType), new ParameterExpression[] { data }, list);
    //        }

    //        throw new ArgumentException(dataType.ToString());
    //    }

    //    private static Expression GetReadCommand(Expression reader, DataType slotType)
    //    {
    //        var field = Expression.Variable(DataTypeUtils.GetSlotDataType(slotType));
    //        var exitPoint = Expression.Label(DataTypeUtils.GetSlotDataType(slotType));

    //        if (slotType == DataType.Boolean ||
    //            slotType == DataType.Char ||
    //            slotType == DataType.SByte ||
    //            slotType == DataType.Byte ||
    //            slotType == DataType.Int16 ||
    //            slotType == DataType.Int32 ||
    //            slotType == DataType.UInt32 ||
    //            slotType == DataType.UInt16 ||
    //            slotType == DataType.Int64 ||
    //            slotType == DataType.UInt64 ||
    //            slotType == DataType.Single ||
    //            slotType == DataType.Double ||
    //            slotType == DataType.Decimal)
    //        {
    //            MethodInfo readAny = typeof(BinaryReader).GetMethod("Read" + slotType.PrimitiveType.Name);

    //            //reader.ReadInt32();

    //            return Expression.Call(reader, readAny);
    //        }
    //        else if (slotType == DataType.DateTime)
    //        {
    //            MethodInfo readLong = typeof(BinaryReader).GetMethod("Read" + typeof(long).Name);
    //            return Expression.New(typeof(DateTime).GetConstructor(new Type[] { typeof(long) }), Expression.Call(reader, readLong));

    //            //new DateTime(reader.ReadInt64());
    //        }
    //        else if (slotType == DataType.String)
    //        {
    //            var readBool = typeof(BinaryReader).GetMethod("Read" + typeof(bool).Name);
    //            var readString = typeof(BinaryReader).GetMethod("Read" + typeof(string).Name);

    //            //if(reader.ReadBool() == false)
    //            //  null;
    //            //else
    //            //  reader.ReadString();



    //            var @if = Expression.IfThenElse(
    //                Expression.Equal(Expression.Call(reader, readBool), Expression.Constant(false)),
    //                Expression.Assign(field, Expression.Constant(null, typeof(string))),
    //                Expression.Assign(field, Expression.Call(reader, readString))
    //               );

    //            return Expression.Block(typeof(string), new ParameterExpression[] { field }, @if, Expression.Label(exitPoint, field));
    //        }
    //        else if (slotType == DataType.ByteArray)
    //        {
    //            var readReadBytes = typeof(BinaryReader).GetMethod("ReadBytes");

    //            var callFlag = Expression.Call(reader, typeof(BinaryReader).GetMethod("ReadBoolean"));

    //            var call = Expression.Call(typeof(CountCompression).GetMethod("Deserialize"), reader);
    //            var @if = Expression.IfThenElse(callFlag,
    //                                                Expression.Assign(field, Expression.Call(reader, readReadBytes, Expression.Convert(call, typeof(int)))),
    //                                                Expression.Assign(field, Expression.Constant(null, typeof(byte[])))
    //                                            );

    //            //field = reader.ReadBoolean() ? reader.ReadBytes((int)CountCompression.Deserialize(reader)) : null;

    //            return Expression.Block(typeof(byte[]), new ParameterExpression[] { field }, @if, Expression.Label(exitPoint, field));
    //        }
    //        else
    //            throw new NotSupportedException(slotType.ToString());
    //    }

    //    public IData Read(BinaryReader reader)
    //    {
    //        return read(reader);
    //    }
    //}

    //public class DataPersistExample : IPersist<IData>
    //{
    //    private DataType dt = DataType.Slotes(
    //                    DataType.DateTime,
    //                    DataType.String,
    //                    DataType.List(DataType.KeyValuePair(DataType.Double, DataType.Double)),
    //                    DataType.Dictionary(DataType.Int32, DataType.Int64),
    //                    DataType.Array(DataType.Array(DataType.Boolean)),
    //                    DataType.ByteArray,
    //                    DataType.Slotes(DataType.Int32, DataType.String)
    //                    );

    //    public void Write(BinaryWriter writer, IData item)
    //    {
    //        Data<DateTime, string, List<KeyValuePair<double, double>>, Dictionary<int, long>, bool[][], byte[], Data<int, string>> data =
    //            (Data<DateTime, string, List<KeyValuePair<double, double>>, Dictionary<int, long>, bool[][], byte[], Data<int, string>>)item;

    //        writer.Write(data != null);
    //        if (data != null)
    //        {
    //            writer.Write(data.Slot0.Ticks);

    //            writer.Write(data.Slot1 != null);
    //            if (data.Slot1 != null)
    //                writer.Write(data.Slot1);

    //            List<KeyValuePair<double, double>> list = data.Slot2;

    //            writer.Write(list != null);
    //            if (list != null)
    //            {
    //                CountCompression.Serialize(writer, checked((ulong)list.Count));

    //                for (int i = 0; i < list.Count; i++)
    //                {
    //                    writer.Write(list[i].Key);
    //                    writer.Write(list[i].Value);
    //                }
    //            }

    //            Dictionary<int, long> dictinary = data.Slot3;

    //            writer.Write(dictinary != null);
    //            if (dictinary != null)
    //            {
    //                CountCompression.Serialize(writer, checked((ulong)dictinary.Count));

    //                foreach (var kv in dictinary)
    //                {
    //                    writer.Write(kv.Key);
    //                    writer.Write(kv.Value);
    //                }
    //            }

    //            bool[][] array1 = data.Slot4;

    //            writer.Write(array1 != null);
    //            if (array1 != null)
    //            {
    //                CountCompression.Serialize(writer, checked((ulong)array1.Length));

    //                for (int i = 0; i < array1.Length; i++)
    //                {
    //                    writer.Write(array1[i] != null);
    //                    if (array1[i] != null)
    //                    {
    //                        CountCompression.Serialize(writer, checked((ulong)array1[i].Length));

    //                        for (int j = 0; j < array1[i].Length; j++)
    //                            writer.Write(array1[i][j]);
    //                    }
    //                }
    //            }

    //            writer.Write(data.Slot5 != null);
    //            if (data.Slot5 != null)
    //            {
    //                CountCompression.Serialize(writer, checked((ulong)data.Slot5.Length));

    //                writer.Write(data.Slot5);
    //            }

    //            Data<int, string> slotes = data.Slot6;

    //            writer.Write(slotes != null);
    //            if (slotes != null)
    //            {
    //                writer.Write(slotes.Slot0);

    //                writer.Write(slotes.Slot1 != null);
    //                if (slotes.Slot1 != null)
    //                    writer.Write(slotes.Slot1);
    //            }
    //        }
    //    }

    //    public IData Read(BinaryReader reader)
    //    {
    //        Data<DateTime, string, List<KeyValuePair<double, double>>, Dictionary<int, long>, bool[][], byte[], Data<int, string>> data = new Data<DateTime, string, List<KeyValuePair<double, double>>, Dictionary<int, long>, bool[][], byte[], Data<int, string>>();
    //        data.Slot0 = new DateTime(reader.ReadInt64());

    //        if (!reader.ReadBoolean())
    //            data.Slot1 = null;
    //        else
    //            data.Slot1 = reader.ReadString();

    //        if (!reader.ReadBoolean())
    //            data.Slot2 = null;
    //        else
    //        {
    //            int countOfList = reader.ReadInt32();
    //            data.Slot2 = new List<KeyValuePair<double, double>>();

    //            for (int i = 0; i < countOfList; i++)
    //                data.Slot2.Add(new KeyValuePair<double, double>(reader.ReadDouble(), reader.ReadDouble()));
    //        }

    //        if (!reader.ReadBoolean())
    //            data.Slot3 = null;
    //        else
    //        {
    //            int countOfDisctionry = reader.ReadInt32();
    //            data.Slot3 = new Dictionary<int, long>();

    //            for (int i = 0; i < countOfDisctionry; i++)
    //                data.Slot3.Add(reader.ReadInt32(), reader.ReadInt64());
    //        }

    //        if (!reader.ReadBoolean())
    //            data.Slot4 = null;
    //        else
    //        {
    //            int lenghtOutArray = reader.ReadInt32();
    //            data.Slot4 = new bool[lenghtOutArray][];

    //            for (int i = 0; i < lenghtOutArray; i++)
    //            {
    //                if (!reader.ReadBoolean())
    //                {
    //                    data.Slot4[i] = null;
    //                }
    //                else
    //                {
    //                    int lenghtInArray = reader.ReadInt32();
    //                    data.Slot4[i] = new bool[lenghtInArray];

    //                    for (int j = 0; j < lenghtInArray; j++)
    //                    {
    //                        data.Slot4[i][j] = reader.ReadBoolean();
    //                    }
    //                }
    //            }
    //        }

    //        if (!reader.ReadBoolean())
    //            data.Slot5 = null;
    //        else
    //        {
    //            int lenghtOfBuffer = reader.ReadInt32();

    //            data.Slot5 = new byte[lenghtOfBuffer];

    //            for (int i = 0; i < lenghtOfBuffer; i++)
    //            {
    //                data.Slot5[i] = reader.ReadByte();
    //            }
    //        }

    //        if (!reader.ReadBoolean())
    //            data.Slot6 = null;
    //        else
    //        {
    //            data.Slot6.Slot0 = reader.ReadInt32();

    //            if (reader.ReadBoolean() == false)
    //                data.Slot6.Slot1 = null;
    //            else
    //                data.Slot6.Slot1 = reader.ReadString();
    //        }

    //        return data;
    //    }
    //}
}
