using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using DZCP.API.Models;
using DZCP.Database;
using DZCP.Logging;

namespace DZCP.Statistics
{
    public static class StatsTracker
    {
        private static readonly ConcurrentDictionary<string, PlayerStats> _playerStats = new();
        private static DateTime _lastSaveTime = DateTime.MinValue;
        private static readonly TimeSpan _saveInterval = TimeSpan.FromMinutes(5);

        public static void Initialize()
        {
        }

        public static void RecordKill(Player killer, Player victim)
        {
            if (killer != null)
            {
                var stats = _playerStats.GetOrAdd(killer.UserId, id => new PlayerStats { UserId = id });
                stats.Kills++;
            }

            if (victim != null)
            {
                var stats = _playerStats.GetOrAdd(victim.UserId, id => new PlayerStats { UserId = id });
                stats.Deaths++;
            }
        }

        public static void RecordRoundWin(Player player)
        {
            if (player != null)
            {
                var stats = _playerStats.GetOrAdd(player.UserId, id => new PlayerStats { UserId = id });
                stats.RoundsWon++;
            }
        }

        public static async Task SaveStats()
        {
            try
            {
                using var connection = await DatabaseManager.GetConnectionAsync();
                // Save stats to database
                _lastSaveTime = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to save stats: {ex}");
            }
        }

        public static PlayerStats GetPlayerStats(string userId)
        {
            return _playerStats.TryGetValue(userId, out var stats) ? stats : new PlayerStats { UserId = userId };
        }
    }

    public class PlayerStats
    {
        public string UserId { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int RoundsWon { get; set; }

        public double KillDeathRatio => Deaths == 0 ? Kills : (double)Kills / Deaths;
    }
}
