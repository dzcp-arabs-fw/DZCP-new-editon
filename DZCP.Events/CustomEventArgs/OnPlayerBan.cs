using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerBan
    {
        [PluginEvent(ServerEventType.PlayerBanned)]
        public void HandlePlayerBan(Player player, string reason)
        {
            ServerConsole.AddLog($"Player {player.Nickname} was banned for: {reason}.", ConsoleColor.Red);
        }
    }
}