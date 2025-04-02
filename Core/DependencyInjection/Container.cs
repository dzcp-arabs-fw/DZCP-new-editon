// DZCP/Core/DependencyInjection/Container.cs

using System;
using System.Collections.Generic;
using DZCP.API.Interfaces;
using DZCP.Services.Database;



public static class DZContainer
{
    private static readonly Dictionary<Type, object> _services = new();

    public static void Register<TService, TImpl>() where TImpl : TService, new()
        => _services[typeof(TService)] = new TImpl();

    public static T Resolve<T>() => (T)_services[typeof(T)];
}

// التسجيل عند التحميل:
