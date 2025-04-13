using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp079CloseDoorDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp079CloseDoorEvent>(HandleScp079CloseDoor);
        }

        private static void HandleScp079CloseDoor(Scp079CloseDoorEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-079 أغلق الباب: {e.DoorName}.", ConsoleColor.Cyan);
        }
    }

    public class Scp079CloseDoorEvent
    {
        public Player Scp { get; }
        public string DoorName { get; }

        public Scp079CloseDoorEvent(Player scp, string doorName)
        {
            Scp = scp;
            DoorName = doorName;
        }
    }
}