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

        public static T ValueOf<T>(Func<dynamic, IFappConfiguration<T>> func, bool allowNull = false) where T : IFappConfiguration<T>
        {
            var configuration = func(new AppSettingValues(typeof(IFappConfiguration<T>), allowNull));
            return configuration.Parse(configuration.Key);
        }

        public static bool TryValueOf<T>(Func<dynamic, IFappConfiguration<T>> func, out T value) where T : IFappConfiguration<T>
        {
            var configuration = func(new AppSettingValues(typeof(IFappConfiguration<T>), true));
            value = configuration.Parse(configuration.Key);
            if (value.IsNull())
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
