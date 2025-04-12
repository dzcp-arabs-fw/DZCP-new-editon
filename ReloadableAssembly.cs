using System;
using HarmonyLib;

namespace ReloadableAssembly
{
    [HarmonyPatch(typeof(GameConsoleTransmission), "SomeMethod")]
    public static class ExamplePatch
    {
        static void Prefix()
        {
            // الكود الذي يتم تنفيذه قبل الوظيفة الأصلية
            Console.WriteLine("Prefix: Method called!");
        }

        static void Postfix()
        {
            // الكود الذي يتم تنفيذه بعد الوظيفة الأصلية
            Console.WriteLine("Postfix: Method finished!");
        }
    }
}