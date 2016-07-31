using System.Configuration;
using System.Dynamic;

namespace FappSettings
{
    internal class ConnectionStringValues : DynamicObject
    {
        private readonly bool _allowNull;

        public ConnectionStringValues(bool allowNull)
        {
            _allowNull = allowNull;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string propertyName = binder.Name;
            string connString = ConfigurationManager.ConnectionStrings[propertyName].ConnectionString;
            if (!_allowNull && string.IsNullOrWhiteSpace(connString))
                throw new ConfigurationErrorsException($"You need to provide a ConnectionString called {propertyName}");
            result = connString;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            throw new ConfigurationErrorsException("You cannot set a ConnectionString - only get is supported");
        }
    }
}
