using System;
using DZCP.API.Models;

public class ItemUsedEventArgs : EventArgs
{
    public Player Player { get; }
    public Item Item { get; }

    public ItemUsedEventArgs(Player player, Item item)
    {
        Player = player;
        Item = item;
    }
}