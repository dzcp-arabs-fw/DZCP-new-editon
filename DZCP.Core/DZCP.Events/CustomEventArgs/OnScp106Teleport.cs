using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScp106Teleport
    {
        [PluginEvent(ServerEventType.Scp106TeleportPlayer)]
        public void HandleScp106Teleport(Player scp106)
        {
            ServerConsole.AddLog($"SCP-106 teleported.", ConsoleColor.DarkBlue);
        }
    }
}