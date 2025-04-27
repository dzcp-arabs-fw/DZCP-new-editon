using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

public class PluginLoader
{
    private readonly string pluginsPath;
    private readonly List<Assembly> loadedAssemblies = new List<Assembly>();

    public PluginLoader(string path)
    {
        pluginsPath = path;
        LoadPlugins();
        WatchPluginsFolder();
    }

    private void LoadPlugins()
    {
        foreach (var dll in Directory.GetFiles(pluginsPath, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(dll);
            loadedAssemblies.Add(assembly);
            // تنفيذ منطق تحميل الإضافات
        }
    }

    private void WatchPluginsFolder()
    {
        var watcher = new FileSystemWatcher(pluginsPath, "*.dll")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime
        };
        watcher.Changed += OnChanged;
        watcher.Created += OnChanged;
        watcher.Deleted += OnChanged;
        watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        // منطق إعادة تحميل الإضافات عند التغيير
    }
    private static void OnPluginChanged(object sender, FileSystemEventArgs e)
    {
        // منطق إعادة تحميل الإضافة عند تغيير الملف
    }
    public static void LoadPlugin(string pluginPath)
    {
        if (File.Exists(pluginPath))
        {
            var assembly = Assembly.LoadFrom(pluginPath);
            Console.WriteLine($"تم تحميل الإضافة {pluginPath}");
            // يمكن تنفيذ أي منطق آخر هنا مثل تفعيل الوظائف الخاصة بالإضافة
        }
        else
        {
            Console.WriteLine("الإضافة غير موجودة.");
        }
    }

    public static void WatchForPluginChanges(string pluginDirectory)
    {
        FileSystemWatcher watcher = new FileSystemWatcher(pluginDirectory);
        watcher.Changed += (sender, e) => LoadPlugin(e.FullPath);
        watcher.EnableRaisingEvents = true;
    }
}



