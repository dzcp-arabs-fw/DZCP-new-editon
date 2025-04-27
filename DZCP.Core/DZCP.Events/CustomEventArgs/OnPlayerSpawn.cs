using System;
using DZCP.API.Enums;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerSpawn
    {
        [PluginEvent(ServerEventType.PlayerSpawn)]
        public void HandlePlayerSpawn(Player player, PlayerRole role)
        {
            ServerConsole.AddLog($"Player {player.Nickname} spawned as {role}.", ConsoleColor.Blue);
        }
    }
}