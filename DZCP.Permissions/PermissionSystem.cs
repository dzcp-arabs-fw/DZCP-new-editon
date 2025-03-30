using System.Collections.Generic;
using PluginAPI.Core;

namespace DZCP.Permissions
{
    public static class PermissionSystem
    {
        private static readonly Dictionary<string, List<string>> UserPermissions = new();
        
        public static bool HasPermission(Player player, string permission)
        {
            return UserPermissions.TryGetValue(player.UserId, out var perms) && perms.Contains(permission);
        }
    }
}