using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DZCP.API.Models;
using DZCP.Database;
using DZCP.Logging;

namespace DZCP.Permissions
{
    public static class PermissionManager
    {
        private static readonly Dictionary<string, List<string>> _permissionsCache = new();
        private static bool _initialized;

        public static async Task InitializeAsync()
        {
            if (_initialized) return;

            try
            {
                using var connection = await DatabaseManager.GetConnectionAsync();
                // Load permissions from database
                _initialized = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Permission system initialization failed: {ex}");
            }
        }

        public static async Task ReloadPermissionsAsync()
        {
            _permissionsCache.Clear();
            await InitializeAsync();
        }

        public static bool HasPermission(Player player, string permission)
        {
            if (player == null || string.IsNullOrEmpty(permission))
                return false;

            if (_permissionsCache.TryGetValue(player.UserId, out var permissions))
            {
                return permissions.Contains("*") ||
                       permissions.Contains(permission) ||
                       permissions.Any(p => permission.StartsWith(p + "."));
            }

            return false;
        }

        public static async Task AddPermissionAsync(string userId, string permission)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(permission))
                return;

            if (!_permissionsCache.TryGetValue(userId, out var permissions))
            {
                permissions = new List<string>();
                _permissionsCache[userId] = permissions;
            }

            if (!permissions.Contains(permission))
            {
                permissions.Add(permission);

                try
                {
                    using var connection = await DatabaseManager.GetConnectionAsync();
                    // Save to database
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to save permission: {ex}");
                }
            }
        }
    }
}
