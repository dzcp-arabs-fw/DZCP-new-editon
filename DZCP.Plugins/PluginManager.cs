using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.API;
using DZCP.API.Interfaces;
using DZCP.Logging;

namespace DZCP.Plugins
{
    public class PluginManager
    {
        private readonly List<IPlugin> _loadedPlugins = new();
        private readonly string _pluginsDirectory;

        public IReadOnlyCollection<IPlugin> LoadedPlugins => _loadedPlugins.AsReadOnly();

        public PluginManager(string pluginsDirectory)
        {
            _pluginsDirectory = pluginsDirectory;
        }

        public void LoadAll()
        {
            if (!Directory.Exists(_pluginsDirectory))
            {
                Directory.CreateDirectory(_pluginsDirectory);
                return;
            }

            foreach (var file in Directory.GetFiles(_pluginsDirectory, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsAbstract)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            _loadedPlugins.Add(plugin);
                            plugin.OnEnabled();
                            Logger.Info($"Loaded plugin: {plugin.Name} v{plugin.Version}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to load plugin {Path.GetFileName(file)}: {ex}");
                }
            }
        }

        public void UnloadAll()
        {
            foreach (var plugin in _loadedPlugins)
            {
                try
                {
                    plugin.OnDisabled();
                    Logger.Info($"Unloaded plugin: {plugin.Name}");
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error while unloading plugin {plugin.Name}: {ex}");
                }
            }
            _loadedPlugins.Clear();
        }

        public T GetPlugin<T>() where T : IPlugin
        {
            return _loadedPlugins.OfType<T>().FirstOrDefault();
        }
    }
}