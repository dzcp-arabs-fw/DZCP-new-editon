using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.Loader;
using DZCP.Logging;
using HarmonyLib;
using PluginAPI.Core.Attributes;

namespace DZCP_new_editon
{
    public class DZCPLoader
    {
        public static DZCPLoader Instance { get; private set; }

        // مسارات الملفات
        public static readonly string BaseDir = Path.Combine(Environment.CurrentDirectory, "DZCP");
        public readonly string PluginsDir = Path.Combine(BaseDir, "Plugins");
        public readonly string ConfigsDir = Path.Combine(BaseDir, "Configs");
        public readonly string DependenciesDir = Path.Combine(BaseDir, "Dependencies");
        public readonly string LogsDir = Path.Combine(BaseDir, "Logs");
        public readonly string PatchesDir = Path.Combine(BaseDir, "Patches");

        public List<IPlugin> LoadedPlugins { get; } = new List<IPlugin>();
        public List<IPatch> LoadedPatches { get; } = new List<IPatch>();
        public Harmony HarmonyInstance { get; private set; }

        public bool IsInitialized { get; private set; }

        [PluginEntryPoint("DZCP New Edition", "2.0.0", "Advanced plugin framework for SCP:SL", "YourName")]
        public void LoadPlugin()
        {
            Instance = this;
            Initialize();
        }

