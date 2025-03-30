using System.Collections.Generic;
using DZCP.API.Models;

namespace DZCP.Analytics
{
    public static class PlayerStatistics
    {
        private static readonly Dictionary<string, Stats> _stats = new();

        public static void RecordKill(Player killer, Player victim)
        {
            GetStats(killer).Kills++;
            GetStats(victim).Deaths++;
        }

        public static Stats GetStats(Player player)
        {
            if (!_stats.ContainsKey(player.UserId))
                _stats[player.UserId] = new Stats();

            return _stats[player.UserId];
        }
    }

    public class Stats
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public double KDR => Deaths == 0 ? Kills : (double)Kills / Deaths;
    }
}
