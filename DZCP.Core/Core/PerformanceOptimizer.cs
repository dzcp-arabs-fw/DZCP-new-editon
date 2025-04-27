// DZCP/Core/PerformanceOptimizer.cs

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PluginAPI.Helpers;

public static class PerformanceOptimizer
{
    private static readonly ConcurrentDictionary<Type, MethodInfo[]> _cachedMethods = new();

    public static MethodInfo[] GetOptimizedMethods(Type type)
    {
        return _cachedMethods.GetOrAdd(type, t =>
            t.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => !m.IsAbstract)
                .ToArray());
    }

    public static void PreloadAssemblies()
    {
        Parallel.ForEach(Directory.GetFiles(Paths.Plugins, "*.dll"), file =>
        {
            Assembly.Load(File.ReadAllBytes(file));
        });
    }
}
