using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScpEscape
    {
        [PluginEvent(ServerEventType.PlayerEscape)]
        public void HandleScpEscape(Player scp)
        {
            ServerConsole.AddLog($"SCP {scp.Nickname} escaped!", ConsoleColor.Yellow);
        }
    }
}