using System.Collections.Generic;
using DZCP.API.Models;

namespace DZCP.Events;

public class Event_System
{
    public interface IPlayerEvent
    {
        void OnPlayerJoin(Player player);
        void OnPlayerDeath(Player player);
        void OnItemUse(Player player, Item item);
    }

    public static class EventManager
    {
        private static readonly List<IPlayerEvent> eventHandlers = new List<IPlayerEvent>();

        public static void Register(IPlayerEvent handler)
        {
            eventHandlers.Add(handler);
        }

        public static void TriggerPlayerJoin(Player player)
        {
            foreach (var handler in eventHandlers)
            {
                handler.OnPlayerJoin(player);
            }
        }

        public static void TriggerPlayerDeath(Player player)
        {
            foreach (var handler in eventHandlers)
            {
                handler.OnPlayerDeath(player);
            }
        }

        public static void TriggerItemUse(Player player, Item item)
        {
            foreach (var handler in eventHandlers)
            {
                handler.OnItemUse(player, item);
            }
        }
    }

}