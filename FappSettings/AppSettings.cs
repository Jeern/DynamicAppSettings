using System;

namespace FappSettings
{
    public static class AppSettings
    {
        public static string ValueOf(Func<dynamic, string> func, bool allowNull = false)
        {
            return func(new AppSettingValues(typeof(string), allowNull));
        }
        public static bool TryValueOf(Func<dynamic, string> func, out string value)
        {
            value = func(new AppSettingValues(typeof(string), true));
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return true;
        }
    }
    public static class AppSettings<T> where T : struct 
    {
        public static T ValueOf(Func<dynamic, T> func, bool allowNull = false)
        {
            return func(new AppSettingValues(typeof(T), allowNull));
        }
        public static bool TryValueOf(Func<dynamic, T> func, out T value)
        {
            value = func(new AppSettingValues(typeof(T), true));
            if (value.IsNull())
                return false;
            return true;
        }
    }
}
