using System.Collections.Generic;
using DZCP.API.Models;
using DZCP.CustomItems.Interfaces;

namespace DZCP.CustomItems.Managers
{
    public static class CustomItemManager
    {
        private static readonly Dictionary<uint, ICustomItem> _customItems = new();

        public static void Register(ICustomItem item)
        {
            if (!_customItems.ContainsKey(item.Id))
            {
                _customItems.Add(item.Id, item);
            }
        }

        public static bool TryGetItem(uint id, out ICustomItem item)
        {
            return _customItems.TryGetValue(id, out item);
        }

        public static bool IsCustomItem(Item item)
        {
            return _customItems.ContainsKey(item.Id);
        }
    }
}