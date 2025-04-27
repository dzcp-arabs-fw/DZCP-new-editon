using System;
using DZCP.Framework;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnWarheadDetonatedDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<WarheadDetonatedEvent>(HandleWarheadDetonated);
        }

        private static void HandleWarheadDetonated(WarheadDetonatedEvent e)
        {
            ServerConsole.AddLog("[DZCP] الرأس النووي انفجر! النهاية قادمة!", ConsoleColor.DarkRed);
            Server.SendBroadcast("الرأس النووي انفجر! اللعبة انتهت.", 10);
        }
    }

    public class WarheadDetonatedEvent
    {
    }
    namespace DZCP.Events
    {
        public struct WarheadDetonatedEvent
        {
            public string DetonatedBy;

            public WarheadDetonatedEvent(string detonatedBy)
            {
                DetonatedBy = detonatedBy;
            }
        }
    }

        // يمكن إضافة خصائص إضافية إذا لزم الأمر.
    }
