using System;

namespace DynamicAppSettings
{
    public static class AppSettings
    {
        public static string ValueOf(Func<dynamic, string> func, bool allowNull = false)
        {
            return func(new AppSettingValues(typeof(string), allowNull));
        }
    }
    public static class AppSettings<T> where T : struct 
    {
        public static T ValueOf(Func<dynamic, T> func, bool allowNull = false)
        {
            return func(new AppSettingValues(typeof(T), allowNull));
        }
    }
}
