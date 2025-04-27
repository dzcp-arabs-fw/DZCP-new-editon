using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DZCP.API.Models;

public static class AbilitySystem
{
    private static readonly Dictionary<string, Action<Player>> _abilities = new();

    public static void RegisterAbility(string abilityId, Action<Player> action)
    {
        _abilities[abilityId] = action;
    }

    public static bool TryUseAbility(Player player, string abilityId)
    {
        if (_abilities.TryGetValue(abilityId, out var action))
        {
            action(player);
            return true;
        }
        return false;
    }

    public static Action<Player> TryUseAbility(Player player, RoleAbility abilityId)
    {
        throw new NotImplementedException();
    }
}

// مثال: قدرة الاختفاء للدكتور المختفي

internal class Program
{
    public static void Main(string[] args)
    {
        AbilitySystem.RegisterAbility("ghost_doctor_invis", player =>
        {
            player.IsInvisible = true;
            Task.Delay(30000).ContinueWith(_ => player.IsInvisible = false);
        });
    }
}
