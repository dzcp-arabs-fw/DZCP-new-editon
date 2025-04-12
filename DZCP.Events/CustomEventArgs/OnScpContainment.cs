using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScpContainment
    {
        [PluginEvent(ServerEventType.LczDecontaminationStart)]
        public void HandleScpContainment(Player scp)
        {
            ServerConsole.AddLog($"SCP {scp.Nickname} was contained.", ConsoleColor.Green);
        }
    }
}