using HarmonyLib;
using UnityEngine;

namespace DZCP.Loader.DZCP.Entry
{
    [HarmonyPatch(typeof(IPlugin), nameof(GameCore.RoundStart))]
    public static class DzcpBootstrap
    {
        static void Postfix()
        {
            try
            {
                DZCPMain.Init();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("[DZCP] Error during Init: " + ex);
            }
        }
    }
}