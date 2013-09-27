using STSdb4.General.Compression;
using STSdb4.General.Persist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using STSdb4.General.Extensions;
using System.Reflection;

namespace STSdb4.Data
{
    public class DataIndexerPersist : IIndexerPersist<IData>
    {
        private Action<BinaryWriter, Func<int, IData>, int> store;
        private Action<BinaryReader, Action<int, IData>, int> load;

        public DataType DataType { get; private set; }
        public IIndexerPersist[] Persists { get; private set; }

        public Expression<Action<BinaryWriter, Func<int, IData>, int>> LambdaStore { get; private set; }
        public Expression<Action<BinaryReader, Action<int, IData>, int>> LambdaLoad { get; private set; }

        public DataIndexerPersist(DataType dataType, IIndexerPersist[] persists)
        {
            bool supported = dataType.IsPrimitive || (dataType.IsSlotes && dataType.AreAllTypesPrimitive);
            if (!supported)
                throw new NotSupportedException(dataType.ToString());

            DataType = dataType;
            Persists = persists;

            if (DataType.IsPrimitive)
            {
                LambdaStore = CreateStoreMethodSingleSlot();
                LambdaLoad = CreateLoadMethodSingleSlot();
            }
            else
            {
                LambdaStore = CreateStoreMethod();
                LambdaLoad = CreateLoadMethod();
            }

            store = LambdaStore.Compile();
            load = LambdaLoad.Compile();
        }

        public DataIndexerPersist(DataType dataType)
            : this(dataType, GetDefaultPersists(dataType))
        {
        }

        public void Store(BinaryWriter writer, Func<int, IData> values, int count)
        {
            store(writer, values, count);
        }

        public void Load(BinaryReader reader, Action<int, IData> values, int count)
        {
            load(reader, values, count);
        }

        #region Store

        private Expression<Action<BinaryWriter, Func<int, IData>, int>> CreateStoreMethod()
        {
            List<Expression> list = new List<Expression>();

            var writer = Expression.Parameter(typeof(BinaryWriter), "writer");
            var values = Expression.Parameter(typeof(Func<int, IData>), "values");
            var count = Expression.Parameter(typeof(int), "count");

            var idataType = DataTypeUtils.GetDataType(DataType);

            //Action[] actions = new Action[DataType.TypesCount];

            var actions = Expression.Variable(typeof(Action[]), "actions");
            var newActions = Expression.NewArrayBounds(typeof(Action), Expression.Constant(DataType.TypesCount, typeof(int)));
            var assignActions = Expression.Assign(actions, newActions);

            list.Add(assignActions);

            //MemoryStream[] streams = new MemoryStream[DataType.TypesCount];

            var streams = Expression.Variable(typeof(MemoryStream[]), "streams");
            var newStreams = Expression.NewArrayBounds(typeof(MemoryStream), Expression.Constant(DataType.TypesCount, typeof(int)));
            var assignStreams = Expression.Assign(streams, newStreams);

            list.Add(assignStreams);

            ////Int
            //actions[0] = () =>
            //{
            //    ms[0] = new MemoryStream();
            //    ((IIndexerPersist<Int32>)persist[0]).Store(new BinaryWriter(streams[0]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot0; }, count);
            //};

            for (int j = 0; j < DataType.TypesCount; j++)
            {
                //actions[0] = ()=> { task body }

                var slotType = idataType.GetField("Slot" + j).FieldType;
                var storeTaskBody = GetStoreActionBody(Persists[j], j, values, count, streams);
                var taskAssign = Expression.Assign(Expression.ArrayAccess(actions, Expression.Constant(j)), storeTaskBody);

                list.Add(taskAssign);
            }

            //Parallel.Invoke(actions);

            var InvokeMethod = typeof(Parallel).GetMethod("Invoke", new Type[] { typeof(Action[]) });
            list.Add(Expression.Call(InvokeMethod, actions));

            //for (int i = 0; i < DataType.TypesCount; i++)
            //{
            //    var stream = streams[i];
            //    using (stream)
            //    {
            //        CountCompression.Serialize(writer, checked((ulong)stream.Length));
            //        writer.Write(stream.GetBuffer(), 0, (int)stream.Length);
            //    }
            //}

            var i = Expression.Variable(typeof(int), "i");
            var msIndex = Expression.ArrayAccess(streams, i);
            var stream = Expression.Variable(typeof(MemoryStream), "stream");
            var assignStream = Expression.Assign(stream, msIndex);
            var streamLength = Expression.Property(stream, "Length");
            var writeByteArray = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(byte[]), typeof(int), typeof(int) });

