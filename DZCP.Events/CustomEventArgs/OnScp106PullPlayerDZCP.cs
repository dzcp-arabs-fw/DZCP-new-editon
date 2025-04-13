using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp106PullPlayerDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp106PullPlayerEvent>(HandleScp106PullPlayer);
        }

        private static void HandleScp106PullPlayer(Scp106PullPlayerEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-106 سحب اللاعب {e.Target.Nickname} إلى البعد الجيبي.", ConsoleColor.DarkRed);
        }
    }

    public class Scp106PullPlayerEvent
    {
        public Player Scp { get; }
        public Player Target { get; }

        public Scp106PullPlayerEvent(Player scp, Player target)
        {
            Scp = scp;
            Target = target;
        }
    }
}