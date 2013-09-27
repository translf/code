using STSdb4.General.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using STSdb4.General.Extensions;

namespace STSdb4.Data
{
    public static class DataTypeUtils
    {
        public static Type GetSlotDataType(DataType dataType)
        {
            if (dataType.IsPrimitive)
                return dataType.PrimitiveType;

            Type[] slotTypes = new Type[dataType.TypesCount];

            for (int i = 0; i < slotTypes.Length; i++)
                slotTypes[i] = DataTypeUtils.GetSlotDataType(dataType[i]);

            if (dataType.IsSlotes)
                return GetDataType(slotTypes);

            if (dataType.IsArray)
                return slotTypes[0].MakeArrayType();

            if (dataType.IsList)
                return typeof(List<>).MakeGenericType(slotTypes[0]);

            if (dataType.IsDictionary)
                return typeof(Dictionary<,>).MakeGenericType(slotTypes[0], slotTypes[1]);

            if (dataType.IsKeyValuePair)
                return typeof(KeyValuePair<,>).MakeGenericType(slotTypes[0], slotTypes[1]);

            throw new NotSupportedException(dataType.ToString());
        }

        public static Type GetDataType(DataType dataType)
        {
            Type slotType = DataTypeUtils.GetSlotDataType(dataType);

            if (dataType.IsSlotes)
                return slotType;

            return typeof(Data<>).MakeGenericType(slotType);
        }

