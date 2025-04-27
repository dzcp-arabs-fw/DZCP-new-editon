using InventorySystem.Items;

namespace DZCP.Events
{
    public struct PlayerDropItemEvent
    {
        public int PlayerId;
        public int ItemId;

        public PlayerDropItemEvent(int pid, int iid)
        {
            PlayerId = pid;
            ItemId = iid;
        }

        public PlayerDropItemEvent(ItemIdentifier itemItemId)
        {
            throw new System.NotImplementedException();
        }
    }
}