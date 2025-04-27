namespace DZCP.Events
{
    public struct PlayerChangeRoleEvent
    {
        public int PlayerId;
        public string OldRole;
        public string NewRole;

        public PlayerChangeRoleEvent(int playerId, string oldRole, string newRole)
        {
            PlayerId = playerId;
            OldRole = oldRole;
            NewRole = newRole;
        }
    }
}