using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnFacilityLayoutChangeDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<FacilityLayoutChangeEvent>(HandleFacilityLayoutChange);
        }

        private static void HandleFacilityLayoutChange(FacilityLayoutChangeEvent e)
        {
            ServerConsole.AddLog($"[DZCP] تم تغيير تصميم المنطقة: {e.AffectedZone}.", ConsoleColor.Magenta);
        }
    }

    public class FacilityLayoutChangeEvent
    {
        public string AffectedZone { get; }

        public FacilityLayoutChangeEvent(string affectedZone)
        {
            AffectedZone = affectedZone;
        }
    }
}