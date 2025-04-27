using System.IO;
using DZCP.Tools;
using UnityEngine;

namespace DZCP.Loader
{
    public static class PluginLoader
    {
        public static void LoadAll()
        {
            string[] dlls = Directory.GetFiles(PathManager.PluginsPath, "*.dll");
            foreach (var dll in dlls)
            {
                Debug.Log($"[DZCP] Found plugin: {Path.GetFileName(dll)} (but loading not implemented yet)");
                // في المستقبل: تستخدم Reflection أو نظام dynamic loading
            }
        }
    }
}