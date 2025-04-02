using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class ItemEvents
    {
        [PluginEvent(ServerEventType.PlayerUsedItem)]
        public void OnItemPickup(Player player, ItemType item)
        {
            ServerConsole.AddLog($"[DZCP] {player.Nickname} التقط {item}", ConsoleColor.Magenta);
        }

        [PluginEvent(ServerEventType.PlayerDropItem)]
        public void OnItemDrop(Player player, ItemType item)
        {
            ServerConsole.AddLog($"[DZCP] {player.Nickname} أسقط {item}", ConsoleColor.DarkMagenta);
        }
    }
}
