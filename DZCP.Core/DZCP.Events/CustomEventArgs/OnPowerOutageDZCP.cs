using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnPowerOutageDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<PowerOutageEvent>(HandlePowerOutage);
        }

        private static void HandlePowerOutage(PowerOutageEvent e)
        {
            ServerConsole.AddLog($"[DZCP] انقطاع التيار الكهربائي في المنطقة {e.ZoneName} لمدة {e.Duration} ثانية.", ConsoleColor.Yellow);
        }
    }

    public class PowerOutageEvent
    {
        public string ZoneName { get; }
        public float Duration { get; }

        public PowerOutageEvent(string zoneName, float duration)
        {
            ZoneName = zoneName;
            Duration = duration;
        }
    }
}