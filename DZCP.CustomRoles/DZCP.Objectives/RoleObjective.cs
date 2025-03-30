// DZCP.Objectives/RoleObjective.cs

using System;
using DZCP.API.Models;

public class RoleObjective
{
    public string ObjectiveId { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; private set; }
    public Action<Player> OnCompletion { get; set; }

    public void Complete(Player player)
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            OnCompletion?.Invoke(player);
        }
    }
}
