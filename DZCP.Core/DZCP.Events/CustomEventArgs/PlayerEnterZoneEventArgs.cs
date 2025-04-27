using System;
using DZCP.API.Models;

public class PlayerEnterZoneEventArgs : EventArgs
{
    public Player Player { get; }
    public string ZoneName { get; }

    public PlayerEnterZoneEventArgs(Player player, string zoneName)
    {
        Player = player;
        ZoneName = zoneName;
    }
}