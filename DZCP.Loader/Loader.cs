using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using DZCP.API;
using DZCP.API.Interfaces;
using UnityEngine;

namespace DZCP.Loader
{
    public static class Loader
    {
        private static readonly List<IPlugin> _loadedPlugins = new();
        private static readonly DependencyResolver _resolver = new();

        public static IReadOnlyCollection<IPlugin> LoadedPlugins => _loadedPlugins.AsReadOnly();

        public static void LoadAll(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                return;
            }

            foreach (var file in Directory.GetFiles(directory, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        if (PluginValidator.Validate(type))
                        {
                            var plugin = (IPlugin)_resolver.CreateInstance(type);
                            _loadedPlugins.Add(plugin);
                            plugin.OnEnabled();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logging.Logger.Error($"Failed to load plugin from {Path.GetFileName(file)}: {ex}");
                }
            }
        }

        public static void UnloadAll()
        {
            foreach (var plugin in _loadedPlugins)
            {
                try
                {
                    plugin.OnDisabled();
                }
                catch (Exception ex)
                {
                    Logging.Logger.Error($"Error while disabling plugin {plugin.Name}: {ex}");
                }
            }
            _loadedPlugins.Clear();
        }
    }
}
