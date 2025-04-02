// DZCP/API/Events/EventSystem.cs

using System;
using System.Collections.Generic;
using DZCP.API.Events;
using DZCP.Logging;
using Hints;
using Newtonsoft.Json;

public static class EventSystem
{
    private static readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public static void Subscribe<T>(Action<T> handler) where T : IEvent
    {
        var eventType = typeof(T);
        if (!_handlers.ContainsKey(eventType))
            _handlers[eventType] = new List<Delegate>();

        _handlers[eventType].Add(handler);
    }

    public static void Publish<T>(T @event) where T : IEvent
    {
        if (!_handlers.TryGetValue(typeof(T), out var handlers))
            return;

        foreach (var handler in handlers)
        {
            try
            {
                // دعم حقن التبعيات في المعالجين
                if (handler.Target is Required diObject)
                {
                    ;
                }
                ((Action<T>)handler)(@event);
            }
            catch (Exception ex)
            {
                Logger.Error($"Event Error: {ex}");
            }
        }
    }

    private static void Format(string s, Exception exception)
    {
        throw new System.NotImplementedException();
    }
}
