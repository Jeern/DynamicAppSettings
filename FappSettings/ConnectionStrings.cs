using System;

namespace FappSettings
{
    public static class ConnectionStrings
    {
        public static string ValueOf(Func<dynamic, string> func, bool allowNull = false)
        {
            return func(new ConnectionStringValues(allowNull));
        }
        public static bool TryValueOf(Func<dynamic, string> func, out string value)
        {
            value = func(new ConnectionStringValues(true));
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return true;
        }
    }
}
