using System.Collections.Generic;
using DZCP.API.Models;
using Eagle._Components.Public.Delegates;
using PlayerRoles.Subroutines;

public class RoleProgression
{
    private void UnlockNewAbility(Player player, string roleId, int newLevel)
    {
        var ability = GetAbilityForLevel(roleId, newLevel);
        if (ability != null)
        {
            AbilitySystem.RegisterAbility(player.UserId,AbilitySystem.TryUseAbility(player, ability));
            player.SendMessage($"New ability unlocked: {ability.Name}");
            PlayUnlockEffect(player);
        }
    }

    private RoleAbility GetAbilityForLevel(string roleId, int level)
    {
        // يمكن استبدال هذا بقاعدة بيانات أو ملف تكوين
        return roleId switch
        {
            "scientist_guard" => level switch
            {
                2 => new RoleAbility("medical_heal", "Heal Self"),
                5 => new RoleAbility("team_heal", "Heal Team"),
                _ => null
            },
            "chaos_scientist" => level switch
            {
                3 => new RoleAbility("scp_knowledge", "SCP Weakness Scan"),
                _ => null
            },
            _ => null
        };
    }

    private void PlayUnlockEffect(Player player)
    {
    }
}

public class RoleAbility
{
    public string Id { get; }
    public string Name { get; }

    public RoleAbility(string id, string name)
    {
        Id = id;
        Name = name;
    }
    public Dictionary<string, RoleLevel> RoleLevels = new();

    public void AddXP(Player player, string roleId, int xp)
    {
        if (!RoleLevels.TryGetValue(roleId, out var level))
        {
            level = new RoleLevel();
            RoleLevels[roleId] = level;
        }

        level.CurrentXP += xp;
        CheckLevelUp(player, roleId, level);
    }

    private void CheckLevelUp(Player player, string roleId, RoleLevel level)
    {
        int requiredXP = 100 * (level.CurrentLevel + 1);
        if (level.CurrentXP >= requiredXP)
        {
            level.CurrentLevel++;

        }
    }
}

public class RoleLevel
{
    public int CurrentLevel { get; set; }
    public int CurrentXP { get; set; }
}
