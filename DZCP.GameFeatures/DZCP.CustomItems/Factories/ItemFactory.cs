using DZCP.API.Enums;
using DZCP.API.Models;

namespace DZCP.CustomItems.Factories
{
    public static class ItemFactory
    {
        public static Item Create(ItemType type)
        {
            return type switch
            {
                ItemType.GunLogicer => new Item { Type = ItemType.GunLogicer, Name = "Logicer Machine Gun" },
                ItemType.GrenadeHE => new Item { Type = ItemType.GrenadeHE, Name = "HE Grenade" },
                _ => new Item { Type = type, Name = type.ToString() }
            };
        }

        public static T CreateCustom<T>() where T : CustomItem, new()
        {
            return new T();
        }
    }
}