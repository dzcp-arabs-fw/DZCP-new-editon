using System;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace DZCP.Events
{
    public class ServerEvents
    {
        [PluginEvent(ServerEventType.WaitingForPlayers)]
        public void OnWaitingForPlayers()
        {
            ServerConsole.AddLog("[DZCP] في انتظار اللاعبين...", ConsoleColor.Blue);
        }

        [PluginEvent(ServerEventType.RoundStart)]
        public void OnRoundRestart()
        {
            ServerConsole.AddLog("[DZCP] إعادة تشغيل الجولة!", ConsoleColor.Yellow);
        }
    }
}
