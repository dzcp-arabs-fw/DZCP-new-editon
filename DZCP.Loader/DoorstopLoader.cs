using System;
using System.IO;
using System.Reflection;
using HarmonyLib;

namespace DZCP.Framework
{
    public class DoorstopLoader
    {
        private static Harmony _harmonyInstance;
        private static Assembly _loadedAssembly;
        private static string _assemblyFilePath = Path.Combine("DZCP", "ReloadableAssembly.dll");

        public static void Initialize()
        {
            Console.WriteLine("Initializing Harmony and Doorstop loader...");

            // Initialize Harmony instance
            _harmonyInstance = new Harmony("com.dzcp.doorstop");

            // Load the initial assembly
            LoadAssembly();
        }

        public static void Reload()
        {
            Console.WriteLine("Reloading assembly...");

            // Unpatch all existing patches
            _harmonyInstance.UnpatchAll("com.dzcp.doorstop");

            // Clear the loaded assembly
            _loadedAssembly = null;

            // Reload the assembly
            LoadAssembly();
        }

        private static void LoadAssembly()
        {
            if (!File.Exists(_assemblyFilePath))
            {
                Console.WriteLine($"Assembly file not found at {_assemblyFilePath}");
                return;
            }

            try
            {
                // Load the assembly
                byte[] assemblyBytes = File.ReadAllBytes(_assemblyFilePath);
                _loadedAssembly = Assembly.Load(assemblyBytes);

                // Apply Harmony patches
                foreach (Type type in _loadedAssembly.GetTypes())
                {
                    if (type.GetCustomAttribute<HarmonyPatch>() != null)
                    {
                        _harmonyInstance.PatchAll(_loadedAssembly);
                        Console.WriteLine($"Patched: {type.FullName}");
                    }
                }

                Console.WriteLine("Assembly loaded and patched successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load assembly: {ex.Message}");
            }
        }
    }
}