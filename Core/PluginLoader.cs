using DZCP.API.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.API;

namespace DZCP.Core
{
    public static class PluginLoaderDzcp
    {
        public static void LoadPlugins(string pluginsPath)
        {
            if (!Directory.Exists(pluginsPath))
                Directory.CreateDirectory(pluginsPath);

            foreach (var dll in Directory.GetFiles(pluginsPath, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(dll);
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    plugin.OnEnable();
                }
            }
        }
    }
}