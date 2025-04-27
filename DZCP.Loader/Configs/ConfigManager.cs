using System.IO;
using DZCP.Tools;
using UnityEngine;

namespace DZCP.Loader
{
    public static class ConfigManager
    {
        public static void Load()
        {
            string configFile = Path.Combine(PathManager.ConfigPath, "framework.cfg");
            if (!File.Exists(configFile))
            {
                File.WriteAllText(configFile, "# DZCP Default Config\nlanguage=en\nlogging=true");
                Debug.Log("[DZCP] Default config created.");
            }
            else
            {
                Debug.Log("[DZCP] Config loaded from " + configFile);
            }
        }
    }
}