// DZCP/API/Configs/SmartConfig.cs

using System.IO;
using DZCP.API.Interfaces;
using DZCP.Loader;
using PluginAPI.Helpers;

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
            File.WriteAllText(path, Loader.ConfigSerializer.Serialize(_instance));
            return;
        }

        _instance = Loader.ConfigDeserializer.Deserialize<T>(File.ReadAllText(path));

        // مراقبة التغييرات
        _watcher = new FileSystemWatcher(Paths.Configs, $"{typeof(T).Name}.yml")
        {
            NotifyFilter = NotifyFilters.LastWrite
        };
        _watcher.Changed += (_, _) => Reload();
        _watcher.EnableRaisingEvents = true;
    }
}
