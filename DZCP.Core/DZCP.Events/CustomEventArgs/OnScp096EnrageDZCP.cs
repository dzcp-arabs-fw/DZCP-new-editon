using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp096EnrageDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp096EnrageEvent>(HandleScp096Enrage);
        }

        private static void HandleScp096Enrage(Scp096EnrageEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-096 دخل في حالة غضب بسبب اللاعب: {e.Target.Nickname}.", ConsoleColor.Red);
        }
    }

    public class Scp096EnrageEvent
    {
        public Player Scp { get; }
        public Player Target { get; }

        public Scp096EnrageEvent(Player scp, Player target)
        {
            Scp = scp;
            Target = target;
        }
    }
}