using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnMysteriousMessageDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<MysteriousMessageEvent>(HandleMysteriousMessage);
        }

        private static void HandleMysteriousMessage(MysteriousMessageEvent e)
        {
            ServerConsole.AddLog($"[DZCP] رسالة غامضة في {e.Location}: {e.MessageContent}", ConsoleColor.DarkGreen);
        }
    }

    public class MysteriousMessageEvent
    {
        public string MessageContent { get; }
        public string Location { get; }

        public MysteriousMessageEvent(string messageContent, string location)
        {
            MessageContent = messageContent;
            Location = location;
        }
    }
}