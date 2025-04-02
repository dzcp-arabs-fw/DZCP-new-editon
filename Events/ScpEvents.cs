using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PlayerRoles.PlayableScps.Scp079;

namespace DZCP.Events
{
    public class ScpEvents
    {
        [PluginEvent(ServerEventType.Scp079LevelUpTier)]
        public void OnScp079LevelUp(Player player, Scp079TierManager tier)
        {
            ServerConsole.AddLog($"[DZCP] SCP-079 ارتقى إلى المستوى {tier}", ConsoleColor.DarkMagenta);
        }

        [PluginEvent(ServerEventType.Scp096Enraging)]
        public void OnScp096Enrage(Player player)
        {
            ServerConsole.AddLog($"[DZCP] SCP-096 أصبح غاضباً!", ConsoleColor.Red);
        }
    }
}
