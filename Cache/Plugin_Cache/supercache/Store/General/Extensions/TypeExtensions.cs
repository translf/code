using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace STSdb4.General.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsPrimitive && !type.IsEnum;
        }

        public static bool IsInheritInterface(this Type type, Type @interface)
        {
            if (!@interface.IsInterface)
                throw new ArgumentException(String.Format("The type '{0}' has to be an interface.", @interface.Name));

            foreach (var i in type.GetInterfaces())
            {
                if (i == @interface)
                    return true;
            }

            return false;
        }

        public static IEnumerable<MemberInfo> GetPublicReadWritePropertiesAndFields(this Type type)
        {
            foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                if (member.MemberType == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)member;
                    if (field.IsInitOnly)
                        continue;

                    yield return member;
                }

                if (member.MemberType == MemberTypes.Property)
                {
                    PropertyInfo property = (PropertyInfo)member;
                    if (property.GetAccessors(false).Length != 2)
                        continue;

                    yield return member;
                }
            }
        }

        public static Type GetPropertyOrFieldType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property: return ((PropertyInfo)member).PropertyType;
                case MemberTypes.Field: return ((FieldInfo)member).FieldType;
                default:
                    throw new NotSupportedException(member.MemberType.ToString());
            }
        }

        public static bool IsDictionary(this Type type)
        {
            return type.Name == typeof(Dictionary<,>).Name;
        }

        public static bool IsList(this Type type)
        {
            return type.Name == typeof(List<>).Name;
        }
    }
}
