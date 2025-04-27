using HarmonyLib;
using System;

namespace SCPSL.Framework
{
    public static class HarmonyInitializer
    {
        private static Harmony _harmonyInstance;

        public static void Initialize(string id)
        {
            if (_harmonyInstance != null)
            {
                Console.WriteLine("[Framework] Harmony is already initialized.");
                return;
            }

            try
            {
                _harmonyInstance = new Harmony(id);
                _harmonyInstance.PatchAll();
                Console.WriteLine("[Framework] Harmony initialized successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Framework] Failed to initialize Harmony: {ex.Message}");
            }
        }

        public static void Shutdown()
        {
            if (_harmonyInstance == null)
            {
                Console.WriteLine("[Framework] Harmony is not initialized.");
                return;
            }

            try
            {
                _harmonyInstance.UnpatchAll(_harmonyInstance.Id);
                Console.WriteLine("[Framework] Harmony unpatched successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Framework] Failed to unpatch Harmony: {ex.Message}");
            }
        }
    }
}