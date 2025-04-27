using DZCP.Tools;
using UnityEngine;

namespace DZCP.Loader
{
    public static class DZCPMain
    {
        public static bool IsInitialized { get; private set; } = false;

        public static void Init()
        {
            if (IsInitialized) return;

            IsInitialized = true;
            Debug.Log("<color=cyan>[DZCP]</color> Starting Framework...");

            PathManager.Initialize();
            ConfigManager.Load();
            PluginLoader.LoadAll();

            Debug.Log("<color=green>[DZCP]</color> Framework fully initialized.");
        }
    }
}