// محاولة تحميل إضافة Exiled في DZCP

using System;
using System.Linq;
using System.Reflection;

public class ExiledCompatibility
{
    public static void LoadExiledPlugin(string path)
    {
        var exiledAssembly = Assembly.LoadFrom(path);
        var pluginType = exiledAssembly.GetTypes().FirstOrDefault(t => t.Name == "Plugin");
        if (pluginType != null)
        {
            dynamic exiledPlugin = Activator.CreateInstance(pluginType);
            exiledPlugin.OnEnabled(); // تشغيل الإضافة
        }
    }
}