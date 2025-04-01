using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using DZCP.API;
using DZCP.Loader;
using DZCP.Logging;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;

namespace DZCP.NewEdition
{
    public class DZCPCore
    {
        public static DZCPCore Instance { get; private set; }

        // هيكل المجلدات
        public readonly string BaseDir = Path.Combine(Environment.CurrentDirectory, "DZCP");
        public string PluginsDir;
        public string ConfigsDir;
        public string LogsDir;
        public string PatchesDir;

        public List<IDZCPPlugin> LoadedPlugins { get; } = new List<IDZCPPlugin>();
        public List<IDZCPPatch> LoadedPatches { get; } = new List<IDZCPPatch>();

        [PluginEntryPoint("DZCP New Edition", "2.5.0", "Advanced Framework for SCP:SL", "DZCP Team:MONCEF50G")]
        public void Initialize()
        {
            Instance = this;

            // تهيئة المسارات
            PluginsDir = Path.Combine(BaseDir, "Plugins");
            ConfigsDir = Path.Combine(BaseDir, "Configs");
            LogsDir = Path.Combine(BaseDir, "Logs");
            PatchesDir = Path.Combine(BaseDir, "Patches");

            try
            {
                // عرض شعار النظام
                DZCPBanner.Display();

                // إنشاء الهيكل الأساسي
                CreateDirectories();

                // تحميل الباتشات
                LoadPatches();

                // تحميل الملحقات
                LoadPlugins();

                ServerConsole.AddLog("[DZCP] Frame loaded successfully!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] Configuration error: {ex}", ConsoleColor.Red);
            }
        }

        private void CreateDirectories()
        {
            Directory.CreateDirectory(BaseDir);
            Directory.CreateDirectory(PluginsDir);
            Directory.CreateDirectory(ConfigsDir);
            Directory.CreateDirectory(LogsDir);
            Directory.CreateDirectory(PatchesDir);
        }

        private void LoadPatches()
        {
            if (!Directory.Exists(PatchesDir)) return;

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var patchTypes = assembly.GetTypes()
                        .Where(t => typeof(IDZCPPatch).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in patchTypes)
                    {
                        var patch = (IDZCPPatch)Activator.CreateInstance(type);
                        patch.Apply();
                        LoadedPatches.Add(patch);
                        ServerConsole.AddLog($"[DZCP] The patch has been loaded: {patch.Name}", ConsoleColor.Blue);
                    }
                }
                catch (Exception ex)
                {
                    ServerConsole.AddLog($"[DZCP] Error loading patch: {ex.Message}", ConsoleColor.DarkRed);
                }
            }
        }
        public static void loadpluginfile()
        {
            ServerConsole.AddLog("[PluginLoader] Searching for plugins...");
            ServerConsole.AddLog("[PluginLoader] Searching for plugins...", ConsoleColor.Yellow);

            var pluginFiles = Directory.GetFiles( "*.dll");

            if (!pluginFiles.Any())
            {
                ServerConsole.AddLog("[PluginLoader] No plugins found.");
                ServerConsole.AddLog("[PluginLoader] No plugins found.", ConsoleColor.Red);
                return;
            }

            foreach (var pluginFile in pluginFiles)
            {
                loadpluginfile();
            }

            ServerConsole.AddLog("✅ [PluginLoader] All plugins loaded successfully!", ConsoleColor.Green);
        }
        private void LoadPlugins()
        {
            if (!Directory.Exists(PluginsDir))
            {
                ServerConsole.AddLog("[DZCP] Extensions folder not found!", ConsoleColor.Yellow);
                return;
            }

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IDZCPPlugin).IsAssignableFrom(t) && !t.IsAbstract);
                    ServerConsole.AddLog($"🔄 [PluginLoader] Loading plugin: {pluginTypes.FirstOrDefault()}");
                    ServerConsole.AddLog($"🔄 [PluginLoader] Loading plugin: {PluginsDir}", ConsoleColor.Green);


                    ServerConsole.AddLog("[PluginLoader] Searching for plugins...");
                    ServerConsole.AddLog("[PluginLoader] Searching for plugins...", ConsoleColor.Yellow);
                    var pluginFiles = Directory.GetFiles(PluginsDir, "*.dll");
                    if (!pluginFiles.Any())
                    {
                        ServerConsole.AddLog("[PluginLoader] No plugins found.");
                        ServerConsole.AddLog("[PluginLoader] No plugins found.", ConsoleColor.Red);
                        return;
                    }



                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IDZCPPlugin)Activator.CreateInstance(type);
                        ServerConsole.AddLog("✅ [PluginLoader] All plugins loaded successfully!", ConsoleColor.Green);

                        plugin.OnEnabled();
                        LoadedPlugins.Add(plugin);
                        ServerConsole.AddLog($"[DZCP] Loaded: {plugin.Name} v{plugin.Version}", ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    ServerConsole.AddLog($"[DZCP] Error loading {Path.GetFileName(dll)}: {ex.Message}", ConsoleColor.Red);
                }
            }
        }
    }

    public static class DZCPBanner
    {
        public static void Display()
        {
            try
            {
                var banner = new[]
                {
                    " ",
                    "██████╗ ███████╗ ██████╗██████╗     ███╗   ██╗███████╗██╗    ██╗",
                    " ██╔══██╗╚══███╔╝██╔════╝██╔══██╗    ████╗  ██║██╔════╝██║    ██║",
                    " ██║  ██║  ███╔╝ ██║     ██████╔╝    ██╔██╗ ██║█████╗  ██║ █╗ ██║",
                    " ██║  ██║ ███╔╝  ██║     ██╔═══╝     ██║╚██╗██║██╔══╝  ██║███╗██║",
                    " ██████╔╝███████╗╚██████╗██║         ██║ ╚████║███████╗╚███╔███╔╝",
                    " ╚═════╝ ╚══════╝ ╚═════╝╚═╝         ╚═╝  ╚═══╝╚══════╝ ╚══╝╚══╝ ",

                    " ",
                    " DZCP New Edition Framework v2.5.0",
                    " =====================================",
                    "Created by DZCP - devloper:MONCEF50G",
                    " =====================================",
                    $" Loaded at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                    " "
                };

                foreach (var line in banner)
                {
                    var color = line.Contains("█") ? ConsoleColor.DarkMagenta :
                              line.Contains("===") ? ConsoleColor.Gray : ConsoleColor.Yellow;

                    ServerConsole.AddLog(line, color);
                }
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[BANNER ERROR] {ex.Message}", ConsoleColor.Red);
            }
        }
    }

    public interface IDZCPPlugin
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        void OnEnabled();
        void OnDisabled();
    }

    public interface IDZCPPatch
    {
        string Name { get; }
        void Apply();
        void Unapply();
    }
}
