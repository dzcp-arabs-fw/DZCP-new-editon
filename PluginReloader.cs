using System.IO;
using DZCP.Loader;

public class PluginReloader
{
    public static void WatchForPluginChanges()
    {
        var watcher = new FileSystemWatcher(DZCP.Core.PluginLoader.PluginsPath, "*.dll")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
        };

        watcher.Created += (sender, args) => DZCP.Loader.PluginLoader.LoadAll();
        watcher.Changed += (sender, args) => DZCP.Loader.PluginLoader.LoadAll();
        watcher.Deleted += (sender, args) => DZCP.Loader.PluginLoader.LoadAll();

        watcher.EnableRaisingEvents = true;
    }
}