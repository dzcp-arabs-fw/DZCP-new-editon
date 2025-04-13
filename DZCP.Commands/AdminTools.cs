using System;
using DZCP.API.Models;

public class AdminTools
{
    public void MutePlayer(Player player, TimeSpan duration)
    {
        player.IsMuted = true;
        player.MuteExpiry = DateTime.UtcNow.Add(duration);
        Console.WriteLine($"{player.Name} تم كتمه لمدة {duration.TotalMinutes} دقيقة.");
    }

    public void UnmutePlayer(Player player)
    {
        player.IsMuted = false;
        player.MuteExpiry = null;
        Console.WriteLine($"{player.Name} تم فك كتمه.");
    }

    public void BanPlayer(Player player, TimeSpan duration)
    {
        player.IsBanned = true;
        player.BanExpiry = DateTime.UtcNow.Add(duration);
        Console.WriteLine($"{player.Name} تم حظره لمدة {duration.TotalMinutes} دقيقة.");
    }

    public void UnbanPlayer(Player player)
    {
        player.IsBanned = false;
        player.BanExpiry = null;
        Console.WriteLine($"{player.Name} تم فك حظره.");
    }
}