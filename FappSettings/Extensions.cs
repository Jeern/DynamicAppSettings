using System.Collections.Generic;

namespace FappSettings
{
    internal static class Extensions
    {
        public static bool IsNull<T>(this T t)
        {
            return EqualityComparer<T>.Default.Equals(t, default(T));
        }
    }
}