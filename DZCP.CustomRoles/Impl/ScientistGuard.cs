using DZCP.API.Models;
using DZCP.Roles;
using PlayerRoles;

public class ScientistGuard : CustomRole
{
    public ScientistGuard()
    {
        RoleId = "scientist_guard";
        RoleName = "Scientist Guard";
        Description = "MTF unit specialized in protecting scientists";
        Team = Team.MTF;
    }

    protected override void ApplyStartingInventory(Player player)
    {
        player.Inventory.Add(ItemType.GunCOM15);
        player.Inventory.Add(ItemType.Medkit);
        player.Inventory.Add(ItemType.Radio);
    }
}
