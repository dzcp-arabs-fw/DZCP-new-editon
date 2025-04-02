// DZCP/API/Events/PlayerDamageEvent.cs
using DZCP.API.Interfaces;
using DZCP.API.Models;

namespace DZCP.API.Events
{
    public class PlayerDamageEvent : IEvent
    {
        public Player Player { get; }
        public float Damage { get; set; }
        public bool IsCancelled { get; set; }

        public PlayerDamageEvent(Player player, float damage)
        {
            Player = player;
            Damage = damage;
        }
    }
}
