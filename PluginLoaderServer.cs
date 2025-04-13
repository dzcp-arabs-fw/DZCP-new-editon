using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DZCP_new_editon;
using UnityEngine;

namespace DZCP.Core
{
    public static class PluginLoader
    {
        public static readonly string PluginsPath = Path.Combine(Application.dataPath, "DZCP/Plugins");
        private static bool _isInitialized;

        /// <summary>
        /// تهيئة النظام وتحميل جميع البلغنات
        /// </summary>
        public static void Initialize()
        {
            if (_isInitialized) return;
            
            Directory.CreateDirectory(PluginsPath);
            LoadAllPlugins();
            
            Debug.Log($"[DZCP] تم تحميل {GetLoadedCount()} بلغن بنجاح");
            _isInitialized = true;
        }

        /// <summary>
        /// تحميل جميع البلغنات من المجلد
        /// </summary>
        private static void LoadAllPlugins()
        {
            foreach (var dll in Directory.GetFiles(PluginsPath, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var assembly = Assembly.Load(File.ReadAllBytes(dll));
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        plugin.OnEnable();
                        Debug.Log($"[DZCP] تم تحميل: {type.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[DZCP] خطأ في تحميل {Path.GetFileName(dll)}: {ex}");
                }
            }
        }

        /// <summary>
        /// الحصول على عدد البلغنات المحملة
        /// </summary>
        public static int GetLoadedCount()
        {
            return Directory.GetFiles(PluginsPath, "*.dll", SearchOption.AllDirectories).Length;
        }
        
    }
}