        public static Type GetDataType(params Type[] slotTypes)
        {
            switch (slotTypes.Length)
            {
                case 01: return typeof(Data<>).MakeGenericType(slotTypes);
                case 02: return typeof(Data<,>).MakeGenericType(slotTypes);
                case 03: return typeof(Data<,,>).MakeGenericType(slotTypes);
                case 04: return typeof(Data<,,,>).MakeGenericType(slotTypes);
                case 05: return typeof(Data<,,,,>).MakeGenericType(slotTypes);
                case 06: return typeof(Data<,,,,,>).MakeGenericType(slotTypes);
                case 07: return typeof(Data<,,,,,,>).MakeGenericType(slotTypes);
                case 08: return typeof(Data<,,,,,,,>).MakeGenericType(slotTypes);
                case 09: return typeof(Data<,,,,,,,,>).MakeGenericType(slotTypes);
                case 10: return typeof(Data<,,,,,,,,,>).MakeGenericType(slotTypes);
                case 11: return typeof(Data<,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 12: return typeof(Data<,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 13: return typeof(Data<,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 14: return typeof(Data<,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 15: return typeof(Data<,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 16: return typeof(Data<,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 17: return typeof(Data<,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 18: return typeof(Data<,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 19: return typeof(Data<,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 20: return typeof(Data<,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 21: return typeof(Data<,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 22: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 23: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 24: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 25: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 26: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 27: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 28: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 29: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 30: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 31: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 32: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 33: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 34: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 35: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 36: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 37: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 38: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 39: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 40: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 41: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 42: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 43: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 44: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 45: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 46: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 47: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 48: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 49: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 50: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 51: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 52: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 53: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 54: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 55: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 56: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 57: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 58: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 59: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 60: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 61: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 62: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 63: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);
                case 64: return typeof(Data<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType(slotTypes);

                default:
                    throw new NotSupportedException("Invalid number of fields!");
            }
        }

        public static DataType FromPrimitiveTypes(params Type[] types)
        {
            if (types.Length == 1)
                return DataType.FromPrimitiveType(types[0]);
            else
                return DataType.Slotes(types.Select(x => DataType.FromPrimitiveType(x)).ToArray());
        }

        public static IEnumerable<MemberInfo> GetPublicMembers(Type type, Func<Type, MemberInfo, int> membersOrder)
        {
            var members = type.GetPublicReadWritePropertiesAndFields();
            if (membersOrder == null)
                return members;

            return members.Where(x => membersOrder(type, x) >= 0).OrderBy(x => membersOrder(type, x));
        }

        //public static DataType BuildType(Type type, Func<Type, MemberInfo, int> membersOrder)
        //{
        //    //TODO: cycleCheck

        //    if (DataType.IsPrimitiveType(type))
        //        return DataType.FromPrimitiveType(type);

        //    if (type.IsEnum)
        //        return DataType.FromPrimitiveType(type.GetEnumUnderlyingType());

        //    if (type.IsArray)
        //    {
        //        var t = BuildType(type.GetGenericArguments()[0], membersOrder);
        //        if (t == null)
        //            return null;

        //        return DataType.Array(t);
        //    }

        //    if (type.IsList())
        //    {
        //        var t = BuildType(type.GetGenericArguments()[0], membersOrder);
        //        if (t == null)
        //            return null;

        //        return DataType.List(t);
        //    }

        //    if (type.IsDictionary())
        //    {
        //        var generics = type.GetGenericArguments();

        //        var key = BuildType(generics[0], membersOrder);
        //        if (key == null)
        //            return null;

        //        var val = BuildType(generics[1], membersOrder);
        //        if (val == null)
        //            return null;

        //        return DataType.Dictionary(key, val);
        //    }

        //    List<DataType> slotes = new List<DataType>();

        //    foreach (var member in GetPublicMembers(type, membersOrder))
        //    {
        //        var memberType = member.GetPropertyOrFieldType();

        //        DataType slot = BuildType(memberType, membersOrder);
        //        if (slot != null)
        //            slotes.Add(slot);
        //    }

        //    if (slotes.Count == 0)
        //        return null;

        //    return DataType.Slotes(slotes.ToArray());
        //}

        //public static DataType BuildType(Type type)
        //{
        //    return BuildType(type, null);
        //}

        private static CompareOption GetDefaultCompareOption(this DataType type)
        {
            if (type == DataType.ByteArray)
                return new CompareOption(SortOrder.Ascending, ByteOrder.BigEndian);

            if (type == DataType.String)
                return new CompareOption(SortOrder.Ascending, false);

            return new CompareOption(SortOrder.Ascending);
        }

        public static CompareOption[] GetDefaultCompareOptions(this DataType type)
        {
            if (type.IsPrimitive)
                return new CompareOption[] { type.GetDefaultCompareOption() };

            if (type.IsSlotes && type.AreAllTypesPrimitive)
                return type.Select(x => x.GetDefaultCompareOption()).ToArray();

            throw new NotSupportedException(type.ToString());
        }

        private static void CheckCompareOption(this DataType type, CompareOption option)
        {
            if (!type.IsPrimitive)
                throw new NotSupportedException(String.Format("The type '{0}' is not primitive.", type));

            if (type == DataType.String)
            {
                if (option.ByteOrder != ByteOrder.Unspecified)
                    throw new ArgumentException("String can't have ByteOrder option.");
            }
            else if (type == DataType.ByteArray)
            {
                if (option.ByteOrder == ByteOrder.Unspecified)
                    throw new ArgumentException("byte[] must have ByteOrder option.");
            }
            else
            {
                if (option.ByteOrder != ByteOrder.Unspecified)
                    throw new ArgumentException(String.Format("{0} does not support ByteOrder option.", type));
            }
        }

        public static void CheckCompareOptions(this DataType type, params CompareOption[] options)
        {
            if (type.IsPrimitive)
            {
                if (options.Length != 1)
                    throw new ArgumentException("options");

                type.CheckCompareOption(options[0]);
                return;
            }

            if (type.IsSlotes)
            {
                if (options.Length != type.TypesCount)
                    throw new ArgumentException("options");

                for (int i = 0; i < type.TypesCount; i++)
                    type[i].CheckCompareOption(options[i]);
            }

            throw new NotSupportedException(type.ToString());
        }

        public static void CheckDataType(DataType dataType)
        {
            if (dataType.IsDictionary)
            {
                if (!dataType[0].IsPrimitive)
                    throw new Exception("Dictionarty<TKey, TValue> TKey is not primitive");

                CheckDataType(dataType[1]);
            }

            if (dataType.IsList || dataType.IsArray)
                CheckDataType(dataType[0]);

            if (dataType.IsKeyValuePair)
            {
                CheckDataType(dataType[0]);
                CheckDataType(dataType[1]);
            }

            if (dataType.IsSlotes)
            {
                for (int i = 0; i < dataType.TypesCount; i++)
                    CheckDataType(dataType[i]);
            }
        }
    }
}
