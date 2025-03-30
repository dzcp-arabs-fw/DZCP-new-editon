using System;
using DZCP.API.Interfaces;
using DZCP.API.Enums;
using DZCP.API.Interfaces;
using DZCP.Loader;
using PluginAPI.Core;

namespace ServerASCIIBanner
{
    public class Config : IConfig
    {
        public static bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public static string LogoText { get; set; } = @"
███████╗ ██████╗██████╗ ██╗███████╗
██╔════╝██╔════╝██╔══██╗██║██╔════╝
███████╗██║     ██████╔╝██║███████╗
╚════██║██║     ██╔═══╝ ██║╚════██║
███████║╚██████╗██║     ██║███████║
╚══════╝ ╚═════╝╚═╝     ╚═╝╚══════╝
";
        public static string LogoColor { get; set; } = "Green";
        public static bool ShowVersion { get; set; } = true;
    }

    public class MainPlugin : ServerConsole
    {
        public string Name => "Server ASCII Banner";
        public string Author => "YourName";
        public Version Version => new Version(2, 3, 1);

        public void OnEnabled()
        {
            try
            {
                if (Config.IsEnabled)
                {
                    // عرض الشعار عند تشغيل السيرفر
                    ShowASCIIBanner();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error showing banner: {ex}");
            }

            base.enabled = true;;
        }

        private void ShowASCIIBanner()
        {
            var logoLines = Config.LogoText.Split('\n');
            var color = GetColorFromString(Config.LogoColor);

            foreach (var line in logoLines)
            {
                ServerConsole.AddLog(color + line.Trim(), ConsoleColor.White);
            }

            if (Config.ShowVersion)
            {
                ServerConsole.AddLog($"\nSCPSL Server v{Server.ServerIpAddress} | Plugin v{Version}", ConsoleColor.Cyan);
            }
        }

        private ConsoleColor GetColorFromString(string colorName)
        {
            try
            {
                return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName, true);
            }
            catch
            {
                return ConsoleColor.Green; // لون افتراضي إذا كان هناك خطأ
            }
        }
    }
}
