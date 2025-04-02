using DZCP.API.Models;

namespace DZCP.Events
{
    public class PlayerLeaveEventArgs : System.EventArgs
    {
        public Player Player { get; }
        public string Reason { get; }

        public PlayerLeaveEventArgs(Player player, string reason)
        {
            Player = player;
            Reason = reason;
        }
    }
}
