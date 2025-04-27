using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerEnterPocketDimension
    {
        [PluginEvent(ServerEventType.PlayerEnterPocketDimension)]
        public void HandlePlayerEnterPocketDimension(Player player)
        {
            ServerConsole.AddLog($"Player {player.Nickname} entered the Pocket Dimension.", ConsoleColor.DarkGray);
        }
    }
}