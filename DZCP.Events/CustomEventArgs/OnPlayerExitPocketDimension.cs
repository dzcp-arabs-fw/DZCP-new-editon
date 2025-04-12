using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerExitPocketDimension
    {
        [PluginEvent(ServerEventType.PlayerExitPocketDimension)]
        public void HandlePlayerExitPocketDimension(Player player)
        {
            ServerConsole.AddLog($"Player {player.Nickname} exited the Pocket Dimension.", ConsoleColor.DarkGreen);
        }
    }
}