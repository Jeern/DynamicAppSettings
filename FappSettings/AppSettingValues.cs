using System;
using System.Configuration;
using System.Dynamic;

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
                if(!bool.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if(_propertyType == typeof(int))
            {
                int specificResult;
                if (!int.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(double))
            {
                double specificResult;
                if (!double.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(float))
            {
                float specificResult;
                if (!float.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(decimal))
            {
                decimal specificResult;
                if (!decimal.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(DateTime))
            {
                DateTime specificResult;
                if (!DateTime.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(TimeSpan))
            {
                TimeSpan specificResult;
                if (!TimeSpan.TryParse(valueString, out specificResult))
                    throw new ConfigurationErrorsException(TypeErrorText(propertyName));
                result = specificResult;
            }
            else if (_propertyType == typeof(string))
            {
                result = valueString;
            }
            else
            {
                throw new ConfigurationErrorsException($"Dynamic AppSettings does not support values of type {_propertyType.Name}");
            }
            return true;
        }

        public string TypeErrorText(string key)
        {
            return $"AppSettings key: {key} must be of type: {_propertyType.Name}";
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            throw new ConfigurationErrorsException("You cannot set an AppSetting value - only get is supported");
        }
    }
}
