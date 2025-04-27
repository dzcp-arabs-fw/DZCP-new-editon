using DZCP.API.Enums;
using DZCP.API.Roles;
using UnityEngine;

public class ExampleCustomRole : ICustomRole
{
    public int RoleID => (int)PlayerRole.Scientist + 1; // أول دور مخصص
    public string RoleName => "العميل السري";
    public Team Team { get; } = Team.Chaos;
    public float Health => 150f;
    public ItemType[] StartItems => new[] { ItemType.GunCOM15, ItemType.KeycardChaosInsurgency };
    public Color RoleColor => Color.cyan;

    private ExampleRoleConfig _config;

    public ExampleCustomRole()
    {
        _config = RoleConfig.LoadRoleConfig<ExampleRoleConfig>("SecretAgent");
    }

    public void OnRoleAssigned(GameObject player)
    {
        var nickname = player.GetComponent<NicknameSync>()?.MyNick ?? "لاعب";
        Debug.Log($"[DZCP] {nickname} أصبح الآن {RoleName}");
        
        // تطبيق خصائص الدور من التهيئة
        if (_config.InvisibleOnSpawn)
        {
            MakePlayerInvisible(player);
        }
    }

    public void OnRoleRemoved(GameObject player)
    {
        // تنظيف أي تأثيرات خاصة عند إزالة الدور
    }

    private void MakePlayerInvisible(GameObject player)
    {
        // كود لجعل اللاعب خفياً
    }
}

// تهيئة خاصة بالدور
public class ExampleRoleConfig
{
    public bool InvisibleOnSpawn { get; set; } = true;
    public float SpeedMultiplier { get; set; } = 1.2f;
}