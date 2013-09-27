using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Com.SuperCache.Engine
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source != null)
            {
                foreach (var item in source)
                {
                    action(item);
                }
            }
        }

        public static string NormalizeFileName(this string FileName)
        {
            var result = FileName;
            Path.GetInvalidFileNameChars().ForEach(c =>
                {
                    result = result.Replace(c.ToString(), string.Empty);
                });
            return result;
        }
    }
}
