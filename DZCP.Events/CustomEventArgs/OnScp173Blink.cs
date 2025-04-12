using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScp173Blink
    {
        [PluginEvent(ServerEventType.Scp173BreakneckSpeeds)]
        public void HandleScp173Blink(Player player)
        {
            ServerConsole.AddLog($"Player {player.Nickname} blinked near SCP-173!", ConsoleColor.DarkRed);
        }
    }
}