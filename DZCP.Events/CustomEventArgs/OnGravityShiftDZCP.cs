using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnGravityShiftDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<GravityShiftEvent>(HandleGravityShift);
        }

        private static void HandleGravityShift(GravityShiftEvent e)
        {
            ServerConsole.AddLog($"[DZCP] تم تغيير الجاذبية إلى: {e.NewGravityScale}.", ConsoleColor.Gray);
        }
    }

    public class GravityShiftEvent
    {
        public float NewGravityScale { get; }

        public GravityShiftEvent(float newGravityScale)
        {
            NewGravityScale = newGravityScale;
        }
    }
}