using System;
using System.Configuration;

namespace FappSettings
{
    public abstract class FappConfiguration 
    {
        public void DoPopulate(string key, string value)
        {
            try
            {
                Populate(value);
            }
            catch(Exception ex)
            {
                throw new ConfigurationErrorsException($"The value {value} of the appSetting {key} is not in the correct format", ex);
            }
        }

        public abstract void Populate(string value);
    }
}
