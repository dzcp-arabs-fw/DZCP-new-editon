using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp096KillDuringRageDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp096KillDuringRageEvent>(HandleScp096KillDuringRage);
        }

        private static void HandleScp096KillDuringRage(Scp096KillDuringRageEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-096 قتل اللاعب {e.Victim.Nickname} أثناء الغضب.", ConsoleColor.DarkYellow);
        }
    }

    public class Scp096KillDuringRageEvent
    {
        public Player Scp { get; }
        public Player Victim { get; }

        public Scp096KillDuringRageEvent(Player scp, Player victim)
        {
            Scp = scp;
            Victim = victim;
        }
    }
}