using System;
using DZCP.Framework;

namespace DZCP.Events
{
    public class OnPlayerEscapeDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<PlayerEscapeEvent>(HandlePlayerEscape);
        }

        private static void HandlePlayerEscape(PlayerEscapeEvent e)
        {
            ServerConsole.AddLog($"[DZCP] اللاعب {e.PlayerName} هرب باستخدام {e.EscapeType}", ConsoleColor.Magenta);
        }
    }

    public class PlayerEscapeEvent
    {
        public string PlayerName { get; }
        public string EscapeType { get; }

        public PlayerEscapeEvent(string playerName, string escapeType)
        {
            PlayerName = playerName;
            EscapeType = escapeType;
        }
    }
}