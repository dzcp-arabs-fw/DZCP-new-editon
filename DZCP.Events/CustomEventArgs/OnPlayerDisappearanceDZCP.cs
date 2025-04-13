using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnPlayerDisappearanceDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<PlayerDisappearanceEvent>(HandlePlayerDisappearance);
        }

        private static void HandlePlayerDisappearance(PlayerDisappearanceEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.Player.Nickname} بدأ في الاختفاء تدريجياً.", ConsoleColor.DarkRed);
        }
    }

    public class PlayerDisappearanceEvent
    {
        public Player Player { get; }

        public PlayerDisappearanceEvent(Player player)
        {
            Player = player;
        }
    }
}