            LabelTarget returnPoint = Expression.Label("RETURN_POINT");

            var GetSerialize = Expression.Call(typeof(CountCompression).GetMethod("Serialize"), writer, Expression.ConvertChecked(streamLength, typeof(ulong)));
            var GetBuffer = Expression.Call(stream, typeof(MemoryStream).GetMethod("GetBuffer"));
            var GetWrite = Expression.Call(writer, writeByteArray, GetBuffer, Expression.Constant(0), Expression.Convert(streamLength, typeof(int)));

            var usingBody = Expression.Block(assignStream,
                                             GetSerialize,   //CountCompression.Serialize(writer, checked((ulong)stream.Length));
                                             GetWrite       // writer.Write(stream.GetBuffer(), 0, (int)stream.Length);
                                             );

            var streamUsing = stream.Using(usingBody);

            var counterAssign = Expression.Assign(i, Expression.Constant(0));
            list.Add(counterAssign);

            var loopBody = Expression.Block(//assignStream,       //var stream = ms[i];
                                            streamUsing,        //using (stream) {...} 
                                            Expression.AddAssign(i, Expression.Constant(1)));

            var loop = Expression.Loop(Expression.IfThenElse(Expression.LessThan(i, Expression.Constant(DataType.TypesCount, typeof(int))),
                                            loopBody,
                                            Expression.Break(returnPoint)), returnPoint);

            list.Add(loop);

            var lambdaBody = Expression.Block(new ParameterExpression[] { actions, i, streams }, list);
            var lambda = Expression.Lambda<Action<BinaryWriter, Func<int, IData>, int>>(lambdaBody, new ParameterExpression[] { writer, values, count });

