using System;
using System.IO;
using System.Linq;
using System.Reflection;
using PluginAPI.Loader.Features;
using System.Collections.Generic;
using DZCP_Loader;
using DZCP.API;
using DZCP.API.Interfaces;
using PluginAPI.Core.Attributes;
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
            [PluginEntryPoint("DZCP Loader", "1.0.0", "Advanced plugin loader", "YourName")]
            void LoadPlugin()
            {
                // عرض البانر
                ConsoleBannerShow.DisplayBanner();

                // تحميل الملحقات...

                // عرض الملخص
                ConsoleBannerShow.DisplayLoadSummary(
                    LoadedPlugins.Count,
                    LoadedPlugins.Select(p => p.Name).ToList()
                );
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
                            plugin.OnEnable();
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
                    plugin.OnDisable();
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
