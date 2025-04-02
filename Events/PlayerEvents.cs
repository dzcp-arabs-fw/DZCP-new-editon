using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class PlayerEvents
    {
        [PluginEvent(ServerEventType.PlayerJoined)]
        public void OnPlayerJoined(Player player)
        {
            ServerConsole.AddLog($"[DZCP] {player.Nickname} انضم إلى السيرفر", ConsoleColor.Cyan);

            // مثال: إرسال رسالة ترحيب
            player.SendBroadcast($"مرحباً {player.Nickname} في سيرفرنا!", 5);
        }

        [PluginEvent(ServerEventType.PlayerLeft)]
        public void OnPlayerLeft(Player player)
        {
            ServerConsole.AddLog($"[DZCP] {player.Nickname} غادر السيرفر", ConsoleColor.DarkCyan);
        }

        [PluginEvent(ServerEventType.PlayerDeath)]
        public void OnPlayerDeath(Player victim, Player killer, DamageType type)
        {
            string deathMessage = killer != null ?
                $"{victim.Nickname} قتل بواسطة {killer.Nickname}" :
                $"{victim.Nickname} مات";

            ServerConsole.AddLog($"[DZCP] {deathMessage}", ConsoleColor.Red);
        }
    }
}