        public void Initialize()
        {
            if (IsInitialized) return;

            try
            {
                // إنشاء الهيكل الأساسي
                CreateDirectories();

                // عرض الشعار
                ShowConsoleBanner();

                // تحميل التبعيات الأساسية (Harmony أولاً)
                LoadDependencies();

                // تهيئة نظام Harmony
                InitializeHarmony();

                // تحميل الباتشات
                LoadPatches();

                // تحميل الملحقات
                LoadPlugins();

                IsInitialized = true;

                Log("تم تهيئة DZCP New Edition بنجاح!", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Log($"فشل التهيئة: {ex}", LogLevel.Error);
            }
        }

        private void CreateDirectories()
        {
            Directory.CreateDirectory(BaseDir);
            Directory.CreateDirectory(PluginsDir);
            Directory.CreateDirectory(ConfigsDir);
            Directory.CreateDirectory(DependenciesDir);
            Directory.CreateDirectory(LogsDir);
            Directory.CreateDirectory(PatchesDir);

            // إنشاء ملف تهيئة افتراضي
            if (!File.Exists(Path.Combine(ConfigsDir, "dzcp_config.cfg")))
            {
                File.WriteAllText(Path.Combine(ConfigsDir, "dzcp_config.cfg"),
                    "# تهيئة DZCP الأساسية\n" +
                    "enable_patches=true\n" +
                    "auto_update=false\n" +
                    "debug_mode=false\n");
            }
        }

        private void ShowConsoleBanner()
        {
            string banner = @"
    ██████╗ ███████╗ ██████╗██████╗     ███╗   ██╗███████╗██╗    ██╗
    ██╔══██╗██╔════╝██╔════╝██╔══██╗    ████╗  ██║██╔════╝██║    ██║
    ██║  ██║█████╗  ██║     ██████╔╝    ██╔██╗ ██║█████╗  ██║ █╗ ██║
    ██║  ██║██╔══╝  ██║     ██╔═══╝     ██║╚██╗██║██╔══╝  ██║███╗██║
    ██████╔╝███████╗╚██████╗██║         ██║ ╚████║███████╗╚███╔███╔╝
    ╚═════╝ ╚══════╝ ╚═════╝╚═╝         ╚═╝  ╚═══╝╚══════╝ ╚══╝╚══╝

    DZCP New Edition - SCP:SL Plugin Framework
    Version 2.0.0 | Loaded at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"
    ==============================================";

            Log(banner, LogLevel.Info);
        }

        private void LoadDependencies()
        {
            Log("جارٍ تحميل التبعيات...", LogLevel.Debug);

            // تحميل Harmony أولاً بشكل خاص
            string harmonyPath = Path.Combine(DependenciesDir, "0Harmony.dll");
            if (File.Exists(harmonyPath))
            {
                try
                {
                    Assembly.LoadFrom(harmonyPath);
                    Log("تم تحميل مكتبة Harmony بنجاح", LogLevel.Info);
                }
                catch (Exception ex)
                {
                    Log($"فشل تحميل مكتبة Harmony: {ex.Message}", LogLevel.Error);
                    throw new Exception("Harmony is required for DZCP to work!");
                }
            }
            else
            {
                Log("لم يتم العثور على مكتبة Harmony المطلوبة!", LogLevel.Error);
                throw new FileNotFoundException("0Harmony.dll not found in Dependencies folder!");
            }

            // تحميل باقي التبعيات
            foreach (var dll in Directory.GetFiles(DependenciesDir, "*.dll")
                .Where(x => !x.EndsWith("0Harmony.dll")))
            {
                try
                {
                    Assembly.LoadFrom(dll);
                    Log($"تم تحميل التبعية: {Path.GetFileName(dll)}", LogLevel.Debug);
                }
                catch (Exception ex)
                {
                    Log($"فشل تحميل التبعية {Path.GetFileName(dll)}: {ex.Message}", LogLevel.Warning);
                }
            }
        }

        private void InitializeHarmony()
        {
            try
            {
                HarmonyInstance = new Harmony("dzcp.newedition");
                Log("تم تهيئة Harmony بنجاح", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Log($"فشل تهيئة Harmony: {ex.Message}", LogLevel.Error);
                throw;
            }
        }

        private void LoadPatches()
        {
            Log("جارٍ تحميل الباتشات...", LogLevel.Debug);

            foreach (var dll in Directory.GetFiles(PatchesDir, "*.dll"))
            {
                try
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
                }
                catch (Exception ex)
                {
                    Log($"فشل تحميل الباتش {Path.GetFileName(dll)}: {ex.Message}", LogLevel.Error);
                }
            }
        }

        private void LoadPlugins()
        {
            Log("جارٍ تحميل الملحقات...", LogLevel.Debug);

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);

                        // تحميل التهيئة
                        string configPath = Path.Combine(ConfigsDir, $"{plugin.Name}.cfg");
                        if (!File.Exists(configPath))
                        {
                            File.WriteAllText(configPath, $"# تهيئة {plugin.Name}\nversion={plugin.Version}\n");
                        }

                        plugin.OnEnable();
                        LoadedPlugins.Add(plugin);
                        Log($"تم تحميل الملحق: {plugin.Name} v{plugin.Version}", LogLevel.Info);
                    }
                }
                catch (Exception ex)
                {
                    Log($"فشل تحميل الملحق {Path.GetFileName(dll)}: {ex.Message}", LogLevel.Error);
                }
            }

            Log($"تم تحميل {LoadedPlugins.Count} ملحق(ات) و {LoadedPatches.Count} باتش(ات)", LogLevel.Info);
        }

        public void ReloadAll()
        {
            Log("جارٍ إعادة تحميل جميع المكونات...", LogLevel.Debug);

            foreach (var plugin in LoadedPlugins)
            {
                try
                {
                    plugin.OnDisable();
                    plugin.OnEnable();
                }
                catch (Exception ex)
                {
                    Log($"فشل إعادة تحميل {plugin.Name}: {ex.Message}", LogLevel.Error);
                }
            }

            Log("تم إعادة تحميل جميع الملحقات بنجاح", LogLevel.Info);
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
                    default:
                        Logger.Info(message);
                        break;
                }

                File.AppendAllText(Path.Combine(LogsDir, "dzcp_log.txt"),
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}\n");
            }
            catch { /* تجاهل أي أخطاء في التسجيل */ }
        }
    }

    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        string Description { get; }

        void OnEnable();
        void OnDisable();
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


