using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerKicked
    {
        [PluginEvent(ServerEventType.PlayerKicked)]
        public void HandlePlayerKicked(Player player, string reason)
        {
            ServerConsole.AddLog($"Player {player.Nickname} was kicked for: {reason}.", ConsoleColor.Yellow);
        }
    }
}