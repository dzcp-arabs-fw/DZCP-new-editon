using System;
using DZCP.Framework;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScpContainmentBreachDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<ScpContainmentBreachEvent>(HandleScpContainmentBreach);
        }

        private static void HandleScpContainmentBreach(ScpContainmentBreachEvent e)
        {
            ServerConsole.AddLog("[DZCP] حدث اختراق لاحتواء SCP!", ConsoleColor.Red);
            Cassie.Message("Containment breach detected. Secure all areas!", true, false);
        }
    }

    public class ScpContainmentBreachEvent
    {
        // يمكن إضافة تفاصيل مخصصة لاحقًا إذا لزم الأمر.
    }
}