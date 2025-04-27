using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.NewEdition;
using DZCP;

namespace DZCP.Core
{
    public static class PluginsInjector
    {
        public static void LoadAllPlugins(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var dlls = Directory.GetFiles(folder, "*.dll");

            foreach (var dll in dlls)
            {
                var asm = Assembly.LoadFrom(dll);
                var pluginTypes = asm.GetTypes()
                    .Where(t => typeof(IDZCPPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in pluginTypes)
                {
                    try
                    {
                        var plugin = (IDZCPPlugin)Activator.CreateInstance(type);
                        plugin.OnEnabled();
                        Console.WriteLine($"✅ Plugin '{type.Name}' loaded!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Failed to load plugin {type.Name}: {ex.Message}");
                    }
                }
            }
        }
    }
}