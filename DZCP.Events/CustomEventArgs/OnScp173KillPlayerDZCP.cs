using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp173KillPlayerDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp173KillPlayerEvent>(HandleScp173KillPlayer);
        }

        private static void HandleScp173KillPlayer(Scp173KillPlayerEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-173 قتل اللاعب: {e.Victim.Nickname}.", ConsoleColor.DarkRed);
        }
    }

    public class Scp173KillPlayerEvent
    {
        public Player Scp { get; }
        public Player Victim { get; }

        public Scp173KillPlayerEvent(Player scp, Player victim)
        {
            Scp = scp;
            Victim = victim;
        }
    }
}