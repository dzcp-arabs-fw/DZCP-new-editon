using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using DZCP_Loader;
using DZCP.API;
using DZCP.Core;
using DZCP.Core.Paths;
using DZCP.Loader;
using DZCP.Logging;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;



namespace SCP_Server
{
    class Program
    {
        private static List<IPlugin> _loadedPlugins = new List<IPlugin>();
        private static string _pluginsDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Plugins");

        static void Main(string[] args)
        {
            // تحميل جميع البلجنات
            var plugins = DZCP.Loader.PluginsLoader.LoadAll();
            Console.WriteLine("🧠 DZCP Framework is starting...");

            PluginLoader.LoadPlugin("Plugins");

            // محاكاة لاعب يدخل السيرفر
            var player = new MockPlayer("SCP_Mido");
            EventManager.Fire((new PluginEvent().EventType == ServerEventType.PlayerJoined));
            // بدء السيرفر أو أي شيء آخر بعد تحميل البلجنات
            Console.WriteLine("Server started with loaded plugins.");

            try
            {
                // عرض البانر
                ConsoleBannerShow.DisplayBanner();
                // تهيئة المجلدات
                InitializeDirectories();

                // تحميل الملحقات
                LoadAllPlugins();
                DZCPLoaderConsol.Instance.Initialize();
                DZCPLoaderConsol.Instance.HarmonyInstance.PatchAll();
                DZCPLoaderConsol.Instance.HarmonyInstance.UnpatchAll();
                DZCPLoaderConsol.Instance.HarmonyInstance.PatchAll(typeof(Program).Assembly);
                DZCPLoaderConsol.Instance.Initialize();
                
                // بدء الخادم
                StartServer(args);
                
                ConsoleBannerShow.DisplayBanner();
                DZCPLoaderConsol.Instance.Initialize();

                // حلقة الأوامر الرئيسية
                CommandLoop();
            }
            catch (Exception ex)
            {
                LogError("فشل تشغيل السيرفر: " + ex);
            }
            
        }
    
        static void InitializeDirectories()
        {
            Directory.CreateDirectory(_pluginsDir);
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory,  "Configs"));
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory,  "Plugins"));
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory,  "Logs"));
        }

        static void LoadAllPlugins()
        {
            Log("جارٍ تحميل الملحقات...");

            foreach (var dll in Directory.GetFiles(_pluginsDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        plugin.OnEnable();
                        _loadedPlugins.Add(plugin);
                        Log($"تم تحميل: {plugin.Name} v{plugin.Version}");
                    }
                }
                catch (Exception ex)
                {
                    LogError($"فشل تحميل {Path.GetFileName(dll)}: {ex.Message}");
                }
            }

            ConsoleBannerShow.DisplayLoadSummary(_loadedPlugins.Count,
                _loadedPlugins.Select(p => p.Name).ToList());
        }

        // محاكاة لاعب يدخل السيرفر

        static void StartServer(string[] args)
        {
            Log("بدء تشغيل سيرفر SCP:SL...");
            // هنا كود بدء السيرفر الفعلي
            // يمكنك استخدام Process.Start أو أي طريقة أخرى لبدء السيرفر
        }

        static void CommandLoop()
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                switch (input?.ToLower())
                {
                    case "reload":
                        ReloadPlugins();
                        break;
                    case "plugins":
                        ListPlugins();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Log("أمر غير معروف. الأوامر المتاحة: reload, plugins, exit");
                        break;
                }
            }
        }

        static void ReloadPlugins()
        {
            Log("إعادة تحميل جميع الملحقات...");
            foreach (var plugin in _loadedPlugins)
            {
                plugin.OnDisable();
            }
            _loadedPlugins.Clear();
            LoadAllPlugins();
        }

        static void ListPlugins()
        {
            Log($"الملحقات المحملة ({_loadedPlugins.Count}):");
            foreach (var plugin in _loadedPlugins)
            {
                Log($"- {plugin.Name} v{plugin.Version} بواسطة {plugin.Author}");
            }
        }

        static void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}";
            Console.WriteLine(logEntry);
            File.AppendAllText("server_log.txt", logEntry + Environment.NewLine);
        }

        static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log(message);
            Console.ResetColor();
        }
    }

    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        void OnEnable();
        void OnDisable();
    }
}




