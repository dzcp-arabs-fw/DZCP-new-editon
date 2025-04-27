using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp939AttackDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp939AttackEvent>(HandleScp939Attack);
        }

        private static void HandleScp939Attack(Scp939AttackEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-939 هاجم اللاعب: {e.Target.Nickname}.", ConsoleColor.DarkRed);
        }
    }

    public class Scp939AttackEvent
    {
        public Player Scp { get; }
        public Player Target { get; }

        public Scp939AttackEvent(Player scp, Player target)
        {
            Scp = scp;
            Target = target;
        }
    }
}