using System;
using PluginAPI.Core;

namespace DZCP.Framework
{
    public class PlayerHintManagerDZCP
    {
        /// <summary>
        /// عرض رسالة تلميحية للاعب.
        /// </summary>
        public static void ShowHint(Player player, string message, int duration = 5)
        {
            if (player == null)
            {
                ServerConsole.AddLog($"[DZCP] لا يمكن عرض التلميح. اللاعب غير موجود.", ConsoleColor.Red);
                return;
            }

            player.ReceiveHint(message, duration);
            ServerConsole.AddLog($"[DZCP] تم عرض تلميح للاعب {player.Nickname}: {message} لمدة {duration} ثانية.", ConsoleColor.Cyan);
        }
    }
}