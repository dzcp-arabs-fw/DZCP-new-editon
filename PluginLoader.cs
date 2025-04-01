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
        private static readonly string DZCPRoot = "DZCP";
        private static readonly string PluginsDir = Path.Combine(DZCPRoot, "PLUGINS");
        private static readonly string ConfigsDir = Path.Combine(DZCPRoot, "CONFIGS");
        private static readonly string LogsDir = Path.Combine(DZCPRoot, "LOGS");
        private static readonly string DependenciesDir = Path.Combine(DZCPRoot, "DEPENDENCIES");

        public static List<IPlugin> LoadAll()
        {
            CreateRequiredDirectories();

            var plugins = new List<IPlugin>();

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll"))
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
                            Console.WriteLine($"[DZCP] ✅ Loaded Plugin: {plugin.Name} | Version: {plugin.Version}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError($"[DZCP] ❌ Failed to load {dll}: {ex.Message}");
                }
            }

            return plugins;
        }

        private static void CreateRequiredDirectories()
        {
            CreateDirectory(DZCPRoot);
            CreateDirectory(PluginsDir);
            CreateDirectory(ConfigsDir);
            CreateDirectory(LogsDir);
            CreateDirectory(DependenciesDir);
        }

        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"[DZCP] 📂 Created directory: {path}");
            }
        }

        private static void LogError(string message)
        {
            string logFilePath = Path.Combine(LogsDir, "errors.log");
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
            Console.WriteLine(message);
        }
    }
}
