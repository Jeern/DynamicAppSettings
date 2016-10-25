using System;
using System.Configuration;
using System.Dynamic;
using System.Globalization;

namespace FappSettings
{
    internal class AppSettingValues : DynamicObject
    {
        private readonly Type _propertyType;
        private readonly bool _allowNull;

        public AppSettingValues(Type propertyType, bool allowNull)
        {
            _propertyType = propertyType;
            _allowNull = allowNull;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string propertyName = binder.Name;
            string valueString = ConfigurationManager.AppSettings[propertyName];
            if (!_allowNull && string.IsNullOrWhiteSpace(valueString))
                throw new ConfigurationErrorsException($"You need to provide an AppSetting called {propertyName}");

            if (_propertyType == typeof(bool))
            {
                bool specificResult;
                if (!bool.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(int))
            {
                int specificResult;
                if (!int.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(double))
            {
                double specificResult;
                if (!double.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(float))
            {
                float specificResult;
                if (!float.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(decimal))
            {
                decimal specificResult;
                if (!decimal.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(DateTime))
            {
                DateTime specificResult;
                if (!DateTime.TryParse(valueString, CultureInfo.InvariantCulture, DateTimeStyles.None, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(TimeSpan))
            {
                TimeSpan specificResult;
                if (!TimeSpan.TryParse(valueString, CultureInfo.InvariantCulture, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType.IsEnum)
            {
                try
                {
                    result = Enum.Parse(_propertyType, valueString);
                }
                catch(Exception ex)
                {
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName), ex);
                }
            }
            else if (_propertyType == typeof(string))
            {
                result = valueString;
            }
            else
            {
                if (typeof(FappConfiguration).IsAssignableFrom(_propertyType))
                {
                    var instance = Activator.CreateInstance(_propertyType, true);
                    _propertyType.GetMethod("DoPopulate").Invoke(instance, new object[] { propertyName, valueString });
                    result = instance;
                }
                else
                {
                    throw new ConfigurationErrorsException($"FappSettings does not support values of type {_propertyType.Name}");
                }
            }
            return true;
        }

        private string TypeErrorText(string key)
        {
            return $"AppSettings key: {key} must be of type: {_propertyType.Name}";
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            throw new ConfigurationErrorsException("You cannot set an AppSetting value - only get is supported");
        }
    }
}
