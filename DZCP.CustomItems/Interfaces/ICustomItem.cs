using DZCP.API.Models;

namespace DZCP.CustomItems.Interfaces
{
    public interface ICustomItem
    {
        uint Id { get; }
        string Name { get; }
        ItemType Type { get; }
        
        void OnSpawn(Player player);
        void OnPickup(Player player);
        void OnDrop(Player player);
    }
}