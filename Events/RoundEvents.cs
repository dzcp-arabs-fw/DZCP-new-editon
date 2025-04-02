using System;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using RoundRestarting;

namespace DZCP.Events
{
    public class RoundEvents
    {
        [PluginEvent(ServerEventType.RoundStart)]
        public void OnRoundStart()
        {
            ServerConsole.AddLog("[DZCP] بدأت الجولة الجديدة!", ConsoleColor.Green);

            // مثال: إرسال رسالة لجميع اللاعبين
            Server.SendBroadcast("بدأت الجولة! حظاً موفقاً للجميع!", 5);
        }

        [PluginEvent(ServerEventType.RoundEnd)]
        public void OnRoundEnd(RoundSummary.LeadingTeam leadingTeam)
        {
            string teamName = leadingTeam switch
            {
                RoundSummary.LeadingTeam.Anomalies => "SCPs",
                RoundSummary.LeadingTeam.ChaosInsurgency => "التمرد",
                RoundSummary.LeadingTeam.FacilityForces => "الحراس",
                _ => "لا أحد"
            };

            ServerConsole.AddLog($"[DZCP] انتهت الجولة! الفريق الفائز: {teamName}", ConsoleColor.Yellow);
        }
    }
}
