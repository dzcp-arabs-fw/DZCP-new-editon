using HarmonyLib;
using System.Reflection;

namespace DZCP.Core
{
    public static class HarmonyManager
    {
        private static Harmony _harmony;

        public static void Initialize()
        {
            _harmony = new Harmony("com.dzcp.framework");
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static void UnpatchAll()
        {
            _harmony.UnpatchAll("com.dzcp.framework");
        }
    }
}