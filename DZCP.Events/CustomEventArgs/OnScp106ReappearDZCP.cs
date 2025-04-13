using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp106ReappearDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp106ReappearEvent>(HandleScp106Reappear);
        }

        private static void HandleScp106Reappear(Scp106ReappearEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-106 ظهر من البعد الجيبي في الموقع: {e.Location}.", ConsoleColor.DarkGray);
        }
    }

    public class Scp106ReappearEvent
    {
        public Player Scp { get; }
        public string Location { get; }

        public Scp106ReappearEvent(Player scp, string location)
        {
            Scp = scp;
            Location = location;
        }
    }
}