using System;
using DZCP.API;
using DZCP.API.Interfaces;
using DZCP.Logging;

namespace DZCP.Loader
{
    public static class PluginValidator
    {
        public static bool Validate(Type pluginType)
        {
            if (!typeof(IPlugin).IsAssignableFrom(pluginType))
            {
                Logger.Error($"Type {pluginType.Name} does not implement IPlugin");
                return false;
            }

            if (pluginType.GetConstructor(Type.EmptyTypes) == null)
            {
                Logger.Error($"Plugin {pluginType.Name} must have a parameterless constructor");
                return false;
            }

            return true;
        }
    }
}