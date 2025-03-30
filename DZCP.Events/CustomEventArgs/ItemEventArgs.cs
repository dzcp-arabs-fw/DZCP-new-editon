using DZCP.API.Models;

namespace DZCP.Events.CustomEventArgs
{
    public class ItemEventArgs : System.EventArgs
    {
        public Player Player { get; }
        public Item Item { get; }

        public ItemEventArgs(Player player, Item item)
        {
            Player = player;
            Item = item;
        }
    }
}