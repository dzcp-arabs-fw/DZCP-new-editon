using System;
using DZCP.Framework;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnTeslaGateTriggeredDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<TeslaGateTriggeredEvent>(HandleTeslaGateTriggered);
        }

        private static void HandleTeslaGateTriggered(TeslaGateTriggeredEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.PlayerName} قام بتفعيل بوابة تسلا.", ConsoleColor.Yellow);
            ShowHint("لقد قمت بتفعيل بوابة تسلا! كن حذرًا!", 3);
        }

        private static void ShowHint(string message, int i)
        {
            throw new NotImplementedException();
        }
    }

    public class TeslaGateTriggeredEvent
    {
        public Player Player { get; }
        public string PlayerName => Player.Nickname;

        public TeslaGateTriggeredEvent(Player player)
        {
            Player = player;
        }
    }
}