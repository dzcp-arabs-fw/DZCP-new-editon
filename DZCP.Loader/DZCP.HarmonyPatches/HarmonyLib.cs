using HarmonyLib;

[HarmonyPatch(typeof(HarmonyTargetMethod), "TargetMethod")]
public class PatchClass
{
    [HarmonyPrefix]
    static void PrefixMethod()
    {
    }

    [HarmonyPostfix]
    static void PostfixMethod()
    {
    }
}