using System;

namespace DZCP.Events
{
    public struct RoundStartEvent
    {
        public DateTime StartTime;

        public RoundStartEvent(DateTime time)
        {
            StartTime = time;
        }
    }
}