            return lambda;
        }

        private Expression<Action<BinaryWriter, Func<int, IData>, int>> CreateStoreMethodSingleSlot()
        {
            var writer = Expression.Parameter(typeof(BinaryWriter), "writer");
            var values = Expression.Parameter(typeof(Func<int, IData>), "values");
            var count = Expression.Parameter(typeof(int), "count");

            var idataType = DataTypeUtils.GetDataType(DataType);

            List<Expression> list = new List<Expression>();

            //MemoryStream ms = new MemoryStream()

            var ms = Expression.Variable(typeof(MemoryStream), "ms");
            var newMs = Expression.New(typeof(MemoryStream).GetConstructor(new Type[] { }));
            var msLength = Expression.Property(ms, "Length");

            //((IIndexerPersist<Int32>)persist[0]).Store(new BinaryWriter(streams[0]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot0; }, count);

            var castPersist = Expression.Convert(Expression.Constant(Persists[0]), Persists[0].GetType());
            var storeMethod = Persists[0].GetType().GetMethod("Store");

            var binaryWriter = Expression.New(typeof(BinaryWriter).GetConstructor(new Type[] { typeof(MemoryStream) }), ms);

            var idx = Expression.Variable(typeof(int), "idx");
            var internalCall = Expression.Call(values, values.Type.GetMethod("Invoke"), idx);
            var cast = Expression.Convert(internalCall, idataType);
            var field = Expression.Field(cast, String.Format("Slot{0}", 0));
            var func = Expression.Lambda(field, idx);

            var storeCall = Expression.Call(castPersist, storeMethod, new Expression[] { binaryWriter, func, count });
            list.Add(storeCall);

            //CountCompression.Serialize(writer, checked((ulong)ms.Length));

            var callCompression = Expression.Call(typeof(CountCompression), "Serialize", null, new Expression[] { writer, Expression.ConvertChecked(msLength, typeof(ulong)) });
            list.Add(callCompression);

            //writer.Write(ms.GetBuffer(), 0, (int)ms.Length);

            var writeByteArray = typeof(BinaryWriter).GetMethod("Write", new Type[] { typeof(byte[]), typeof(int), typeof(int) });

            var GetBufferCaller = Expression.Call(ms, typeof(MemoryStream).GetMethod("GetBuffer"));
            var GetWriteCaller = Expression.Call(writer, writeByteArray, GetBufferCaller, Expression.Constant(0), Expression.Convert(msLength, typeof(int)));

            list.AddRange(new Expression[] { GetWriteCaller });

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    ((IIndexerPersist<String>)persist[0]).Store(new BinaryWriter(ms), (idx) => { return ((Data<string>)values(idx)).Slot0; }, count);
            //    CountCompression.Serialize(writer, checked((ulong)ms.Length));
            //    writer.Write(ms.GetBuffer(), 0, (int)ms.Length);
            //}

            var usingBody = Expression.Block(list);
            var methodbody = ms.Using(newMs, usingBody);

            var parameters = new ParameterExpression[] { writer, values, count };

            var lambda = Expression.Lambda<Action<BinaryWriter, Func<int, IData>, int>>(methodbody, parameters);

            return lambda;
        }

        private Expression GetStoreActionBody(IIndexerPersist persist, int slotIndex, ParameterExpression values, ParameterExpression count, ParameterExpression ms)
        {
            List<Expression> list = new List<Expression>();

            var msAccess = Expression.ArrayAccess(ms, Expression.Constant(slotIndex));
            var msConstructor = Expression.New(typeof(MemoryStream).GetConstructor(new Type[] { }));
            var msAssign = Expression.Assign(msAccess, msConstructor);

            var storeCall = GetStorePersistCall(persist, slotIndex, msAccess, values, count);

            list.Add(msAssign);
            list.Add(storeCall);

            //() =>
            //{
            //    ms[slotIndex] = new MemoryStream();
            //    ((IIndexerPersist<Int32>)persist[0]).Store(new BinaryWriter(streams[0]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot0; }, count);
            //};

            var action = Expression.Lambda(Expression.Block(list));

            return action;
        }

        private Expression GetStorePersistCall(IIndexerPersist persist, int slotIndex, Expression msAccess, ParameterExpression values, ParameterExpression count)
        {
            var castPersist = Expression.Convert(Expression.Constant(Persists[slotIndex]), Persists[slotIndex].GetType());

            var binaryWriter = Expression.New(typeof(BinaryWriter).GetConstructor(new Type[] { typeof(MemoryStream) }), msAccess);

            var idx = Expression.Variable(typeof(int), "idx");
            var callFunc = Expression.Call(values, values.Type.GetMethod("Invoke"), idx);

            var cast = Expression.Convert(callFunc, DataTypeUtils.GetDataType(DataType));
            var field = Expression.Field(cast, String.Format("Slot{0}", slotIndex));

            var storeMethod = persist.GetType().GetMethod("Store");

            var func = Expression.Lambda(field, idx);
            var storeCall = Expression.Call(castPersist, storeMethod, new Expression[] { binaryWriter, func, count });

            //((IIndexerPersist<Int32>)persist[0]).Store(new BinaryWriter(streams[0]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot0; }, count);

            return storeCall;
        }

        #endregion

        #region Load

        private Expression<Action<BinaryReader, Action<int, IData>, int>> CreateLoadMethod()
        {
            List<Expression> list = new List<Expression>();

            var reader = Expression.Parameter(typeof(BinaryReader), "reader");
            var values = Expression.Parameter(typeof(Action<int, IData>), "values");
            var count = Expression.Parameter(typeof(int), "count");

            var idataType = DataTypeUtils.GetDataType(DataType);

            //Data<int, string, double>[] array = new Data<int, string, double>[count];

            var array = Expression.Variable(idataType.MakeArrayType(), "array");
            var newArray = Expression.NewArrayBounds(idataType, count);
            var assignArray = Expression.Assign(array, newArray);

            list.Add(assignArray);

            //for (int i = 0; i < count; i++)
            //{
            //    var data = new Data<int, string, double>();
            //    array[i] = data;
            //    values(i, data);
            //}

            var i = Expression.Variable(typeof(int), "i");
            var counterAssign = Expression.Assign(i, Expression.Constant(0));
            list.Add(counterAssign);

            var data = Expression.Variable(idataType, "data");
            var callAction = Expression.Call(values, values.Type.GetMethod("Invoke"), i, data);

            LabelTarget returnPoint = Expression.Label("RETURN_POINT");

            var loopBody = Expression.Block(new ParameterExpression[] { data },
                                                Expression.Assign(data, Expression.New(idataType)),
                                                Expression.Assign(Expression.ArrayAccess(array, i), data),
                                                callAction,
                                                Expression.AddAssign(i, Expression.Constant(1))
                                                );

            var loop = Expression.Loop(Expression.IfThenElse(Expression.LessThan(i, count),
                                            loopBody,
                                            Expression.Break(returnPoint)), returnPoint);

            list.Add(loop);

            //Action[] actions = new Action[DataType.TypesCount];

            var actions = Expression.Variable(typeof(Action[]), "actions");
            var newActions = Expression.NewArrayBounds(typeof(Action), Expression.Constant(DataType.TypesCount));
            var assignActions = Expression.Assign(actions, newActions);

            list.Add(assignActions);

            //byte[][] buffers = new byte[DataType.TypesCount][];

            var buffers = Expression.Variable(typeof(byte[][]), "buffers");
            var newBuffers = Expression.NewArrayBounds(typeof(byte[]), Expression.Constant(DataType.TypesCount));
            var assignBuffers = Expression.Assign(buffers, newBuffers);

            list.Add(assignBuffers);

            //for (int j = 0; j < DataType.TypesCount; j++)
            //    buffers[j] = reader.ReadBytes((int)CountCompression.Deserialize(reader));

            var counterAssign2 = Expression.Assign(i, Expression.Constant(0));
            list.Add(counterAssign2);

            var ReadBytes = typeof(BinaryReader).GetMethod("ReadBytes", new Type[] { typeof(int) });
            var Deserialize = typeof(CountCompression).GetMethod("Deserialize");

            var callDeserialize = Expression.Convert(Expression.Call(Deserialize, reader), typeof(int));
            var callReadBytes = Expression.Call(reader, ReadBytes, callDeserialize);

            var loopBody2 = Expression.Block(
                                     Expression.Assign(Expression.ArrayAccess(buffers, i), callReadBytes),
                                     Expression.AddAssign(i, Expression.Constant(1)));

            var loop2 = Expression.Loop(Expression.IfThenElse(Expression.LessThan(i, Expression.Constant(DataType.TypesCount, typeof(int))),
                                            loopBody2,
                                            Expression.Break(returnPoint)), returnPoint);

            list.Add(loop2);

            //Int32
            //actions[0] = () =>
            //{
            //    using (MemoryStream ms = new MemoryStream(buffers[0]))
            //        new Int32IndexerPersist().Load(new BinaryReader(ms), (idx, value) => { array[idx].Slot0 = value; }, count);
            //};

            for (int k = 0; k < DataType.TypesCount; k++)
            {
                var slotType = idataType.GetField("Slot" + k).FieldType;
                var loadBody = GetLoadActionBody(slotType, k, array, buffers, values, count);
                var action = Expression.Assign(Expression.ArrayAccess(actions, Expression.Constant(k)), loadBody);

                list.Add(action);
            }

            //Parallel.Invoke(actions);

            var Invoke = typeof(Parallel).GetMethod("Invoke", new Type[] { typeof(Action[]) });
            list.Add(Expression.Call(Invoke, actions));

            var lambdaBody = Expression.Block(new ParameterExpression[] { array, actions, buffers, i }, list);
            var lambda = Expression.Lambda<Action<BinaryReader, Action<int, IData>, int>>(lambdaBody, new ParameterExpression[] { reader, values, count });

            return lambda;
        }

        public Expression<Action<BinaryReader, Action<int, IData>, int>> CreateLoadMethodSingleSlot()
        {
            var reader = Expression.Parameter(typeof(BinaryReader), "reader");
            var values = Expression.Parameter(typeof(Action<int, IData>), "values");
            var count = Expression.Parameter(typeof(int), "count");

            List<Expression> list = new List<Expression>();

            //byte[] buffer = reader.ReadBytes((int)CountCompression.Deserialize(reader));

            var buffer = Expression.Variable(typeof(byte[]), "buffer");
            var ReadBytes = typeof(BinaryReader).GetMethod("ReadBytes");
            var counter = Expression.Convert(Expression.Call(typeof(CountCompression).GetMethod("Deserialize"), reader), typeof(int));
            var ReadBytesCaller = Expression.Call(reader, ReadBytes, counter);

            list.Add(Expression.Assign(buffer, ReadBytesCaller));

            var ms = Expression.Variable(typeof(MemoryStream), "ms");
            var newMs = Expression.New(typeof(MemoryStream).GetConstructor(new Type[] { typeof(byte[]) }), buffer);

            //((IIndexerPersist<string>)persist[0]).Load(new BinaryReader(ms), (idx, value) => { values(idx, new Data<string>(value)); }, count);

            var castPersist = Expression.Convert(Expression.Constant(Persists[0]), Persists[0].GetType());
            var loadMethod = Persists[0].GetType().GetMethod("Load");

            var binaryReader = Expression.New(typeof(BinaryReader).GetConstructor(new Type[] { typeof(MemoryStream) }), ms);

            var idx = Expression.Variable(typeof(int), "idx");
            var value = Expression.Variable(DataType.PrimitiveType, "value");
            var newData = Expression.New(DataTypeUtils.GetDataType(DataType).GetConstructor(new Type[] { DataType.PrimitiveType }), value);
            var internalCall = Expression.Call(values, values.Type.GetMethod("Invoke"), idx, newData);

            var func = Expression.Lambda(internalCall, idx, value);
            var loadCall = Expression.Call(castPersist, loadMethod, binaryReader, func, count);

            //byte[] buffer = reader.ReadBytes((int)CountCompression.Deserialize(reader));

            //using (MemoryStream ms = new MemoryStream(buffer))
            //((IIndexerPersist<string>)persist[0]).Load(new BinaryReader(ms), (idx, value) => { values(idx, new Data<string>(value)); }, count);

            var usingBody = ms.Using(newMs, loadCall);
            list.Add(usingBody);

            var lambda = Expression.Lambda<Action<BinaryReader, Action<int, IData>, int>>(Expression.Block(new ParameterExpression[] { buffer }, list), new ParameterExpression[] { reader, values, count });

            return lambda;
        }

        private Expression GetLoadActionBody(Type slotType, int slotIndex, ParameterExpression array, ParameterExpression buffers, ParameterExpression values, ParameterExpression count)
        {
            //Int32
            //actions[0] = () =>
            //{
            //    using (MemoryStream ms = new MemoryStream(buffers[0]))
            //        ((IIndexerPersist<string>)persist[0]).Load(new BinaryReader(ms), (idx, value) => { array[idx].Slot0 = value; }, count);
            //};

            var ms = Expression.Variable(typeof(MemoryStream), "ms");
            var msConstructor = Expression.New(typeof(MemoryStream).GetConstructor(new Type[] { typeof(byte[]) }), Expression.ArrayAccess(buffers, Expression.Constant(slotIndex)));

            var usingBody = Expression.Block(GetLoadPersistCall(slotType, slotIndex, array, ms, count));
            var streamUsing = ms.Using(msConstructor, usingBody);

            var lambda = Expression.Lambda(Expression.Block(streamUsing));

            return lambda;
        }

        private Expression GetLoadPersistCall(Type slotType, int slotIndex, ParameterExpression array, ParameterExpression ms, ParameterExpression count)
        {
            //  ((IIndexerPersist<string>)persist[0]).Load(new BinaryReader(ms), (idx, value) => { array[idx].Slot0 = value; }, count);

            var castPersist = Expression.Convert(Expression.Constant(Persists[slotIndex]), Persists[slotIndex].GetType());
            var loadMethod = Persists[slotIndex].GetType().GetMethod("Load");

            var readerConstructor = Expression.New(typeof(BinaryReader).GetConstructor(new Type[] { typeof(MemoryStream) }), ms);

            var idx = Expression.Variable(typeof(int), "idx");
            var value = Expression.Variable(slotType, "value");

            var field = Expression.Field(Expression.ArrayAccess(array, idx), String.Format("Slot{0}", slotIndex));
            var assignField = Expression.Assign(field, value);

            Type primitiveAction = typeof(Action<,>).MakeGenericType(new Type[] { typeof(int), slotType }); // Action<int, slotType>

            var action = Expression.Lambda(primitiveAction, assignField, idx, value);
            var loadCall = Expression.Call(castPersist, loadMethod, new Expression[] { readerConstructor, action, count });

            return loadCall;
        }

        #endregion

        private static IIndexerPersist GetDefaultPersist(DataType type)
        {
            if (!type.IsPrimitive)
                throw new NotSupportedException(type.ToString());

            if (type == DataType.Boolean)
                return new BooleanIndexerPersist();
            if (type == DataType.Char)
                return new CharIndexerPersist();
            if (type == DataType.Byte)
                return new ByteIndexerPersist();
            if (type == DataType.SByte)
                return new SByteIndexerPersist();
            if (type == DataType.Int16)
                return new Int16IndexerPersist();
            if (type == DataType.UInt16)
                return new UInt16IndexerPersist();
            if (type == DataType.Int32)
                return new Int32IndexerPersist();
            if (type == DataType.UInt32)
                return new UInt32IndexerPersist();
            if (type == DataType.Int64)
                return new Int64IndexerPersist();
            if (type == DataType.UInt64)
                return new UInt64IndexerPersist();
            if (type == DataType.Single)
                return new SingleIndexerPersist();
            if (type == DataType.Double)
                return new DoubleIndexerPersist();
            if (type == DataType.Decimal)
                return new DecimalIndexerPersist();
            if (type == DataType.String)
                return new StringIndexerPersist();
            if (type == DataType.DateTime)
                return new DateTimeIndexerPersist();
            if (type == DataType.ByteArray)
                return new ByteArrayIndexerPersist();

            throw new NotSupportedException(type.ToString());
        }

        private static IIndexerPersist[] GetDefaultPersists(DataType type)
        {
            if (type.IsPrimitive)
                return new IIndexerPersist[] { GetDefaultPersist(type) };

            if (type.IsSlotes)
                return type.Select(x => GetDefaultPersist(x)).ToArray();

            throw new NotSupportedException(type.ToString());
        }

        #region Examples

        private void StoreExample(BinaryWriter writer, Func<int, IData> values, int count)
        {
            Action[] actions = new Action[DataType.TypesCount];
            MemoryStream[] streams = new MemoryStream[DataType.TypesCount];

            //Int
            actions[0] = () =>
            {
                streams[0] = new MemoryStream();
                ((IIndexerPersist<Int32>)Persists[0]).Store(new BinaryWriter(streams[0]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot0; }, count);
            };

            //String
            actions[1] = () =>
            {
                streams[1] = new MemoryStream();
                ((IIndexerPersist<String>)Persists[1]).Store(new BinaryWriter(streams[1]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot1; }, count);
            };

            //Double
            actions[2] = () =>
            {
                streams[2] = new MemoryStream();
                ((IIndexerPersist<Double>)Persists[2]).Store(new BinaryWriter(streams[2]), (idx) => { return ((Data<int, string, double>)values(idx)).Slot2; }, count);
            };

            Parallel.Invoke(actions);

            for (int i = 0; i < DataType.TypesCount; i++)
            {
                var stream = streams[i];
                using (stream)
                {
                    CountCompression.Serialize(writer, checked((ulong)stream.Length));
                    writer.Write(stream.GetBuffer(), 0, (int)stream.Length);
                }
            }
        }

        private void LoadExample(BinaryReader reader, Action<int, IData> values, int count)
        {
            Data<int, string, double>[] array = new Data<int, string, double>[count];
            for (int i = 0; i < count; i++)
            {
                var data = new Data<int, string, double>();
                array[i] = data;
                values(i, data);
            }

            Action[] actions = new Action[DataType.TypesCount];
            byte[][] buffers = new byte[DataType.TypesCount][];

            for (int i = 0; i < DataType.TypesCount; i++)
                buffers[i] = reader.ReadBytes((int)CountCompression.Deserialize(reader));

            //Int32
            actions[0] = () =>
            {
                using (MemoryStream ms = new MemoryStream(buffers[0]))
                    ((IIndexerPersist<Int32>)Persists[0]).Load(new BinaryReader(ms), (idx, value) => { array[idx].Slot0 = value; }, count);
            };

            //String
            actions[1] = () =>
            {
                using (MemoryStream ms = new MemoryStream(buffers[1]))
                    ((IIndexerPersist<String>)Persists[0]).Load(new BinaryReader(ms), (idx, value) => { array[idx].Slot1 = value; }, count);
            };

            //Double
            actions[2] = () =>
            {
                using (MemoryStream ms = new MemoryStream(buffers[2]))
                    ((IIndexerPersist<Double>)Persists[0]).Load(new BinaryReader(ms), (idx, value) => { array[idx].Slot2 = value; }, count);
            };

            Parallel.Invoke(actions);
        }

        private void StoreExampleSingleSlot(BinaryWriter writer, Func<int, IData> values, int count)
        {
            //String
            using (MemoryStream ms = new MemoryStream())
            {
                ((IIndexerPersist<String>)Persists[0]).Store(new BinaryWriter(ms), (idx) => { return ((Data<string>)values(idx)).Slot0; }, count);
                CountCompression.Serialize(writer, checked((ulong)ms.Length));
                writer.Write(ms.GetBuffer(), 0, (int)ms.Length);
            }
        }

        private void LoadExampleSingleSlot(BinaryReader reader, Action<int, IData> values, int count)
        {
            byte[] buffer = reader.ReadBytes((int)CountCompression.Deserialize(reader));

            //String
            using (MemoryStream ms = new MemoryStream(buffer))
                ((IIndexerPersist<string>)Persists[0]).Load(new BinaryReader(ms), (idx, value) => { values(idx, new Data<string>(value)); }, count);
        }

        #endregion
    }
}
