using DZCP.Core;

namespace DZCP
{
    class ProgramPath
    {
        static void Main(string[] args)
        {
            HarmonyManager.Initialize();
            PluginLoaderDzcp.LoadPlugin("Plugins");

            // تنفيذ المهام الأخرى...

            // عند الإنهاء
            HarmonyManager.UnpatchAll();
        }
    }
}