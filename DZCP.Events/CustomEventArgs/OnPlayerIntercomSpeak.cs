using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnPlayerIntercomSpeak
    {
        [PluginEvent(ServerEventType.PlayerUsingIntercom)]
        public void HandlePlayerIntercomSpeak(Player player)
        {
            ServerConsole.AddLog($"Player {player.Nickname} is speaking on the intercom.", ConsoleColor.Gray);
        }
    }
}