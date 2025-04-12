using System;
using HarmonyLib;

namespace DZCP.Framework
{
    public static class HarmonyManager
    {
        private static Harmony harmonyInstance;

        /// <summary>
        /// تهيئة Harmony مع معرف فريد.
        /// </summary>
        /// <param name="id">معرف Harmony</param>
        public static void Initialize(string id)
        {
            if (harmonyInstance != null)
            {
                Console.WriteLine("Harmony already initialized.");
                return;
            }

            harmonyInstance = new Harmony(id);
            Console.WriteLine($"Harmony initialized with ID: {id}");
        }

        /// <summary>
        /// تطبيق جميع التعديلات (Patches) من التجميعات الحالية.
        /// </summary>
        public static void ApplyAllPatches()
        {
            if (harmonyInstance == null)
            {
                Console.WriteLine("Harmony is not initialized.");
                return;
            }

            harmonyInstance.PatchAll();
            Console.WriteLine("All patches applied.");
        }

        /// <summary>
        /// إزالة جميع التعديلات (Unpatch All).
        /// </summary>
        public static void RemoveAllPatches()
        {
            if (harmonyInstance == null)
            {
                Console.WriteLine("Harmony is not initialized.");
                return;
            }

            harmonyInstance.UnpatchAll(harmonyInstance.Id);
            Console.WriteLine("All patches removed.");
        }
    }
}