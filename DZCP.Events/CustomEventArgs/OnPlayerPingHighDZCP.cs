using System;
using DZCP.API.Models;
using DZCP.Framework;

namespace DZCP.Events
{
    public class OnPlayerPingHighDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<PlayerPingHighEvent>(HandlePlayerPingHigh);
        }

        private static void HandlePlayerPingHigh(PlayerPingHighEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.PlayerName} لديه بينغ مرتفع: {e.Ping}.", ConsoleColor.Magenta);
            e.Player.SendMessage("البينغ الخاص بك مرتفع جدًا! قد تواجه مشاكل في الاتصال.", 5);
        }
    }

    public class PlayerPingHighEvent
    {
        public Player Player { get; }
        public string PlayerName => Player.Nickname;
        public int Ping { get; }

        public PlayerPingHighEvent(Player player, int ping)
        {
            Player = player;
            Ping = ping;
        }
    }
}