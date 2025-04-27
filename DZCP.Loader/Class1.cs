using System;
using System.IO;
using DZCP.Framework;
using DZCP.Logging;
using DZCP.Tools;

namespace DZCP.Features.Plugins
{
    public class PathPlugin
    {
        /// <summary>
        /// اسم مجلد البلجنات في المسار.
        /// </summary>
        public string PluginDirectory { get; private set; }

        /// <summary>
        /// اسم مجلد الإعدادات للبلجنات.
        /// </summary>
        public string ConfigDirectory { get; private set; }

        /// <summary>
        /// اسم مجلد السجلات للبلجنات.
        /// </summary>
        public string LogDirectory { get; private set; }

        /// <summary>
        /// منشئ كائن PathPlugin الذي يقوم بتحديد المسارات.
        /// </summary>
        /// <param name="pluginName">اسم البلجن لاستخدامه في تكوين المسار.</param>
        public PathPlugin(string pluginName)
        {
            // تحديد المسارات بناءً على اسم البلجن
            PluginDirectory = Path.Combine(PathManager.PluginsPath, pluginName);
            ConfigDirectory = Path.Combine(PathManager.ConfigsPath, "Configs");
            LogDirectory = Path.Combine(PathManager.LogsPath, "Logs");

            // تأكد من وجود المجلدات
            EnsureDirectoryExists(PluginDirectory);
            EnsureDirectoryExists(ConfigDirectory);
            EnsureDirectoryExists(LogDirectory);
        }

        /// <summary>
        /// تأكد من وجود المجلد وإذا لم يكن موجودًا، قم بإنشائه.
        /// </summary>
        /// <param name="directoryPath">المسار الكامل للمجلد.</param>
        private void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.CreateDirectory(directoryPath);
                    Logger.Info($"[PATH] Created directory: {directoryPath}");
                }
                catch (Exception e)
                {
                    Logger.Error($"[PATH] Failed to create directory: {directoryPath}");
                    Logger.Error(e);
                }
            }
        }

        /// <summary>
        /// استرجاع المسار الكامل للملفات داخل المجلد.
        /// </summary>
        /// <param name="fileName">اسم الملف.</param>
        /// <returns>المسار الكامل للملف.</returns>
        public string GetFilePath(string fileName)
        {
            return Path.Combine(PluginDirectory, fileName);
        }

        /// <summary>
        /// استرجاع المسار الكامل للملفات في مجلد الإعدادات.
        /// </summary>
        /// <param name="fileName">اسم الملف في مجلد الإعدادات.</param>
        /// <returns>المسار الكامل للملف في مجلد الإعدادات.</returns>
        public string GetConfigFilePath(string fileName)
        {
            return Path.Combine(ConfigDirectory, fileName);
        }

        /// <summary>
        /// استرجاع المسار الكامل للملفات في مجلد السجلات.
        /// </summary>
        /// <param name="fileName">اسم الملف في مجلد السجلات.</param>
        /// <returns>المسار الكامل للملف في مجلد السجلات.</returns>
        public string GetLogFilePath(string fileName)
        {
            return Path.Combine(LogDirectory, fileName);
        }
    }
}
