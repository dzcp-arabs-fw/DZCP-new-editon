using System;
using HarmonyLib;

namespace DZCP.Patches
{
    [HarmonyPatch(typeof(GameConsoleTransmission), "SomeMethod")]
    public static class ExamplePatchDZCP
    {
        static void Prefix()
        {
            Console.WriteLine("Prefix: Method is about to be called.");
        }

        static void Postfix()
        {
            Console.WriteLine("Postfix: Method has been executed.");
        }
    }
}