using System;
using System.Collections.Generic;
using DZCP.API.Models;
using UnityEngine;

namespace DZCP.API.Roles
{
    /// <summary>
    /// النظام المركزي لإدارة الأدوار المخصصة
    /// </summary>
    public static class RoleManager
    {
        private static readonly Dictionary<int, ICustomRole> _registeredRoles = new();
        private static readonly Dictionary<GameObject, ICustomRole> _playerRoles = new();

        /// <summary>
        /// تسجيل دور جديد في النظام
        /// </summary>
        public static void RegisterRole(ICustomRole role)
        {
            if (_registeredRoles.ContainsKey(role.RoleID))
            {
                Debug.LogWarning($"[DZCP] تم تجاهل تسجيل دور مكرر: {role.RoleName} (ID: {role.RoleID})");
                return;
            }

            _registeredRoles.Add(role.RoleID, role);
            Debug.Log($"[DZCP] تم تسجيل دور جديد: {role.RoleName}");
        }

        /// <summary>
        /// تعيين دور للاعب
        /// </summary>
        public static bool AssignRole(GameObject player, int roleId)
        {
            if (!_registeredRoles.TryGetValue(roleId, out var role))
                return false;

            // إزالة أي دور سابق
            if (_playerRoles.TryGetValue(player, out var oldRole))
            {
                oldRole.OnRoleRemoved(player);
            }

            // تعيين الدور الجديد
            _playerRoles[player] = role;
            role.OnRoleAssigned(player);
            
            // تحديث مكونات اللاعب
            UpdatePlayerComponents(player, role);
            
            return true;
        }

        private static void UpdatePlayerComponents(GameObject player, ICustomRole role)
        {
            // هنا يتم تحديث مكونات اللاعب حسب الدور
            var playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                player.name = role.Health.ToString();
            }

            // إعطاء العناصر المبدئية
            foreach (var item in role.StartItems)
            {
            }
        }
    }
}