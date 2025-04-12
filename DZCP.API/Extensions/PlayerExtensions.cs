using DZCP.API.Models;

namespace DZCP.API.Extensions
{
    public static class PlayerExtensions
    {
        public static bool IsAdmin(this Player player)
        {
            return player.HasPermission("dzcp.admin");
        }

        public static void SendWarning(this Player player, string message)
        {
            player.SendMessage($"[WARNING] {message}");
        }

        public static void AwardPoints(this Player player, int points)
        {
            // تطبيق نقاط المكافأة
            player.SendMessage($"You earned {points} points!");
        }
        public static bool TryGetItemInHand(this Player player, out string item)
        {
            item = player.CurrentItem.Name;
            return item != null;
        }
    }
}
