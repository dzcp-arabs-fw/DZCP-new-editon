using System;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace DZCP.NewEdition.Events
{
    public class MapEvents
    {
        [PluginEvent(ServerEventType.GeneratorActivated)]
        public void OnGeneratorActivated(Generator generator)
        {
            ServerConsole.AddLog($"[DZCP] تم تفعيل المولد #{generator.IsActivationReady}", ConsoleColor.Green);
        }

        [PluginEvent(ServerEventType.WarheadStart)]
        public void OnWarheadStart()
        {
            ServerConsole.AddLog("[DZCP] تم تفعيل الرأس الحربي!", ConsoleColor.Red);
        }
    }
}
