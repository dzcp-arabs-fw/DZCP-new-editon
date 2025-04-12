using System;
using DZCP.API.Enums;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerChangeRole
    {
        [PluginEvent(ServerEventType.PlayerChangeRole)]
        public void HandlePlayerChangeRole(Player player, PlayerRole oldRole, PlayerRole newRole)
        {
            ServerConsole.AddLog($"Player {player.Nickname} changed role from {oldRole} to {newRole}.", ConsoleColor.Cyan);
        }
    }
}