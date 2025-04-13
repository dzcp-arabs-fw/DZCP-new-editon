using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp079TriggerTeslaGateDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp079TriggerTeslaGateEvent>(HandleScp079TriggerTeslaGate);
        }

        private static void HandleScp079TriggerTeslaGate(Scp079TriggerTeslaGateEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-079 فعّل بوابة تسلا في الموقع: {e.GateLocation}.", ConsoleColor.Blue);
        }
    }

    public class Scp079TriggerTeslaGateEvent
    {
        public Player Scp { get; }
        public string GateLocation { get; }

        public Scp079TriggerTeslaGateEvent(Player scp, string gateLocation)
        {
            Scp = scp;
            GateLocation = gateLocation;
        }
    }
}