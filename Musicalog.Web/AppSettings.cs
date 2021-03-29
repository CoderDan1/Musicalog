using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Musicalog.Web
{
    public static class AppSettings
    {

        public static int PageSize
        {
            get
            {
                return Setting("PageSize", 10);
            }
        }

        private static T Setting<T>(string name, T defaultValue)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                return defaultValue;
            }

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}