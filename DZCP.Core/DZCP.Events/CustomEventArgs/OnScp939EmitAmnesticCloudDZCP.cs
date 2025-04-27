using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp939EmitAmnesticCloudDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp939EmitAmnesticCloudEvent>(HandleScp939EmitAmnesticCloud);
        }

        private static void HandleScp939EmitAmnesticCloud(Scp939EmitAmnesticCloudEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-939 أطلق سحابة الأمينستيك في الموقع: {e.Location}.", ConsoleColor.Gray);
        }
    }

    public class Scp939EmitAmnesticCloudEvent
    {
        public Player Scp { get; }
        public string Location { get; }

        public Scp939EmitAmnesticCloudEvent(Player scp, string location)
        {
            Scp = scp;
            Location = location;
        }
    }
}