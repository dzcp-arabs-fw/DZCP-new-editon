using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP.Loader;

public abstract class PluginLoaderDzcp
{
    public static void LoadPlugin(string pluginName)
    {
        try
        {
            var pluginPath = Path.Combine("Plugins", pluginName + ".dll");
            if (File.Exists(pluginPath))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(pluginPath);
                // استدعاء دالة لبدء البلغن داخل assembly
                Type pluginType = pluginAssembly.GetTypes().FirstOrDefault(t => t.GetInterface("IPlugin") != null);
                if (pluginType != null)
                {
                    foreach (var dll in Directory.GetFiles(pluginPath, "*.dll"))
                    {
                        Assembly.LoadFrom(dll);
                    }
                    IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(pluginType);
                    pluginInstance.OnEnable();
                    Console.WriteLine($"Plugin {pluginName} loaded successfully!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading plugin {pluginName}: {ex.Message}");
        }
    }
    
    public static void UnloadPlugin(string pluginName)
    {
        try
        {
            // رمز لتحميل وتفريغ البلغنات من الذاكرة
            // هنا يمكنك تحديد الآلية للتفريغ حسب كيفية تصميم البلغنات
            Console.WriteLine($"Plugin {pluginName} unloaded!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error unloading plugin {pluginName}: {ex.Message}");
        }
    }
}