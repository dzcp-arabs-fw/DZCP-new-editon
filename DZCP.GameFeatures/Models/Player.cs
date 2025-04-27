using System;
using System.Collections.Generic;
using DZCP.Permissions;
using DZCP.Roles;

namespace DZCP.API.Models
{
    public class Player
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsMuted { get; set; }
        public DateTime? MuteExpiry { get; set; }
        public bool IsBanned { get; set; }
        public DateTime? BanExpiry { get; set; }
        public string Nickname { get; set; }
        public Item CurrentItem { get; set; }
        public CustomRole Role { get; set; }

        public List<ItemType> Inventory { get; set; } = new();
        public bool IsInvisible { get; set; }
        public List<DZCP_new_editon.DZCP.CustomRoles.DZCP.Objectives.RoleObjective> CurrentObjectives { get; set; } = new();

        public void SendMessage(string message, int i)
        {
            // Implementation to send message to player
        }
        public void UpdateVisibility()
        {
            // كما ورد أعلاه
        }
        public void SendObjectivesList()
        {
            // كما ورد أعلاه
        }
        // إضافة هذه الوظيفة

        public bool HasPermission(string permission)
        {
            return false;
        }

        public void SendMessage(string youDonTHavePermissionToUseThisCommand)
        {
            throw new System.NotImplementedException();
        }
    }
}
