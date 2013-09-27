using STSdb4.General.Compression;
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
    public class DataPersist : IPersist<IData>
    {
        private Action<BinaryWriter, IData> write;
        private Func<BinaryReader, IData> read;

        private Type Type;
        public DataType DataType { get; private set; }

        public Expression<Action<BinaryWriter, IData>> LambdaWrite { get; private set; }
        public Expression<Func<BinaryReader, IData>> LambdaRead { get; private set; }

        public DataPersist(DataType dataType)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            DataType = dataType;
            Type = DataTypeUtils.GetDataType(dataType);

            //prepare Write
            LambdaWrite = CreateWriteMethod();
            write = LambdaWrite.Compile();

            //prepare Read
            LambdaRead = CreateReadMethod();
            read = LambdaRead.Compile();
        }

        private Expression<Action<BinaryWriter, IData>> CreateWriteMethod()
        {
            var writer = Expression.Parameter(typeof(BinaryWriter), "writer");
            var item = Expression.Parameter(typeof(IData), "item");

            var data = Expression.Variable(Type);

            List<Expression> list = new List<Expression>();
            list.Add(Expression.Assign(data, Expression.Convert(item, Type)));

            if (DataType.IsPrimitive)
            {
                var command = GetWriteCommand(writer, data, DataType, 0);
                list.Add(command);
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                {
                    var command = GetWriteCommand(writer, data, DataType[i], i);
                    list.Add(command);
                }
            }

            var body = Expression.Block((new ParameterExpression[] { data }), list);
            var lambda = Expression.Lambda<Action<BinaryWriter, IData>>(body, writer, item);

            //void write(BinaryWriter writer, IData item)
            //{
            //    var data = (Data<int, string, double, DateTime>)item;
            //    writer.Write(data.Slot0);
            //    if (data.Slot1 == null)
            //        writer.Write(false);
            //    else
            //    {
            //        writer.Write(true);
            //        writer.Write(data.Slot1);
            //    }
            //    writer.Write(data.Slot2);
            //    writer.Write(data.Slot3.Ticks);
            //}

            return lambda;
        }

        private Expression<Func<BinaryReader, IData>> CreateReadMethod()
        {
            var reader = Expression.Parameter(typeof(BinaryReader), "reader");

            var data = Expression.Variable(Type, "data");
            var assign = Expression.Assign(data, Expression.New(Type.GetConstructor(new Type[] { })));

            List<Expression> list = new List<Expression>();
            list.Add(assign);

            if (DataType.IsPrimitive)
            {
                var command = GetReadCommand(reader, data, DataType, 0);
                list.Add(command);
            }
            else
            {
                for (int i = 0; i < DataType.TypesCount; i++)
                {
                    var command = GetReadCommand(reader, data, DataType[i], i);
                    list.Add(command);
                }
            }

            var exitPoint = Expression.Label(Type);
            list.Add(Expression.Label(exitPoint, data));

            var body = Expression.Block(Type, new ParameterExpression[] { data }, list);
            var lambda = Expression.Lambda<Func<BinaryReader, IData>>(body, reader);

            //IData read(BinaryReader reader)
            //{
            //    var data = new Data<int, string, double, DateTime>();
            //    data.Slot0 = reader.ReadInt32();
            //    if (reader.ReadBoolean())
            //        data.Slot1 = reader.ReadString();
            //    data.Slot2 = reader.ReadDouble();
            //    data.Slot3 = new DateTime(reader.ReadInt64());
            //    return data;
            //}

            return lambda;
        }

        public void Write(BinaryWriter writer, IData item)
        {
            write(writer, item);
        }

        public IData Read(BinaryReader reader)
        {
            return read(reader);
        }

        private static Expression GetWriteCommand(Expression writer, Expression data, DataType slotType, int slot)
        {
            var field = Expression.Field(data, String.Format("Slot{0}", slot));

            if (slotType == DataType.Boolean ||
                slotType == DataType.Char ||
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
                slotType == DataType.Decimal)
            {
                MethodInfo writeAny = typeof(BinaryWriter).GetMethod("Write", new Type[] { slotType.PrimitiveType });
                return Expression.Call(writer, writeAny, field);
            }
            else if (slotType == DataType.DateTime)
            {
                MethodInfo writeLong = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(long) });
                return Expression.Call(writer, writeLong, Expression.PropertyOrField(field, "Ticks"));
            }
            else if (slotType == DataType.String)
            {
                var writeBool = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) });
                var writeString = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(string) });

                return Expression.IfThenElse(
                    Expression.Equal(field, Expression.Constant(null)),
                    Expression.Call(writer, writeBool, Expression.Constant(false)),
                    Expression.Block(Expression.Call(writer, writeBool, Expression.Constant(true)), Expression.Call(writer, writeString, field))
                    );
            }
            else if (slotType == DataType.ByteArray)
            {
                var writeByteArray = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(byte[]) });

                //if (buffer == null)
                //    writer.Write(false);
                //else
                //{
                //    writer.Write(true);
                //    CountCompression.Serialize(writer, checked((long)buffer.Length));
                //    writer.Write(Buffer);
                //}

                var call1 = Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), Expression.Constant(false));
                var call2 = Expression.Call(writer, typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(bool) }), Expression.Constant(true));
                var call3 = Expression.Call(typeof(CountCompression).GetMethod("Serialize"), writer, Expression.ConvertChecked(Expression.PropertyOrField(field, "Length"), typeof(ulong)));

                return Expression.IfThenElse(Expression.Equal(field, Expression.Constant(null)),
                        call1,
                        Expression.Block(call2, call3, Expression.Call(writer, writeByteArray, field)));
            }
            else
                throw new NotSupportedException(slotType.ToString());
        }

        private static Expression GetReadCommand(Expression reader, Expression data, DataType slotType, int slot)
        {
            var field = Expression.Field(data, String.Format("Slot{0}", slot));

            if (slotType == DataType.Boolean ||
                slotType == DataType.Char ||
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
                slotType == DataType.Decimal)
            {
                MethodInfo readAny = typeof(BinaryReader).GetMethod("Read" + slotType.PrimitiveType.Name);

                //field = reader.ReadInt32();

                return Expression.Assign(field, Expression.Call(reader, readAny));
            }
            else if (slotType == DataType.DateTime)
            {
                MethodInfo readLong = typeof(BinaryReader).GetMethod("Read" + typeof(long).Name);
                var init = Expression.New(typeof(DateTime).GetConstructor(new Type[] { typeof(long) }), Expression.Call(reader, readLong));

                //field = new DateTime(reader.ReadInt64());

                return Expression.Assign(field, init);
            }
            else if (slotType == DataType.String)
            {
                var readBool = typeof(BinaryReader).GetMethod("Read" + typeof(bool).Name);
                var readString = typeof(BinaryReader).GetMethod("Read" + typeof(string).Name);

                //if(reader.ReadBool() == false)
                //  field = null;
                //else
                //  field = reader.ReadString();

                return Expression.IfThenElse(
                    Expression.Equal(Expression.Call(reader, readBool), Expression.Constant(false)),
                    Expression.Assign(field, Expression.Constant(null, typeof(string))),
                    Expression.Assign(field, Expression.Call(reader, readString))
                    );
            }
            else if (slotType == DataType.ByteArray)
            {
                var readReadBytes = typeof(BinaryReader).GetMethod("ReadBytes");

                var callFlag = Expression.Call(reader, typeof(BinaryReader).GetMethod("ReadBoolean"));

                var call = Expression.Call(typeof(CountCompression).GetMethod("Deserialize"), reader);
                var @if = Expression.IfThenElse(callFlag,
                                                Expression.Assign(field, Expression.Call(reader, readReadBytes, Expression.Convert(call, typeof(int)))),
                                                Expression.Assign(field, Expression.Constant(null, typeof(byte[])))
                                                );

                //field = reader.ReadBoolean() ? reader.ReadBytes((int)CountCompression.Deserialize(reader)) : null;

                return @if;
            }
            else
                throw new NotSupportedException(slotType.ToString());
        }
    }
}
