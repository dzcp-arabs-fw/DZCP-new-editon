using System.Collections.Generic;
using DZCP.API.Models;

namespace DZCP.RPG
{
    public static class PlayerLeveling
    {
        private static readonly Dictionary<string, PlayerStats> _playerStats = new();

        public static void AddXP(Player player, int xp)
        {
            if (!_playerStats.ContainsKey(player.UserId))
                _playerStats[player.UserId] = new PlayerStats();

            _playerStats[player.UserId].XP += xp;
            CheckLevelUp(player);
        }

        private static void CheckLevelUp(Player player)
        {
            var stats = _playerStats[player.UserId];
            int requiredXP = stats.Level * 100;

            if (stats.XP >= requiredXP)
            {
                stats.Level++;
                player.SendMessage($"Level up! Now level {stats.Level}");
            }
        }
    }

    public class PlayerStats
    {
        public int Level { get; set; } = 1;
        public int XP { get; set; }
    }
}
