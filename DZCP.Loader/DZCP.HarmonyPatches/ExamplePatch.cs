using HarmonyLib;
using DZCP; // استبدل هذا بمساحة الأسماء الفعلية

[HarmonyPatch(typeof(ExamplePatch), "TargetMethod")]
public static class ExamplePatch
{
    public static void Prefix()
    {
        // الكود الذي سيتم تنفيذه قبل استدعاء الطريقة الأصلية
    }

    public static void Postfix()
    {
        // الكود الذي سيتم تنفيذه بعد استدعاء الطريقة الأصلية
    }
}