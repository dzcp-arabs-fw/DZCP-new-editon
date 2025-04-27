using HarmonyLib;
using DZCP.Events;
using UnityEngine;

[HarmonyPatch(typeof(ServerConsole), nameof(GameCore.RoundStart))]
public static class PlayerJoinPatch
{
    public static void Postfix(string go)
    {
        PlayerJoinEvent playerJoinEvent = (new PlayerJoinEvent(go));
    }
}