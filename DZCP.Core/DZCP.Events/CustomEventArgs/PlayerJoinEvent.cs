using DZCP.API;

namespace DZCP.Events
{
    public class PlayerJoinEvent
    {
        public IPlayer Player { get; set; }

        public PlayerJoinEvent(string player)
        {
            Player = Player;
            Player = Player.Nickname;
        }
    }
}