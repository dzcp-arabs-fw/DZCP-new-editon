using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp0492KillPlayerDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp0492KillPlayerEvent>(HandleScp0492KillPlayer);
        }

        private static void HandleScp0492KillPlayer(Scp0492KillPlayerEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-049-2 قتل اللاعب: {e.Victim.Nickname}.", ConsoleColor.DarkGreen);
        }
    }

    public class Scp0492KillPlayerEvent
    {
        public Player Scp { get; }
        public Player Victim { get; }

        public Scp0492KillPlayerEvent(Player scp, Player victim)
        {
            Scp = scp;
            Victim = victim;
        }
    }
}