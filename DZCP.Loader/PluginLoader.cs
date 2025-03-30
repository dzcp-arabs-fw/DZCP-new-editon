using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.API;

namespace DZCP.Loader
{
    public static class PluginLoader
    {
        public static List<IPlugin> LoadAll(string pluginsDir)
        {
            var plugins = new List<IPlugin>();
            
            if (!Directory.Exists(pluginsDir))
                Directory.CreateDirectory(pluginsDir);
            
            foreach (var dll in Directory.GetFiles(pluginsDir, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dll);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsAbstract)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DZCP] Failed to load {dll}: {ex.Message}");
                }
            }
            
            return plugins;
        }
    }
}