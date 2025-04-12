using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScp096LookedAt
    {
        [PluginEvent(ServerEventType.Scp096AddingTarget)]
        public void HandleScp096LookedAt(Player scp096, Player observer)
        {
            ServerConsole.AddLog($"Player {observer.Nickname} looked at SCP-096!", ConsoleColor.Red);
        }
    }
}