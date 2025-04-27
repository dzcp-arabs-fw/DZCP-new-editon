using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp049HealZombieDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp049HealZombieEvent>(HandleScp049HealZombie);
        }

        private static void HandleScp049HealZombie(Scp049HealZombieEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-049 عالج الزومبي {e.Zombie.Nickname}.", ConsoleColor.DarkGreen);
        }
    }

    public class Scp049HealZombieEvent
    {
        public Player Scp { get; }
        public Player Zombie { get; }

        public Scp049HealZombieEvent(Player scp, Player zombie)
        {
            Scp = scp;
            Zombie = zombie;
        }
    }
}