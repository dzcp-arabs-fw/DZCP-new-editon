// DZCP/Utilities/VersionHelper.cs
using System;
using System.Reflection;

namespace DZCP.Utilities
{
    public static class VersionHelper
    {
        public static Version GetLocalVersion(string pluginName)
        {
            foreach (var plugin in Loader.Loader.LoadedPlugins)
            {
                if (plugin.Name.Equals(pluginName, StringComparison.OrdinalIgnoreCase))
                {
                    return plugin.Version;
                }
            }
            return new Version(0, 0, 0);
        }
    }
}
