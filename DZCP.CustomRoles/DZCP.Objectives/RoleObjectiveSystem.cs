using System;
using System.Collections.Generic;
using DZCP.API.Models;

namespace DZCP_new_editon.DZCP.CustomRoles.DZCP.Objectives;

public static class RoleObjectiveSystem
{
    private static readonly Dictionary<string, List<RoleObjective>> _objectives = new();

    public static void AssignObjectives(Player player, string roleId)
    {
        if (_objectives.TryGetValue(roleId, out List<RoleObjective> objectives))
        {
            player.CurrentObjectives = objectives;
            player.SendObjectivesList();
        }
    }

    public static void RegisterRoleObjectives(string roleId, List<RoleObjective> objectives)
    {
        _objectives[roleId] = objectives;
    }
}

public class RoleObjective
{
    public string ObjectiveId { get; set; }
    public string Description { get; set; }
    public Action<Player> OnCompletion { get; set; }
}
