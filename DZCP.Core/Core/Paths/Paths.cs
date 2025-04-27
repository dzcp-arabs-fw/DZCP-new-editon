using System;
using System.IO;

namespace DZCP.Core.Paths
{
    /// <summary>
    /// مسارات الملفات والمجلدات الأساسية لـ DZCP.
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// المجلد الجذر لتطبيق DZCP.
        /// </summary>
        public static readonly string DZCPRoot = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// مجلد الإضافات (Plugins).
        /// </summary>
        public static readonly string Plugins = Path.Combine(DZCPRoot, "Plugins");

        /// <summary>
        /// مجلد التهيئات (Configs).
        /// </summary>
        public static readonly string Configs = Path.Combine(DZCPRoot, "Configs");

        /// <summary>
        /// مجلد السجلات (Logs).
        /// </summary>
        public static readonly string Logs = Path.Combine(DZCPRoot, "Logs");

        /// <summary>
        /// مجلد الترجمة (Translations).
        /// </summary>
        public static readonly string Translations = Path.Combine(DZCPRoot, "Translations");

        /// <summary>
        /// مسار ملف التهيئة الرئيسي.
        /// </summary>
        public static readonly string MainConfig = Path.Combine(Configs, "config.yml");

        /// <summary>
        /// مجلد البيانات (Data).
        /// </summary>
        public static readonly string Data = Path.Combine(DZCPRoot, "Data");

        /// <summary>
        /// مجلد التخزين المؤقت (Cache).
        /// </summary>
        public static readonly string Cache = Path.Combine(DZCPRoot, "Cache");

        public static string SCPSL { get; }

        /// <summary>
        /// Gets or sets the Scope path.
        /// </summary>
        public static string Scope { get; set; }

        /// <summary>
        /// Gets or sets the mods path.
        /// </summary>
        public static string Mods { get; set; }

        /// <summary>
        /// Gets or sets the required modules and dependecies path.
        /// </summary>
        public static string Dependencies { get; set; }

        /// <summary>
        /// Gets or sets configs path.
        /// </summary>
        public static string configs { get; set; }

        /// <summary>
        /// Gets or sets configs path.
        /// </summary>
        public static string Config { get; set; }

        /// <summary>
        /// Reloads all paths.
        /// </summary>
        /// <param name="rootDirectory">The new root directory name.</param>
        internal static void Reload(string rootDirectory = "Scope")
        {
            Scope = Path.GetFullPath(rootDirectory);
            Mods = Path.Combine(Scope, "Mods");
            Dependencies = Path.Combine(Mods, "Dependencies");
            Config = Path.Combine(Scope, "Configs");
            Config = Path.Combine(Config,  "config.yml");
        }

        /// <summary>
        /// Creates any missing paths if any, and reloads them all.
        /// </summary>
        internal static void Init()
        {
            Reload();

            if (!Directory.Exists(Plugins))
                Directory.CreateDirectory(Plugins);

            if (!Directory.Exists(Mods))
                Directory.CreateDirectory(Mods);

            if (!Directory.Exists(Dependencies))
                Directory.CreateDirectory(Dependencies);
        }
    }
    
}