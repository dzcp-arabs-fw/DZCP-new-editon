using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp173BlinkDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp173BlinkEvent>(HandleScp173Blink);
        }

        private static void HandleScp173Blink(Scp173BlinkEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-173 أغمض عينيه لمدة {e.Duration} ثانية.", ConsoleColor.Cyan);
        }
    }

    public class Scp173BlinkEvent
    {
        public Player Scp { get; }
        public float Duration { get; }

        public Scp173BlinkEvent(Player scp, float duration)
        {
            Scp = scp;
            Duration = duration;
        }
    }
}