using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace DZCP_project.Core.Paths
{
    public class DZCPPatcherDZCP
    {
        public static DZCPPatcherDZCP Instance { get; private set; }

        public Harmony Harmony { get; private set; }
        public List<IPatch> LoadedPatches { get; } = new List<IPatch>();

        public readonly string PatchesDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Patches");
        public readonly string ConfigsDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Configs");
        public readonly string LogsDir = Path.Combine(Environment.CurrentDirectory, "DZCP", "Logs");

        public DZCPPatcherDZCP()
        {
            Instance = this;
            Harmony = new Harmony("dzcp.patcher");

            // إنشاء المجلدات اللازمة
            Directory.CreateDirectory(PatchesDir);
            Directory.CreateDirectory(ConfigsDir);
            Directory.CreateDirectory(LogsDir);
        }

        public void LoadAllPatches()
        {
            Log("جارٍ تحميل جميع الباتشات...");

            foreach (var dll in Directory.GetFiles(PatchesDir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var patchTypes = assembly.GetTypes()
                        .Where(t => typeof(IPatch).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in patchTypes)
                    {
                        var patch = (IPatch)Activator.CreateInstance(type);
                        patch.Load();
                        LoadedPatches.Add(patch);
                        Log($"تم تحميل الباتش: {patch.Name} v{patch.Version}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"فشل تحميل الباتش {Path.GetFileName(dll)}: {ex.Message}");
                }
            }
        }

        public void ApplyAllPatches()
        {
            Log("جارٍ تطبيق جميع الباتشات...");

            foreach (var patch in LoadedPatches)
            {
                try
                {
                    patch.Apply(Harmony);
                    Log($"تم تطبيق الباتش: {patch.Name}");
                }
                catch (Exception ex)
                {
                    Log($"فشل تطبيق الباتش {patch.Name}: {ex.Message}");
                }
            }
        }

        public void UnpatchAll()
        {
            Log("جارٍ إزالة جميع الباتشات...");
            Harmony.UnpatchAll();
            LoadedPatches.Clear();
        }

        private void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            File.AppendAllText(Path.Combine(LogsDir, "patcher.log"), logEntry + Environment.NewLine);
            Console.WriteLine(logEntry);
        }
    }

    public interface IPatch
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        string Description { get; }

        void Load();
        void Apply(Harmony harmony);
        void Unapply();
    }
}
