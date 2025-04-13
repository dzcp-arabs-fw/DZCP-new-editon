using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp106EnterPocketDimensionDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp106EnterPocketDimensionEvent>(HandleScp106EnterPocketDimension);
        }

        private static void HandleScp106EnterPocketDimension(Scp106EnterPocketDimensionEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-106 دخل البعد الجيبي.", ConsoleColor.DarkGray);
        }
    }

    public class Scp106EnterPocketDimensionEvent
    {
        public Player Scp { get; }

        public Scp106EnterPocketDimensionEvent(Player scp)
        {
            Scp = scp;
        }
    }
}