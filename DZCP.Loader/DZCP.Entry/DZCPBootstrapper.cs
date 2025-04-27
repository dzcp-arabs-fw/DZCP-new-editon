using System;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using DZCP.Config;
using DZCP.Loader;
using DZCP.Loader.DZCP.Entry;
using DZCP.Tools;
using ConfigManager = DZCP.Loader.ConfigManager;

namespace DZCP.Entry
{
    [BepInPlugin("dzcp.framework.core", "DZCP Framework", "1.0.0")]
    public class DZCPBootstrapper : BaseUnityPlugin
    {
        public static DZCPBootstrapper Instance { get; private set; }
        public static ManualLogSource Log => Instance.Logger;

        private void Awake()
        {
            Instance = this;

            Log.LogInfo("✅ [DZCP] Bootstrapping DZCP Framework...");

            try
            {
                // 1. إعداد المسارات
                PathManager.Initialize(Paths.ConfigPath);

                // 2. تحميل الإعدادات
                ConfigManager.Load();

                // 3. تسجيل الأحداث/تجهيز النظام
                DZCPMain.Init();

                // 4. تحميل الإضافات (لاحقاً ممكن تطورها هنا)
                Loader.PluginLoader.LoadAll();

                Log.LogInfo("✅ [DZCP] Framework initialized successfully.");
            }
            catch (Exception ex)
            {
                Log.LogError("❌ [DZCP] Failed to initialize Framework: " + ex.Message);
                Log.LogError(ex);
            }
        }
    }
}