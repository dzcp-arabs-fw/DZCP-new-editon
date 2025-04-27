using System;
using DZCP.API.Models;
using PluginAPI.Core;
using Player = DZCP.API.Models.Player;

namespace DZCP.CustomItems;

public class CT_system
{
    public string Name { get; set; }
    public Action<Player> UseAction { get; set; }
}