using System;
using DZCP.API.Models;
using DZCP.Framework;

namespace DZCP.Events
{
    public class OnItemUsedDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<ItemUsedEvent>(HandleItemUsed);
        }

        private static void HandleItemUsed(ItemUsedEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.PlayerName} استخدم العنصر {e.ItemName}.", ConsoleColor.Cyan);
            showhint($"لقد استخدمت {e.ItemName}.", 5);
        }

        private static void showhint(string s, int i)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemUsedEvent
    {
        public Player Player { get; }
        public string PlayerName => Player.Nickname;
        public string ItemName { get; }

        public ItemUsedEvent(Player player, string itemName)
        {
            Player = player;
            ItemName = itemName;
        }
    }
}