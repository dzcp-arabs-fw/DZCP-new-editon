using System;
using System.IO;
using System.Reflection;
using DZCP.Loader;
using DZCP.NewEdition;
using PluginAPI.Core.Attributes;
using IPlugin = DZCP_new_editon.IPlugin;

internal class PluginAutoLoader
{
    [PluginEntryPoint("Plugin Auto Loader", "1.0.0", "Loads all plugins from the Plugins directory", "DZCP")]
    public void OnStart()
    {
        string pluginsDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Plugins");

        if (!Directory.Exists(pluginsDir))
        {
            Directory.CreateDirectory(pluginsDir);
            return;
        }

        foreach (var dll in Directory.GetFiles(pluginsDir, "*.dll"))
        {
            try
            {
                var assembly = Assembly.LoadFrom(dll);
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(DZCP_new_editon.IPlugin).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugin.OnEnable();
                        DZCPLoaderConsol.Instance?.LoadedPlugins.Add(plugin);
                        DZCPLoaderConsol.Instance?.Log($"[AutoLoader] تم تحميل البلجن: {plugin.Name}", LogLevel.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                DZCPLoaderConsol.Instance?.Log($"[AutoLoader] فشل تحميل {Path.GetFileName(dll)}: {ex.Message}", LogLevel.Error);
            }
        }
    }
}