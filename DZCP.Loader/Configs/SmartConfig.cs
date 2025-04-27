// DZCP/API/Configs/SmartConfig.cs

using System.IO;
using DZCP.Core.Configs;
using DZCP.Loader;
using DZCP.NewEdition;
using PluginAPI.Helpers;
using DZCPLoader = DZCP_new_editon.DZCPLoader;
using IConfig = DZCP.API.IConfig;

public class SmartConfig<T> where T : IConfig, new()
{
    private static T _instance;
    private static FileSystemWatcher _watcher;

    public static T Instance
    {
        get
        {
            if (_instance == null)
                Reload();
            return _instance;
        }
    }

    public static void Reload()
    {
        string path = Path.Combine(Paths.Configs, $"{typeof(T).Name}.yml");
        if (!File.Exists(path))
        {
            _instance = new T();
            File.WriteAllText(path, DZCP_new_editon.DZCPLoader.Instance.HarmonyInstance.Id);
            return;
        }


        // مراقبة التغييرات
        _watcher = new FileSystemWatcher(Paths.Configs, $"{typeof(T).Name}.yml")
        {
            NotifyFilter = NotifyFilters.LastWrite
        };
        _watcher.Changed += (_, _) => Reload();
        _watcher.EnableRaisingEvents = true;
    }
}
