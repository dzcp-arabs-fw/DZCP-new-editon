using System;
using System.Collections.Generic;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnMassHallucinationDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<MassHallucinationEvent>(HandleMassHallucination);
        }

        private static void HandleMassHallucination(MassHallucinationEvent e)
        {
            foreach (var player in e.AffectedPlayers)
            {
                ServerConsole.AddLog($"[DZCP] اللاعب {player.Nickname} يعاني من هلوسات.", ConsoleColor.DarkCyan);
            }
        }
    }

    public class MassHallucinationEvent
    {
        public List<Player> AffectedPlayers { get; }

        public MassHallucinationEvent(List<Player> affectedPlayers)
        {
            AffectedPlayers = affectedPlayers;
        }
    }
}