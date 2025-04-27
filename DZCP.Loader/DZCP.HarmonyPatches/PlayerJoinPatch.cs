using DZCP;
using HarmonyLib;
using DZCP.Events;
using PluginAPI.Core;
using Player = DZCP.API.Models.Player;

[HarmonyPatch(typeof(Server), nameof(Server.PlayerId))]
public class PlayerJoinPatch
{
    static void Postfix(Player player)
    {
        var evt = new PlayerJoinEvent(player.Nickname);
        EventManager.Invoke(evt);
    }
}