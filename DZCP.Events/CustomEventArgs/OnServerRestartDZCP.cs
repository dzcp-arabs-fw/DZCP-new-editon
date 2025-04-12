using System;
using DZCP.Framework;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnServerRestartDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<ServerRestartEvent>(HandleServerRestart);
        }

        private static void HandleServerRestart(ServerRestartEvent e)
        {
            ServerConsole.AddLog("[DZCP] الخادم يتم إعادة تشغيله الآن...", ConsoleColor.DarkBlue);
            Server.SendBroadcast("الخادم يتم إعادة تشغيله. يرجى الانتظار...", 10);
        }
    }

    public class ServerRestartEvent
    {
        // يمكن إضافة خصائص إضافية إذا لزم الأمر.
    }
}