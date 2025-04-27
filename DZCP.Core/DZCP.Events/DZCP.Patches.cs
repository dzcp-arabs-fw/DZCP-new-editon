using DZCP.Core.DZCP.Events.CustomEventArgs;
using HarmonyLib;
using PluginAPI.Core;

namespace DZCP.Patches
{
    [HarmonyPatch(typeof(Player), "Join")]
    public static class PlayerJoinedPatch
    {
        public static void Postfix(Player __instance)
        {
            // استدعاء حدث PlayerJoined عند دخول اللاعب
            _ = EventManager.InvokeEventAsync("PlayerJoined", __instance);
        }
    }
}