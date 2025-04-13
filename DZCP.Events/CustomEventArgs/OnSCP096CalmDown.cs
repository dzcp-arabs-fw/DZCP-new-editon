using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp096CalmDownDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp096CalmDownEvent>(HandleScp096CalmDown);
        }

        private static void HandleScp096CalmDown(Scp096CalmDownEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-096 هدأ بعد الغضب.", ConsoleColor.Blue);
        }
    }

    public class Scp096CalmDownEvent
    {
        public Player Scp { get; }

        public Scp096CalmDownEvent(Player scp)
        {
            Scp = scp;
        }
    }
}