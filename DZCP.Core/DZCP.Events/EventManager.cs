using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public static void Invoke<T>(T args)
        {
            if (_events.TryGetValue(typeof(T), out var handler))
            {
                (handler as Action<T>)?.Invoke(args);
            }
        }
            /// <summary>
    /// واجهة الأحداث داخل اللعبة.
    /// </summary>
    public interface IGameEvent
    {
        string EventName { get; }
        Task HandleEventAsync(params object[] args);
    }

    /// <summary>
    /// مدير الأحداث داخل اللعبة.
    /// </summary>
    public static class EventManagerDelegates
    {
        private static readonly Dictionary<string, List<IGameEvent>> RegisteredEvents = new();

        /// <summary>
        /// تسجيل حدث جديد.
        /// </summary>
        public static void RegisterEvent(IGameEvent gameEvent)
        {
            if (!RegisteredEvents.ContainsKey(gameEvent.EventName))
                RegisteredEvents[gameEvent.EventName] = new List<IGameEvent>();

            RegisteredEvents[gameEvent.EventName].Add(gameEvent);
            Console.WriteLine($"[EventManager] Registered event: {gameEvent.EventName}");
        }

        /// <summary>
        /// إلغاء تسجيل حدث.
        /// </summary>
        public static void UnregisterEvent(IGameEvent gameEvent)
        {
            if (RegisteredEvents.ContainsKey(gameEvent.EventName))
            {
                RegisteredEvents[gameEvent.EventName].Remove(gameEvent);
                Console.WriteLine($"[EventManager] Unregistered event: {gameEvent.EventName}");
            }
        }

        /// <summary>
        /// استدعاء حدث معين.
        /// </summary>
        public static async Task InvokeEventAsync(string eventName, params object[] args)
        {
            if (!RegisteredEvents.ContainsKey(eventName))
            {
                Console.WriteLine($"[EventManager] No listeners for event: {eventName}");
                return;
            }

            foreach (var gameEvent in RegisteredEvents[eventName])
            {
                try
                {
                    await gameEvent.HandleEventAsync(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[EventManager] Error in event {gameEvent.EventName}: {ex.Message}");
                }
            }
        }
    }
    }
    }

