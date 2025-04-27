namespace DZCP.Events
{
    public struct PlayerLeaveEvent
    {
        public string PlayerName;
        public string DisconnectReason;
        public int PlayerId;

        public PlayerLeaveEvent(string name, string reason, int id)
        {
            PlayerName = name;
            DisconnectReason = reason;
            PlayerId = id;
        }
    }
}