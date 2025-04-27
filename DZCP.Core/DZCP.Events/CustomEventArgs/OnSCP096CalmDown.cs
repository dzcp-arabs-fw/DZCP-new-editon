using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DZCP.Core.DZCP.Events.CustomEventArgs
{
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
    public static class EventManager
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
            ServerConsole.AddLog($"[EventManager] Registered event: {gameEvent.EventName}", ConsoleColor.Green);
        }

        /// <summary>
        /// إلغاء تسجيل حدث.
        /// </summary>
        public static void UnregisterEvent(IGameEvent gameEvent)
        {
            if (RegisteredEvents.ContainsKey(gameEvent.EventName))
            {
                RegisteredEvents[gameEvent.EventName].Remove(gameEvent);
                ServerConsole.AddLog($"[EventManager] Unregistered event: {gameEvent.EventName}", ConsoleColor.Yellow);
            }
        }

        /// <summary>
        /// استدعاء حدث معين.
        /// </summary>
        public static async Task InvokeEventAsync(string eventName, params object[] args)
        {
            if (!RegisteredEvents.ContainsKey(eventName))
            {
                ServerConsole.AddLog($"[EventManager] No listeners for event: {eventName}", ConsoleColor.Red);
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
                    ServerConsole.AddLog($"[EventManager] Error in event {gameEvent.EventName}: {ex.Message}", ConsoleColor.Red);
                }
            }
        }
    }
}