using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class OnScpDamagePlayer
    {
        [PluginEvent(ServerEventType.PlayerDamage)]
        public void HandleScpDamagePlayer(Player scp, Player target, DamageType damageType)
        {
            ServerConsole.AddLog($"SCP {scp.Nickname} damaged player {target.Nickname} using {damageType}.", ConsoleColor.Red);
        }
    }
}