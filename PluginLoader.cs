using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Commands;
using DZCP.Logging;
using CommandSystem;
using DZCP_new_editon;
using DZCP.Logging;

namespace PluginFramework
{
    public class PluginLoader
    {
        private static readonly string PluginsDirectory = "Plugins";
        private static readonly string ConfigsDirectory = "Configs";
        private static readonly string LogsDirectory = "Logs";
        private static readonly Dictionary<string, IPlugin> LoadedPlugins = new Dictionary<string, IPlugin>();

        /// <summary>
        /// Entry point for the PluginLoader.
        /// </summary>
        [PluginEntryPoint("PluginLoader", "2.1.0", "Custom Plugin Loader for SCP:SL", "Kloer26 & MONCEF50G")]
        public void Init()
        {
            try
            {
                ServerConsole.AddLog("⚡ [PluginLoader] Plugin Loader has been initialized!", ConsoleColor.Cyan);
                Logger.Info("🚀 [PluginLoader] Plugin Loader has started!");

                InitializeDirectories();
                LoadPlugins();
            }
            catch (Exception ex)
            {
                Logger.Error($"❌ [PluginLoader] Error during initialization: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates necessary directories if they don't exist.
        /// </summary>
        private static void InitializeDirectories()
        {
            CreateDirectory(PluginsDirectory);
            CreateDirectory(ConfigsDirectory);
            CreateDirectory(LogsDirectory);
        }

        /// <summary>
        /// Creates a directory at the specified path.
        /// </summary>
        /// <param name="path">The path of the directory to create.</param>
        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
               Logger.Info($"📂 [PluginLoader] Created directory: {path}");
            }
        }

        /// <summary>
        /// Registers server commands for plugin management.
        /// </summary>

        /// <summary>
        /// Loads all plugins from the Plugins directory.
        /// </summary>
        public static void LoadPlugins()
        {
            Logger.Info("[PluginLoader] Searching for plugins...");
            ServerConsole.AddLog("[PluginLoader] Searching for plugins...", ConsoleColor.Yellow);

            var pluginFiles = Directory.GetFiles(PluginsDirectory, "*.dll");

            if (!pluginFiles.Any())
            {
                Logger.Warn("[PluginLoader] No plugins found.");
                ServerConsole.AddLog("[PluginLoader] No plugins found.", ConsoleColor.Red);
                return;
            }

            foreach (var pluginFile in pluginFiles)
            {
                LoadPlugin(pluginFile);
            }
        }

        /// <summary>
        /// Loads a single plugin from the specified file path.
        /// </summary>
        /// <param name="pluginFile">The path to the plugin DLL file.</param>
        private static void LoadPlugin(string pluginFile)
        {
            try
            {
                // Retrieve file metadata
                var fileInfo = new FileInfo(pluginFile);
                var creationTime = fileInfo.CreationTime;
                var modificationTime = fileInfo.LastWriteTime;
                var fileSize = fileInfo.Length / 1024.0; // Size in KB

                Logger.Info($"🔄 [PluginLoader] Loading plugin: {pluginFile}");
                Logger.Info($"   - Created: {creationTime:yyyy-MM-dd HH:mm:ss}");
                Logger.Info($"   - Modified: {modificationTime:yyyy-MM-dd HH:mm:ss}");
                Logger.Info($"   - Size: {fileSize:F2} KB");
                ServerConsole.AddLog($"🔄 [PluginLoader] Loading plugin: {pluginFile}", ConsoleColor.Green);

                var assembly = Assembly.LoadFrom(pluginFile);
                var pluginTypes = assembly.GetTypes()
                    .Where(type => typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

                foreach (var type in pluginTypes)
                {
                    var pluginInstance = (IPlugin)Activator.CreateInstance(type);
                    if (LoadedPlugins.ContainsKey(pluginInstance.Name))
                    {
                        Logger.Warn($"⚠ [PluginLoader] Plugin {pluginInstance.Name} is already loaded. Skipping.");
                        continue;
                    }
                    pluginInstance.OnEnable();
                    LoadedPlugins[pluginInstance.Name] = pluginInstance;

                    Logger.Warn($"✅ [PluginLoader] Plugin loaded: {pluginInstance.Name} - Version {pluginInstance.Version}");
                    ServerConsole.AddLog($"✅ [PluginLoader] Plugin loaded: {pluginInstance.Name} - Version {pluginInstance.Version}", ConsoleColor.Green);
                }
            }
            catch (Exception ex)
            {
                Logger.Warn($"❌ [PluginLoader] Error loading plugin {pluginFile}: {ex.Message}");
                ServerConsole.AddLog($"❌ [PluginLoader] Error loading plugin {pluginFile}: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Unloads a single plugin by name.
        /// </summary>
        /// <param name="pluginName">The name of the plugin to unload.</param>
        /// <returns>True if the plugin was unloaded successfully, false otherwise.</returns>
        private static bool UnloadPlugin(string pluginName)
        {
            if (!LoadedPlugins.TryGetValue(pluginName, out var plugin))
            {
                Logger.Warn($"⚠ [PluginLoader] Plugin {pluginName} is not loaded.");
                return false;
            }

            try
            {
                var onUnloadMethod = plugin.GetType().GetMethod("OnUnload");
                if (onUnloadMethod != null)
                {
                    onUnloadMethod.Invoke(plugin, null);
                    Logger.Info($"🛑 [PluginLoader] Plugin unloaded: {pluginName}");
                    ServerConsole.AddLog($"🛑 [PluginLoader] Plugin unloaded: {pluginName}", ConsoleColor.Yellow);
                }
                else
                {
                    Logger.Warn($"⚠ [PluginLoader] Plugin {pluginName} does not implement OnUnload.");
                }
                LoadedPlugins.Remove(pluginName);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn($"❌ [PluginLoader] Error unloading plugin {pluginName}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Unloads all loaded plugins.
        /// </summary>
        public static void UnloadPlugins()
        {
            foreach (var plugin in LoadedPlugins.Values)
            {
                try
                {
                    var onUnloadMethod = plugin.GetType().GetMethod("OnUnload");
                    if (onUnloadMethod != null)
                    {
                        onUnloadMethod.Invoke(plugin, null);
                        Logger.Info($"🛑 [PluginLoader] Plugin unloaded: {plugin.Name}");
                        ServerConsole.AddLog($"🛑 [PluginLoader] Plugin unloaded: {plugin.Name}", ConsoleColor.Yellow);
                    }
                    else
                    {
                        Logger.Warn($"⚠ [PluginLoader] Plugin {plugin.Name} does not implement OnUnload.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"❌ [PluginLoader] Error unloading plugin {plugin.Name}: {ex.Message}");
                }
            }
            LoadedPlugins.Clear();
        }
    }
}