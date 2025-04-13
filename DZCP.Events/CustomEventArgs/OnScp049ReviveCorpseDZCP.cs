using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp049ReviveCorpseDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp049ReviveCorpseEvent>(HandleScp049ReviveCorpse);
        }

        private static void HandleScp049ReviveCorpse(Scp049ReviveCorpseEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-049 أحيا الجثة في الموقع: {e.Location}.", ConsoleColor.DarkGreen);
        }
    }

    public class Scp049ReviveCorpseEvent
    {
        public Player Scp { get; }
        public string Location { get; }

        public Scp049ReviveCorpseEvent(Player scp, string location)
        {
            Scp = scp;
            Location = location;
        }
    }
}