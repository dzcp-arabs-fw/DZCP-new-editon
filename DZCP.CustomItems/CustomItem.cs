using PluginAPI.Core;

namespace DZCP.CustomItems
{
    public abstract class CustomItem
    {
        public abstract uint Id { get; set; }
        public abstract string Name { get; set; }
        public abstract ItemType Type { get; set; }
        
        public virtual void OnSpawn(Player player) { }
        public virtual void OnPickup(Player player) { }
    }
}