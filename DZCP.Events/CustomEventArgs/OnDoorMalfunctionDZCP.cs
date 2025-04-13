using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnDoorMalfunctionDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<DoorMalfunctionEvent>(HandleDoorMalfunction);
        }

        private static void HandleDoorMalfunction(DoorMalfunctionEvent e)
        {
            ServerConsole.AddLog($"[DZCP] حدث خلل في الباب: {e.DoorName}.", ConsoleColor.DarkYellow);
        }
    }

    public class DoorMalfunctionEvent
    {
        public string DoorName { get; }

        public DoorMalfunctionEvent(string doorName)
        {
            DoorName = doorName;
        }
    }
}