using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerRevive
    {
        [PluginEvent(ServerEventType.PlayerCheckReservedSlot)]
        public void HandlePlayerRevive(Player player)
        {
            ServerConsole.AddLog($"Player {player.Nickname} was revived.", ConsoleColor.DarkYellow);
        }
    }
}