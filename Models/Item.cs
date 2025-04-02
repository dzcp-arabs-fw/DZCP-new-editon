using DZCP.API.Enums;

namespace DZCP.API.Models
{
    public class Item
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public float Weight { get; set; }
        public int Durability { get; set; } = 100;
        
        public virtual void Use(Player player)
        {
            // Base implementation
        }
    }
}