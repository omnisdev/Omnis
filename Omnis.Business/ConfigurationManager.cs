// -----------------------------------------------------------------------
// <copyright file="ConfigurationManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Omnis.Business
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class ConfigManager
    {
        public static object GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
