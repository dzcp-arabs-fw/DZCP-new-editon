using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnRoleSwapDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<RoleSwapEvent>(HandleRoleSwap);
        }

        private static void HandleRoleSwap(RoleSwapEvent e)
        {
            ServerConsole.AddLog($"[DZCP] تم تبديل الأدوار بين {e.Player1.Nickname} و {e.Player2.Nickname}.", ConsoleColor.DarkBlue);
        }
    }

    public class RoleSwapEvent
    {
        public Player Player1 { get; }
        public Player Player2 { get; }

        public RoleSwapEvent(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}