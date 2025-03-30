using DZCP.API.Models;

namespace DZCP.Events
{
    public class PlayerJoinEventArgs : System.EventArgs
    {
        public Player Player { get; }
        public bool IsAllowed { get; set; } = true;

        public PlayerJoinEventArgs(Player player)
        {
            Player = player;
        }
    }
}
