using System;
using System.IO;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using PluginAPI.Core.Attributes;

namespace DZCP_project.Core.Paths
{
    public class GamePatcherDZCP
    {
        public static GamePatcherDZCP Instance { get; private set; }
        private Harmony _harmony;

        private readonly string _patchesDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Patches");

        [PluginEntryPoint("DZCP Game Patcher", "1.0.0", "In-Game Patching System", "DZCP Team")]
        public void LoadPatcher()
        {
            Instance = this;
            _harmony = new Harmony("dzcp.patches");

            try
            {
                Directory.CreateDirectory(_patchesDir);
                LoadAllPatches();

                ServerConsole.AddLog("[DZCP] Game Patcher initialized successfully!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] Patcher Error: {ex}", ConsoleColor.Red);
            }
        }

        private void LoadAllPatches()
        {
            foreach (var dll in Directory.GetFiles(_patchesDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var patchTypes = assembly.GetTypes()
                        .Where(t => t.GetCustomAttributes(typeof(GamePatchAttribute), false).Length > 0);

                    foreach (var type in patchTypes)
                    {
                        var patch = Activator.CreateInstance(type);
                        var initMethod = type.GetMethod("Initialize");
                        initMethod?.Invoke(patch, null);

                        ServerConsole.AddLog($"[DZCP] Applied patch: {type.Name}", ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    ServerConsole.AddLog($"[DZCP] Failed to load patch {Path.GetFileName(dll)}: {ex.Message}", ConsoleColor.Red);
                }
            }
        }

        public void ApplyPatch(Assembly original, Type patch)
        {
            try
            {
                _harmony.PatchAll(original);
                ServerConsole.AddLog($"[DZCP] Successfully patched: {original.FullName}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] Failed to patch {original.FullName}: {ex.Message}", ConsoleColor.Red);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class GamePatchAttribute : Attribute
    {
        public Type TargetType { get; }
        public string TargetMethod { get; }

        public GamePatchAttribute(Type targetType, string targetMethod)
        {
            TargetType = targetType;
            TargetMethod = targetMethod;
        }
    }
}
