using System.Collections.Concurrent;
using System.Collections.Generic;
using DZCP.API.Roles;
using PluginAPI.Core;

namespace DZCP.Cosmetics
{
    public static class CosmeticManager
    {
        private static readonly ConcurrentDictionary<string, List<Cosmetic>> PlayerCosmetics = new();

        public static void UnlockCosmetic(Player player, Cosmetic cosmetic)
        {
            PlayerCosmetics.AddOrUpdate(player.UserId,
                id => new List<Cosmetic> { cosmetic },
                (id, list) => { list.Add(cosmetic); return list; });
        }

        public static bool HasCosmetic(Player player, string cosmeticId)
        {
            return PlayerCosmetics.TryGetValue(player.UserId, out var cosmetics) &&
                   cosmetics.Exists(c => c.Id == cosmeticId);
        }
    }

    public class Cosmetic
    {
        public string Id { get; set; }
        public CosmeticType Type { get; set; }
        public string Name { get; set; }
    }

    public enum CosmeticType { Hat, Badge, Skin }
}
