using System;
using System.IO;

namespace DZCP.Tools
{
    public static class PathManager
    {
        public static string ConfigPath => Path.Combine(RootPath, "Configs");
        public static string LogsPath => Path.Combine(RootPath, "Logs");
        public static string PluginsPath => Path.Combine(PluginsPath, "Plugins");
        public static string RootPath { get; private set; }
        public static string ConfigsPath { get; private set; }
        public static string DataPath { get; private set; }

        /// <summary>
        /// يقوم بتهيئة مجلدات الإطار الأساسية.
        /// </summary>
        public static void Initialize(string rootFolderName = "DZCP")
        {
            RootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootFolderName);
            ConfigsPath = Path.Combine(RootPath, "Configs");
            DataPath = Path.Combine(RootPath, "Data");
            RootPath = Path.Combine(RootPath, "DZCP");

            CreateDirectory(RootPath);
            CreateDirectory(PluginsPath);
            CreateDirectory(ConfigsPath);
            CreateDirectory(LogsPath);
            CreateDirectory(DataPath);
        }

        /// <summary>
        /// يُرجع مسار مجلد البلجن.
        /// </summary>
        public static string GetPluginPath(string pluginName) =>
            CreateAndReturn(Path.Combine(PluginsPath, pluginName));

        /// <summary>
        /// يُرجع مسار إعدادات البلجن.
        /// </summary>
        public static string GetPluginConfigPath(string pluginName) =>
            CreateAndReturn(Path.Combine(PluginsPath, pluginName, "Configs"));

        /// <summary>
        /// يُرجع مسار لوقات البلجن.
        /// </summary>
        public static string GetPluginLogsPath(string pluginName) =>
            CreateAndReturn(Path.Combine(PluginsPath, pluginName, "Logs"));

        /// <summary>
        /// إنشاء مجلد إذا غير موجود.
        /// </summary>
        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// ينشئ المجلد ويُرجع المسار.
        /// </summary>
        private static string CreateAndReturn(string path)
        {
            CreateDirectory(path);
            return path;
        }
    }
}
