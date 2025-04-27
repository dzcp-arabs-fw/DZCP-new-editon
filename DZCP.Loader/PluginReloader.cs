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

        watcher.Created += (sender, args) => PluginsLoader.LoadAll();
        watcher.Changed += (sender, args) => PluginsLoader.LoadAll();
        watcher.Deleted += (sender, args) => PluginsLoader.LoadAll();

        watcher.EnableRaisingEvents = true;
    }
}