using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.NewEdition;

namespace DZCP.Core.Core.DependencyInjection
{
    /// <summary>
    /// Manages initialization of the DZCP framework and loading of plugins and dependencies.
    /// </summary>
    public static class DZCPAssemblyLoader
    {
        private static Assembly _mainAssembly;

        /// <summary>
        /// Gets the main assembly for the game.
        /// </summary>
        public static Assembly MainAssembly
        {
            get
            {
                if (_mainAssembly == null)
                    _mainAssembly = typeof(DZCPCore).Assembly;
                return _mainAssembly;
            }
        }

        /// <summary>
        /// List of loaded plugins.
        /// </summary>
        public static Dictionary<Assembly, Dictionary<Type, IDZCPPlugin>> Plugins { get; } 
            = new Dictionary<Assembly, Dictionary<Type, IDZCPPlugin>>();

        /// <summary>
        /// List of loaded dependencies.
        /// </summary>
        public static HashSet<Assembly> Dependencies { get; } = new HashSet<Assembly>();

        /// <summary>
        /// Whether the loader has been initialized.
        /// </summary>
        public static bool IsInitialized { get; private set; } = false;

        /// <summary>
        /// Initializes the DZCP framework, loading plugins and dependencies.
        /// </summary>
        public static void Initialize()
        {
            if (IsInitialized)
                return;

            ServerConsole.AddLog("[DZCP] Initializing plugin loader...", ConsoleColor.Cyan);

            IsInitialized = true;

            DZCPCore.Instance.CreateDirectories();

            ServerConsole.AddLog("[DZCP] Loading dependencies...", ConsoleColor.Cyan);
            LoadDependencies(DZCPCore.Instance.DependenciesDir);

            ServerConsole.AddLog("[DZCP] Loading plugins...", ConsoleColor.Cyan);
            LoadPlugins(DZCPCore.Instance.PluginsDir);

            ServerConsole.AddLog("[DZCP] All plugins and dependencies loaded successfully!", ConsoleColor.Green);
        }

        /// <summary>
        /// Loads plugins from the specified directory.
        /// </summary>
        /// <param name="directory">The directory containing plugins.</param>
        private static void LoadPlugins(string directory)
        {
            if (!Directory.Exists(directory))
            {
                ServerConsole.AddLog($"[DZCP] Plugin directory not found: {directory}", ConsoleColor.Yellow);
                return;
            }

            var pluginFiles = Directory.GetFiles(directory, "*.dll");
            ServerConsole.AddLog($"[DZCP] Found {pluginFiles.Length} plugins to load.", ConsoleColor.Cyan);

            foreach (string pluginPath in pluginFiles)
            {
                if (!TryLoadAssembly(pluginPath, out var assembly))
                    continue;

                try
                {
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IDZCPPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IDZCPPlugin)Activator.CreateInstance(type);
                        if (!Plugins.ContainsKey(assembly))
                            Plugins[assembly] = new Dictionary<Type, IDZCPPlugin>();

                        Plugins[assembly][type] = plugin;
                        plugin.OnEnabled();
                        ServerConsole.AddLog($"[DZCP] Loaded plugin: {plugin.Name} v{plugin.Version}", ConsoleColor.Green);
                    }
                }
                catch (Exception ex)
                {
                    ServerConsole.AddLog($"[DZCP] Failed to load plugin from {pluginPath}: {ex.Message}", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Loads dependencies from the specified directory.
        /// </summary>
        /// <param name="directory">The directory containing dependencies.</param>
        private static void LoadDependencies(string directory)
        {
            if (!Directory.Exists(directory))
            {
                ServerConsole.AddLog($"[DZCP] Dependencies directory not found: {directory}", ConsoleColor.Yellow);
                return;
            }

            var dependencyFiles = Directory.GetFiles(directory, "*.dll");
            foreach (var dependencyPath in dependencyFiles)
            {
                if (!TryLoadAssembly(dependencyPath, out var assembly))
                    continue;

                Dependencies.Add(assembly);
                ServerConsole.AddLog($"[DZCP] Loaded dependency: {assembly.GetName().Name}", ConsoleColor.Blue);
            }
        }

        /// <summary>
        /// Attempts to load an assembly from the specified path.
        /// </summary>
        /// <param name="path">The path to the assembly.</param>
        /// <param name="assembly">The loaded assembly.</param>
        /// <returns>True if the assembly was loaded successfully; otherwise, false.</returns>
        private static bool TryLoadAssembly(string path, out Assembly assembly)
        {
            try
            {
                assembly = Assembly.Load(File.ReadAllBytes(path));
                return true;
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] Failed to load assembly from {path}: {ex.Message}", ConsoleColor.Red);
                assembly = null;
                return false;
            }
        }
    }
}