using STSdb4.General.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace STSdb4.Data
{
    /// <summary>
    /// <para>DataTransformer is responsible to transforms instance of user type T from and to IData instance. DataTransformer supports the following types of T:</para>
    /// <para>1. Primitive types - Boolean, Char, SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64, Single, Double, Decimal, DateTime, String, byte[]</para>
    /// <para>2. Classes and structures with default constructor, containing public read/write properties and/or fields with types from 1.</para>
    /// <para>3. Classes and structures with default constructor, containing public read/write properties and/or fields with types from 1. and/or from 2.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTransformer<T> : IDataTransformer<T>
    {
        private Func<T, IData> toIData;
        private Func<IData, T> fromIData;

        private Type[] slotTypes;
        private Type Type;
        public DataType DataType { get; private set; }

        public Func<Type, MemberInfo, int> MembersOrder { get; private set; }

        public Expression<Func<T, IData>> LambdaToIData { get; private set; }
        public Expression<Func<IData, T>> LambdaFromIData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="membersOrder">Defines the declaration order of each property and field (because it is not guaranteed by the typeof(T).GetMembers() method)</param>
        public DataTransformer(Func<Type, MemberInfo, int> membersOrder)
        {
            if (!DataType.IsPrimitiveType(typeof(T)) && typeof(T).IsClass && typeof(T).GetConstructor(new Type[] { }) == null)
                    throw new NotSupportedException(String.Format("Type '{0}' does not have a default constructor", typeof(T)));

            MembersOrder = membersOrder;

            List<Type> list = new List<Type>();
            BuildSlotTypes(list, typeof(T), new HashSet<Type>());
            slotTypes = list.ToArray();

            if (slotTypes.Length == 0)
                throw new ArgumentException(String.Format("No public read/write properties/fields available for mapping."));

            Type = DataTypeUtils.GetDataType(slotTypes);
            DataType = DataTypeUtils.FromPrimitiveTypes(slotTypes);

            LambdaToIData = CreateToIDataMethod();
            toIData = LambdaToIData.Compile();

            LambdaFromIData = CreateFromIDataMethod();
            fromIData = LambdaFromIData.Compile();
        }

        public DataTransformer()
            :this(null)
        {
        }

        private IEnumerable<MemberInfo> GetPublicMembers(Type type)
        {
            return DataTypeUtils.GetPublicMembers(type, MembersOrder);
        }

        private void BuildSlotTypes(List<Type> list, Type type, HashSet<Type> cycleCheck)
        {
            if (DataType.IsPrimitiveType(type))
                list.Add(type);
            else if (type.IsEnum)
                list.Add(type.GetEnumUnderlyingType());
            else
            {
                foreach (var m in GetPublicMembers(type))
                {
                    Type memberType = m.GetPropertyOrFieldType();
                    if (cycleCheck.Contains(memberType))
                        throw new NotSupportedException(String.Format("Type {0} has cycle declaration.", memberType));

                    if (DataType.IsPrimitiveType(memberType))
                        list.Add(memberType);
                    else if (memberType.IsEnum)
                        list.Add(memberType.GetEnumUnderlyingType());
                    else if (memberType.IsValueType)
                    {
                        cycleCheck.Add(memberType);
                        BuildSlotTypes(list, memberType, cycleCheck);
                        cycleCheck.Remove(memberType);
                    }
                    else if (memberType.IsClass)
                    {
                        if (memberType.GetConstructor(new Type[] { }) == null)
                            throw new NotSupportedException(String.Format("Type '{0}' does not have a default constructor", memberType));

                        List<Type> tmp = new List<Type>();

                        cycleCheck.Add(memberType);
                        BuildSlotTypes(tmp, memberType, cycleCheck);
                        cycleCheck.Remove(memberType);

                        if (tmp.Count > 0)
                        {
                            list.Add(typeof(bool));
                            list.AddRange(tmp);
                        }
                    }
                }
            }
        }

        private void BuildToIDataExpressions(List<Expression> expressions, Expression data, ref int slot, Expression item)
        {
            if (DataType.IsPrimitiveType(item.Type))
                expressions.Add(Expression.Assign(Expression.Field(data, "Slot" + slot++), item));
            else if (item.Type.IsEnum)
                expressions.Add(Expression.Assign(Expression.Field(data, "Slot" + slot++), Expression.Convert(item, item.Type.GetEnumUnderlyingType())));
            else if (!(item is MemberExpression))
            {
                foreach (var member in GetPublicMembers(item.Type))
                    BuildToIDataExpressions(expressions, data, ref slot, Expression.MakeMemberAccess(item, member));
            }
            else if (item.Type.IsValueType)
            {
                if ((item as MemberExpression).Member.MemberType == MemberTypes.Property)
                {
                    var variable = Expression.Variable(item.Type);

                    List<Expression> list = new List<Expression>();
                    list.Add(Expression.Assign(variable, item));
                    foreach (var member in GetPublicMembers(variable.Type))
                        BuildToIDataExpressions(list, data, ref slot, Expression.MakeMemberAccess(variable, member));

                    if (list.Count > 1)
                        expressions.Add(Expression.Block(new ParameterExpression[] { variable }, list));
                }
                else if ((item as MemberExpression).Member.MemberType == MemberTypes.Field)
                {
                    foreach (var member in GetPublicMembers(item.Type))
                        BuildToIDataExpressions(expressions, data, ref slot, Expression.MakeMemberAccess(item, member));
                }
            }
            else if (item.Type.IsClass)
            {
                var variable = Expression.Variable(item.Type);
                var dataSlot = Expression.Field(data, "Slot" + slot++);

                List<Expression> list = new List<Expression>();
                foreach (var member in GetPublicMembers(variable.Type))
                    BuildToIDataExpressions(list, data, ref slot, Expression.MakeMemberAccess(variable, member));

                if (list.Count == 0)
                    slot--;
                else
                {
                    var assign = Expression.Assign(variable, item);

                    list.Insert(0, Expression.Assign(dataSlot, Expression.Constant(true)));
                    var @if = Expression.IfThenElse(Expression.Equal(variable, Expression.Constant(null, variable.Type)),
                                Expression.Assign(dataSlot, Expression.Constant(false)),
                                Expression.Block(list));

                    expressions.Add(Expression.Block(new ParameterExpression[] { variable }, assign, @if));
                }
            }
        }

        private Expression<Func<T, IData>> CreateToIDataMethod()
        {
            var item = Expression.Parameter(typeof(T), "item");

            List<Expression> list = new List<Expression>();

            var data = Expression.Variable(Type, "data");
            list.Add(Expression.Assign(data, Expression.New(Type)));

            int slot = 0;
            BuildToIDataExpressions(list, data, ref slot, item);

            list.Add(Expression.Label(Expression.Label(Type), data));

            var body = Expression.Block(Type, new ParameterExpression[] { data }, list);

            return Expression.Lambda<Func<T, IData>>(body, item);
        }

        private void BuildFromIDataExpressions(List<Expression> expressions, Expression data, ref int slot, Expression item)
        {
            if (DataType.IsPrimitiveType(item.Type))
                expressions.Add(Expression.Assign(item, Expression.Field(data, "Slot" + slot++)));
            else if (item.Type.IsEnum)
                expressions.Add(Expression.Assign(item, Expression.Convert(Expression.Field(data, "Slot" + slot++), item.Type)));
            else if (!(item is MemberExpression))
            {
                foreach (var member in GetPublicMembers(item.Type))
                    BuildFromIDataExpressions(expressions, data, ref slot, Expression.MakeMemberAccess(item, member));
            }
            else if (item.Type.IsValueType)
            {
                if ((item as MemberExpression).Member.MemberType == MemberTypes.Property)
                {
                    var variable = Expression.Variable(item.Type);

                    List<Expression> list = new List<Expression>();
                    list.Add(Expression.Assign(variable, Expression.New(item.Type)));
                    foreach (var member in GetPublicMembers(variable.Type))
                        BuildFromIDataExpressions(list, data, ref slot, Expression.MakeMemberAccess(variable, member));
                    list.Add(Expression.Assign(item, variable));

                    if (list.Count > 2)
                        expressions.Add(Expression.Block(new ParameterExpression[] { variable }, list));
                }
                else if ((item as MemberExpression).Member.MemberType == MemberTypes.Field)
                {
                    foreach (var member in GetPublicMembers(item.Type))
                        BuildFromIDataExpressions(expressions, data, ref slot, Expression.MakeMemberAccess(item, member));
                }
            }
            else if (item.Type.IsClass)
            {
                var variable = Expression.Variable(item.Type);
                var dataSlot = Expression.Field(data, "Slot" + slot++);

                List<Expression> list = new List<Expression>();
                foreach (var member in GetPublicMembers(variable.Type))
                    BuildFromIDataExpressions(list, data, ref slot, Expression.MakeMemberAccess(variable, member));

                if (list.Count == 0)
                    slot--;
                else
                {
                    list.Insert(0, Expression.Assign(variable, Expression.New(item.Type)));
                    list.Add(Expression.Assign(item, variable));

                    var @if = Expression.IfThenElse(Expression.IsFalse(dataSlot),
                                Expression.Assign(item, Expression.Constant(null, item.Type)),
                                Expression.Block(new ParameterExpression[] { variable }, list));

                    expressions.Add(@if);
                }
            }
        }

        private Expression<Func<IData, T>> CreateFromIDataMethod()
        {
            var data = Expression.Parameter(typeof(IData), "data");

            List<Expression> list = new List<Expression>();

            var d = Expression.Variable(Type, "d");
            list.Add(Expression.Assign(d, Expression.Convert(data, Type)));

            var item = Expression.Variable(typeof(T), "item");
            if (!DataType.IsPrimitiveType(typeof(T)) && typeof(T).IsClass)
                list.Add(Expression.Assign(item, Expression.New(item.Type)));

            int slot = 0;
            BuildFromIDataExpressions(list, d, ref slot, item);

            list.Add(Expression.Label(Expression.Label(typeof(T)), item));

            var body = Expression.Block(typeof(T), new ParameterExpression[] { d, item }, list);

            return Expression.Lambda<Func<IData, T>>(body, data);
        }

        public IData ToIData(T item)
        {
            return toIData(item);
        }

        public T FromIData(IData data)
        {
            return fromIData(data);
        }
    }

    //public class Tick
    //{
    //    public string Symbol { get; set; }
    //    public DateTime Timestamp { get; set; }
    //    public Quotes Quotes { get; set; }
    //    public long Volume { get; set; }
    //    public Provider Provider { get; set; }
    //    public int ID { get; set; }
    //    public TickType Type { get; set; }

    //    public static int MembersOrder(Type type, MemberInfo member)
    //    {
    //        if (type == typeof(Tick))
    //        {
    //            switch (member.Name)
    //            {
    //                case "Symbol": return 1;
    //                case "Timestamp": return 2;
    //                case "Quotes": return 3;
    //                case "Volume": return 4;
    //                case "Provider": return 5;
    //                case "ID": return 6;
    //                case "Type": return 7;
    //            }
    //        }
    //        else if (type == typeof(Quotes))
    //        {
    //            switch (member.Name)
    //            {
    //                case "Bid": return 1;
    //                case "Ask": return 2;
    //            }
    //        }
    //        else if (type == typeof(Provider))
    //        {
    //            switch (member.Name)
    //            {
    //                case "Name": return 1;
    //                case "Website": return 2;
    //            }
    //        }

    //        return -1;
    //    }
    //}

    //public class Provider
    //{
    //    public string Name { get; set; }
    //    public string Website { get; set; }
    //}

    //public struct Quotes
    //{
    //    public double Bid { get; set; }
    //    public double Ask { get; set; }
    //}

    //public enum TickType : byte
    //{
    //    Forex,
    //    Futures,
    //    Stock
    //}

    //public class ExampleTransformer : IDataTransformer<Tick>
    //{
    //    public IData ToIData(Tick item)
    //    {
    //        Data<string, DateTime, double, double, long, bool, string, string, int, byte> data = new Data<string, DateTime, double, double, long, bool, string, string, int, byte>();

    //        data.Slot0 = item.Symbol;
    //        data.Slot1 = item.Timestamp;

    //        //if item.Quotes is property
    //        Quotes quotes = item.Quotes;
    //        data.Slot2 = quotes.Bid;
    //        data.Slot3 = quotes.Ask;

    //        ////if item.Quotes is field
    //        //data.Slot2 = item.Quotes.Bid;
    //        //data.Slot3 = item.Quotes.Ask;

    //        data.Slot4 = item.Volume;

    //        var provider = item.Provider;
    //        if (provider == null)
    //            data.Slot5 = false;
    //        else
    //        {
    //            data.Slot5 = true;
    //            data.Slot6 = provider.Name;
    //            data.Slot7 = provider.Website;
    //        }

    //        data.Slot8 = item.ID;
    //        data.Slot9 = (byte)item.Type;

    //        return data;
    //    }

    //    public Tick FromIData(IData data)
    //    {
    //        Data<string, DateTime, double, double, long, bool, string, string, int, byte> d = (Data<string, DateTime, double, double, long, bool, string, string, int, byte>)data;

    //        Tick item = new Tick();

    //        item.Symbol = d.Slot0;
    //        item.Timestamp = d.Slot1;

    //        //if item.Quotes is property
    //        Quotes quotes = new Quotes();
    //        quotes.Bid = d.Slot2;
    //        quotes.Ask = d.Slot3;
    //        item.Quotes = quotes;

    //        //if item.Quotes is field
    //        //item.Quotes.Bid = d.Slot2;
    //        //item.Quotes.Ask = d.Slot3;

    //        item.Volume = d.Slot4;

    //        if (!d.Slot5)
    //            item.Provider = null;
    //        else
    //        {
    //            var provider = new Provider();
    //            provider.Name = d.Slot6;
    //            provider.Website = d.Slot7;
    //            item.Provider = provider;
    //        }

    //        item.ID = d.Slot8;
    //        item.Type = (TickType)d.Slot9;

    //        return item;
    //    }

    //    public DataDescriptor DataDescriptor
    //    {
    //        get { return new DataDescriptor(typeof(string), typeof(DateTime), typeof(double), typeof(double), typeof(long), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(byte)); }
    //    }
    //}
}
