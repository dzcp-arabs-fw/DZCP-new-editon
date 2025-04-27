using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp018ThrownDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp018ThrownEvent>(HandleScp018Thrown);
        }

        private static void HandleScp018Thrown(Scp018ThrownEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.Player.Nickname} رمى SCP-018 (Jackie).", ConsoleColor.Yellow);
        }
    }

    public class Scp018ThrownEvent
    {
        public Player Player { get; }

        public Scp018ThrownEvent(Player player)
        {
            Player = player;
        }
    }
}