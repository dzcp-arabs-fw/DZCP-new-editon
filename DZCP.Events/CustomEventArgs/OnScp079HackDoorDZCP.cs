using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp079HackDoorDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp079HackDoorEvent>(HandleScp079HackDoor);
        }

        private static void HandleScp079HackDoor(Scp079HackDoorEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-079 اخترق الباب {e.DoorName}.", ConsoleColor.DarkMagenta);
        }
    }

    public class Scp079HackDoorEvent
    {
        public Player Scp { get; }
        public string DoorName { get; }

        public Scp079HackDoorEvent(Player scp, string doorName)
        {
            Scp = scp;
            DoorName = doorName;
        }
    }
}