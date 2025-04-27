using System;
using DZCP.Framework;
using DZCP.Types;
using PluginAPI.Core;

namespace DZCP.Events
{
    public class OnScp939MimicVoiceDZCP
    {
        public static void Initialize()
        {
            DZCPEventManager.Register<Scp939MimicVoiceEvent>(HandleScp939MimicVoice);
        }

        private static void HandleScp939MimicVoice(Scp939MimicVoiceEvent e)
        {
            ServerConsole.AddLog($"[DZCP] SCP-939 قلد الصوت: {e.MimickedVoice}.", ConsoleColor.Red);
        }
    }

    public class Scp939MimicVoiceEvent
    {
        public Player Scp { get; }
        public string MimickedVoice { get; }

        public Scp939MimicVoiceEvent(Player scp, string mimickedVoice)
        {
            Scp = scp;
            MimickedVoice = mimickedVoice;
        }
    }
}