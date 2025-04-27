using System;
using System.Collections.Generic;

namespace DZCP.Core
{
    public static class EventManager
    {
        private static readonly Dictionary<Type, List<Delegate>> listeners = new();

        public static void Register<T>(Action<T> handler)
        {
            if (!listeners.ContainsKey(typeof(T)))
                listeners[typeof(T)] = new List<Delegate>();
            listeners[typeof(T)].Add(handler);
        }

        public static void Fire<T>(T ev)
        {
            if (listeners.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var h in handlers)
                    ((Action<T>)h)(ev);
            }
        }
    }
}