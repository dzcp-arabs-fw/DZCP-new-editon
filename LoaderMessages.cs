// -----------------------------------------------------------------------
// <copyright file="DZCPLoader.cs" company="DZCP Team">
// Copyright (c) DZCP Team. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace DZCP.Loader
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;

    public static class DZCPLoader
    {
        public static List<IPlugin> LoadedPlugins { get; } = new List<IPlugin>();
        private static readonly string PluginsDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Plugins");

        [PluginEntryPoint("DZCP Loader", "2.0.0", "DZCP Core System", "MONCEF50G")]
        public static void Load()
        {
            try
            {
                // عرض الشعار
                ShowLoaderMessage();

                // تهيئة النظام
                Initialize();

                // تحميل الملحقات
                LoadAllPlugins();

                ServerConsole.AddLog("[DZCP] تم تحميل النظام بنجاح!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] خطأ في التحميل: {ex}", ConsoleColor.Red);
            }
        }

        private static void Initialize()
        {
            Directory.CreateDirectory(PluginsDir);
            ServerConsole.AddLog("[DZCP] جاري تهيئة النظام...", ConsoleColor.Cyan);
        }

        private static void ShowLoaderMessage()
        {
            var message = GetLoaderMessage();
            foreach (var line in message.Split('\n'))
            {
                ServerConsole.AddLog(line, line.Contains("█") ? ConsoleColor.Magenta : ConsoleColor.Yellow);
            }
        }

        private static string GetLoaderMessage()
        {
            return @"
   ██████╗ ███████╗ ██████╗██████╗
  ██╔════╝██╔════╝██╔════╝██╔══██╗
  ██║     █████╗  ██║     ██████╔╝
  ██║     ██╔══╝  ██║     ██╔═══╝
  ╚██████╗███████╗╚██████╗██║
   ╚═════╝╚══════╝ ╚═════╝╚═╝

  DZCP Framework v2.0.0
  =====================
";
        }

        private static void LoadAllPlugins()
        {
            if (!Directory.Exists(PluginsDir))
            {
                ServerConsole.AddLog("[DZCP] مجلد الملحقات غير موجود!", ConsoleColor.Yellow);
                return;
            }

            foreach (var dll in Directory.GetFiles(PluginsDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in pluginTypes)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        plugin.OnEnable();
                        LoadedPlugins.Add(plugin);
                        ServerConsole.AddLog($"[DZCP] تم تحميل: {plugin.Name} v{plugin.Version}", ConsoleColor.Green);
                    }
                }
                catch (Exception ex)
                {
                    ServerConsole.AddLog($"[DZCP] خطأ في تحميل {Path.GetFileName(dll)}: {ex.Message}", ConsoleColor.Red);
                }
            }

            ServerConsole.AddLog($"[DZCP] تم تحميل {LoadedPlugins.Count} ملحق(ات) بنجاح", ConsoleColor.Cyan);
        }
    }

    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        void OnEnable();
        void OnDisable();
    }
}
