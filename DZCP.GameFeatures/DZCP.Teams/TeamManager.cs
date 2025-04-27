using System.Collections.Generic;
using DZCP.API.Models;
using UnityEngine;
using DZCP.API.Enums;
using Logger = DZCP.Logging.Logger;

public static class TeamManager
{
    public static List<CustomTeam> CustomTeams = new();
    private static bool _b;

    public static void RegisterTeam(CustomTeam team)
    {
        if (!CustomTeams.Contains(team))
        {
            CustomTeams.Add(team);
            Logger.Info($"Registered team: {team.TeamName}");
        }
    }


    public static void HandlePlayerTeamJoin(Player player, CustomTeam team)
    {
        _b = (player.Role.Team == Team.Custom);
        team.OnPlayerJoined(player);
    }
}

public class CustomTeam
{
    public string TeamId { get; set; }
    public string TeamName { get; set; }
    public Color TeamColor { get; set; }
    public List<Player> Members { get; } = new();

    public virtual void OnPlayerJoined(Player player)
    {
        Members.Add(player);
        player.SendMessage($"Joined {TeamName} team!");
    }
}
