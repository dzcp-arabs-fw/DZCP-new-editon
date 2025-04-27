using System;
using System.Collections.Generic;

namespace DZCP.Events
{
    public static class DZCPEventManager
    {
        private static readonly Dictionary<Type, List<Delegate>> _eventHandlers = new();

        /// <summary>
        /// تسجيل حدث جديد.
        /// </summary>
        public static void Register<T>(Action<T> handler) where T : class
        {
            var eventType = typeof(T);
            if (!_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers[eventType] = new List<Delegate>();
            }

            _eventHandlers[eventType].Add(handler);
        }

        /// <summary>
        /// تنفيذ جميع المستمعين للحدث.
        /// </summary>
        public static void Execute<T>(T eventArgs) where T : class
        {
            var eventType = typeof(T);
            if (_eventHandlers.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    (handler as Action<T>)?.Invoke(eventArgs);
                }
            }
        }
    }
}