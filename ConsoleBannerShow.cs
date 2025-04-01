using System;
using System.Collections.Generic;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;

namespace DZCP_Loader
{
    public class ConsoleBannerShow
    {
        public static void DisplayBanner()
        {
            try
            {
                // لعرض البانر
                ConsoleBannerShow.DisplayBanner();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
    ██████╗ ███████╗ ██████╗██████╗
    ██╔══██╗██╔════╝██╔════╝██╔══██╗
    ██║  ██║█████╗  ██║     ██████╔╝
    ██║  ██║██╔══╝  ██║     ██╔═══╝
    ██████╔╝███████╗╚██████╗██║
    ╚═════╝ ╚══════╝ ╚═════╝╚═╝
                ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    DZCP Plugin Loader - SCP:SL");
                Console.WriteLine($"    Version 1.0.0 | Loaded at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine("    =======================================");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Log.Error($"فشل عرض البانر: {ex}");
            }
        }

        public static void DisplayLoadSummary(int loadedPlugins, List<string> pluginNames)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n    [ملخص التحميل]");
                Console.WriteLine($"    تم تحميل {loadedPlugins} ملحق(ات) بنجاح");
                Console.WriteLine("    ------------------------------");

                foreach (var name in pluginNames)
                {
                    Console.WriteLine($"    - {name}");
                }

                Console.WriteLine("    =======================================");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Log.Error($"فشل عرض ملخص التحميل: {ex}");
            }
        }
    }
}
