using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.Logging;
using DZCP.Tools;
using HarmonyLib;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Loader
{
    public class DZCPLoaderConsol : IPlugin
    {
        public static DZCPLoaderConsol Instance { get; private set; }
        
        // Directory paths
        public static readonly string BaseDir = Path.Combine(Environment.CurrentDirectory, "DZCP");
        public readonly string PluginsDir = Path.Combine(BaseDir, "Plugins");
        public readonly string ConfigsDir = Path.Combine(BaseDir, "Configs");
        public readonly string DependenciesDir = Path.Combine(BaseDir, "Dependencies");
        public readonly string LogsDir = Path.Combine(BaseDir, "Logs");
        public readonly string PatchesDir = Path.Combine(BaseDir, "Patches");

        // Collections
        public List<DZCP_new_editon.IPlugin> LoadedPlugins { get; } = new();
        public List<IPatch> LoadedPatches { get; } = new();
        public Harmony HarmonyInstance { get; private set; }

        // Status
        public bool IsInitialized { get; private set; }

        // Plugin metadata
        public string Name => "DZCP New Edition";
        public string Author => "MONCEF50G";
        public Version Version => new Version("2.0.0");
        public string Description => "Advanced plugin framework for SCP:SL";

        [PluginEntryPoint("DZCP New Edition", "2.0.0", "Advanced plugin framework for SCP:SL", "MONCEF50G")]
        public void OnEnable()
        {
            Instance = this;

            void OnEnabled()
            {
                // تهيئة نظام المسارات
                PathManager.Initialize("DZCP");
                string pluginName = Name; // أو اسم ثابت مثلاً "RankPlugin"

                string myPluginDir = PathManager.GetPluginPath(pluginName);
                string myConfigs = PathManager.GetPluginConfigPath(pluginName);
                string myLogs = PathManager.GetPluginLogsPath(pluginName);

                // مثال على استخدامه
                File.WriteAllText(Path.Combine(myLogs, "startup.log"), "البلغن اشتغل!");
                // مثال: إنشاء مسارات خاصة ببلغن محدد
                string pluginFolder = PathManager.GetPluginPath("MyPlugin");
                string configFolder = PathManager.GetPluginConfigPath("MyPlugin");
                string logsFolder = PathManager.GetPluginLogsPath("MyPlugin");

                Logger.Info("تم تهيئة نظام المسارات بنجاح!");
            }

            Initialize();
        }

        public void OnDisable()
        {
            SafeExecute(() => 
            {
                foreach (var plugin in LoadedPlugins)
                {
                    plugin.OnDisable();
                }
                
                foreach (var patch in LoadedPatches)
                {
                    patch.Unapply();
                }
                
                Log("تم إيقاف جميع البلغنات والباتشات", LogLevel.Info);
            });
        }

        public void Initialize()
        {
            if (IsInitialized) return;

            SafeExecute(() =>
            {
                CreateDirectories();
                ShowConsoleBanner();
                LoadDependencies();
                InitializeHarmony();
                LoadPatches();
                LoadPlugins();

                IsInitialized = true;
                Log("تم تهيئة DZCP بنجاح!", LogLevel.Info);
            }, 
            "فشل التهيئة");
        }

        private void CreateDirectories()
        {
            Directory.CreateDirectory(BaseDir);
            Directory.CreateDirectory(PluginsDir);
            Directory.CreateDirectory(ConfigsDir);
            Directory.CreateDirectory(DependenciesDir);
            Directory.CreateDirectory(LogsDir);
            Directory.CreateDirectory(PatchesDir);
        }

        private void ShowConsoleBanner()
        {
            var bannerLines = new[]
            {
                "██████╗ ███████╗ ██████╗██████╗     ███╗   ██╗███████╗██╗    ██╗",
                "██╔══██╗██╔════╝██╔════╝██╔══██╗    ████╗  ██║██╔════╝██║    ██║",
                "██║  ██║█████╗  ██║     ██████╔╝    ██╔██╗ ██║█████╗  ██║ █╗ ██║",
                "██║  ██║██╔══╝  ██║     ██╔═══╝     ██║╚██╗██║██╔══╝  ██║███╗██║",
                "██████╔╝███████╗╚██████╗██║         ██║ ╚████║███████╗╚███╔███╔╝",
                "╚═════╝ ╚══════╝ ╚═════╝╚═╝         ╚═╝  ╚═══╝╚══════╝ ╚══╝╚══╝",
                "",
                $"DZCP New Edition - SCP:SL Plugin Framework  -ﻦﻴﻄﺴﻠﻓ ﺎﻴﺤﺗ  v{Version}",
                $"Loaded at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                "=============================================="
            };

            foreach (var line in bannerLines)
            {
                Log(line, LogLevel.Info);
            }
        }

        private void LoadDependencies()
        {
            Log("جارٍ تحميل التبعيات...", LogLevel.Debug);

            var harmonyPath = Path.Combine(DependenciesDir, "0Harmony.dll");
            if (!File.Exists(harmonyPath))
            {
                Log("لم يتم العثور على مكتبة Harmony المطلوبة!", LogLevel.Error);
                throw new FileNotFoundException("0Harmony.dll not found in Dependencies folder!");
            }

            SafeExecute(() => 
            {
                Assembly.LoadFrom(harmonyPath);
                Log("تم تحميل مكتبة Harmony بنجاح", LogLevel.Info);
            });

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll")
                .Where(x => !x.EndsWith("0Harmony.dll")))
            {
                SafeExecute(() => 
                {
                    Assembly.LoadFrom(dll);
                    Log($"تم تحميل التبعية: {Path.GetFileName(dll)}", LogLevel.Debug);
                });
            }
        }

        private void InitializeHarmony()
        {
            SafeExecute(() => 
            {
                HarmonyInstance = new Harmony("dzcp.newedition");
                Log("تم تهيئة Harmony بنجاح", LogLevel.Info);
            });
        }

        private void LoadPatches()
        {
            Log("جارٍ تحميل الباتشات...", LogLevel.Debug);

            foreach (var dll in Directory.GetFiles(PatchesDir, "*.dll"))
            {
                SafeExecute(() => 
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var patchTypes = assembly.GetTypes()
                        .Where(t => typeof(IPatch).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in patchTypes)
                    {
                        var patch = (IPatch)Activator.CreateInstance(type);
                        patch.Apply(HarmonyInstance);
                        LoadedPatches.Add(patch);
                        Log($"تم تحميل الباتش: {patch.Name} v{patch.Version}", LogLevel.Info);
                    }
                });
            }
        }

        private void LoadPlugins()
        {
            Log("جارٍ تحميل البلغنات...", LogLevel.Debug);

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll"))
            {
                SafeExecute(() => 
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(DZCP_new_editon.IPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (DZCP_new_editon.IPlugin)Activator.CreateInstance(type);
                        plugin.OnEnable();
                        LoadedPlugins.Add(plugin);
                        Log($"تم تحميل البلغن: {plugin.Name} v{plugin.Version}", LogLevel.Info);
                    }
                });
            }

            Log($"تم تحميل {LoadedPlugins.Count} بلغن و {LoadedPatches.Count} باتش", LogLevel.Info);
        }

        public void ReloadAll()
        {
            Log("إعادة تحميل جميع البلغنات...", LogLevel.Debug);

            foreach (var plugin in LoadedPlugins)
            {
                SafeExecute(() => 
                {
                    plugin.OnDisable();
                    plugin.OnEnable();
                }, 
                $"فشل إعادة تحميل {plugin.Name}");
            }

            Log("تمت إعادة تحميل البلغنات بنجاح", LogLevel.Info);
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            try
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        Logger.Debug(message);
                        break;
                    case LogLevel.Info:
                        Logger.Info(message);
                        break;
                    case LogLevel.Warning:
                        Logger.Warn(message);
                        break;
                    case LogLevel.Error:
                        Logger.Error(message);
                        break;
                }

                File.AppendAllText(Path.Combine(LogsDir, "dzcp_log.txt"),
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log message: {ex.Message}");
            }
        }

        private void SafeExecute(Action action, string errorPrefix = null)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Log($"{(errorPrefix != null ? $"{errorPrefix}: " : "")}{ex.Message}", LogLevel.Error);
            }
        }
    }

    public interface IPatch
    {
        string Name { get; }
        Version Version { get; }
        void Apply(Harmony harmony);
        void Unapply();
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }
}