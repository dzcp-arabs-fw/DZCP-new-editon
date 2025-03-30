using System.Collections.Generic;
using DZCP.API.Models;
using DZCP.Logging;
using PlayerRoles;

namespace DZCP.Roles
{
    public static class CustomRoleManager
    {
        public static Dictionary<string, CustomRole> RegisteredRoles = new();

        public static void RegisterRole(CustomRole role)
        {
            RegisteredRoles[role.RoleId] = role;
            Logger.Info($"Registered role: {role.RoleName}");
        }

        public static bool TryAssignRole(Player player, string roleId)
        {
            if (RegisteredRoles.TryGetValue(roleId, out var role))
            {
                role.ApplyToPlayer(player);
                return true;
            }
            return false;
        }
    }

    public abstract class CustomRole
    {
        public string RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public string Description { get; protected set; }
        public Team  Team { get; protected set; }

        public virtual void ApplyToPlayer(Player player)
        {
            player.SendMessage($"You are now {RoleName}!");
            ApplyStartingInventory(player);
        }

        protected abstract void ApplyStartingInventory(Player player);
    }
}
