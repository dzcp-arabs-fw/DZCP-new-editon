using System;
using System.Collections.Generic;

namespace DZCP.Events
{
    public static class EventManager
    {
        private static readonly Dictionary<Type, Delegate> _events = new();

        public static event Action<PlayerJoinEventArgs> OnPlayerJoin
        {
            add => Subscribe(value);
            remove => Unsubscribe(value);
        }

        public static event Action<PlayerLeaveEventArgs> OnPlayerLeave
        {
            add => Subscribe(value);
            remove => Unsubscribe(value);
        }

        private static void Subscribe<T>(Action<T> handler) where T : EventArgs
        {
            if (_events.TryGetValue(typeof(T), out var existing))
            {
                _events[typeof(T)] = Delegate.Combine(existing, handler);
            }
            else
            {
                _events[typeof(T)] = handler;
            }
        }

        private static void Unsubscribe<T>(Action<T> handler) where T : EventArgs
        {
            if (_events.TryGetValue(typeof(T), out var existing))
            {
                _events[typeof(T)] = Delegate.Remove(existing, handler);
            }
        }

        public static void Invoke<T>(T args) where T : EventArgs
        {
            if (_events.TryGetValue(typeof(T), out var handler))
            {
                (handler as Action<T>)?.Invoke(args);
            }
        }
    }
}
