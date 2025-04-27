using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScp049Cure
    {
        [PluginEvent(ServerEventType.Scp049ResurrectBody)]
        public void HandleScp049Cure(Player scp049, Player target)
        {
            ServerConsole.AddLog($"SCP-049 cured {target.Nickname} into a zombie.", ConsoleColor.DarkMagenta);
        }
    }
}