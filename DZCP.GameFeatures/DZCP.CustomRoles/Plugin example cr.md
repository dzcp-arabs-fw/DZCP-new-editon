using DZCP.API.Roles;
using UnityEngine;

public class CustomRolesPlugin
{
public void OnEnabled()
{
// تسجيل الأدوار المخصصة
RoleManager.RegisterRole(new ExampleCustomRole());

        // مثال لتعيين دور للاعب عند الانضمام
        EventSystem.Subscribe<PlayerJoinEvent>(ev =>
        {
            if (ShouldAssignCustomRole(ev.Player))
            {
                RoleManager.AssignRole(ev.Player, (int)playerrole.CustomRoleStart + 1);
            }
        });
    }

    private bool ShouldAssignCustomRole(GameObject player)
    {
        // شروط تعيين الدور المخصص
        return true;
    }
}