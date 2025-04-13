using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnAlphaWarheadActivatedDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<AlphaWarheadActivatedEvent>(HandleAlphaWarheadActivated);
        }

        private static void HandleAlphaWarheadActivated(AlphaWarheadActivatedEvent e)
        {
            ServerConsole.AddLog($"[DZCP] تم تفعيل رأس الحربة النووية من قبل {e.Activator.Nickname}.", ConsoleColor.Red);
        }
    }

    public class AlphaWarheadActivatedEvent
    {
        public Player Activator { get; }

        public AlphaWarheadActivatedEvent(Player activator)
        {
            Activator = activator;
        }
    }
}