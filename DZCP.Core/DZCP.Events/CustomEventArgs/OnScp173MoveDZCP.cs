using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp173MoveDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp173MoveEvent>(HandleScp173Move);
        }

        private static void HandleScp173Move(Scp173MoveEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-173 تحرك بعد توقف لمدة {e.Duration} ثانية.", ConsoleColor.Cyan);
        }
    }

    public class Scp173MoveEvent
    {
        public Player Scp { get; }
        public float Duration { get; }

        public Scp173MoveEvent(Player scp, float duration)
        {
            Scp = scp;
            Duration = duration;
        }
    }
}