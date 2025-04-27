using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp330CandyTakenDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp330CandyTakenEvent>(HandleScp330CandyTaken);
        }

        private static void HandleScp330CandyTaken(Scp330CandyTakenEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.Player.Nickname} أخذ حلوى من SCP-330: {e.CandyType}.", ConsoleColor.Magenta);
        }
    }

    public class Scp330CandyTakenEvent
    {
        public Player Player { get; }
        public string CandyType { get; }

        public Scp330CandyTakenEvent(Player player, string candyType)
        {
            Player = player;
            CandyType = candyType;
        }
    }
}