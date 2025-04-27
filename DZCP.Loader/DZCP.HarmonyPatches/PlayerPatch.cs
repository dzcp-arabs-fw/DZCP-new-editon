using HarmonyLib;

public class DZCPInitializer
{
    public void Initialize()
    {
        var harmony = new Harmony("com.dzcp.framework");
        harmony.PatchAll();
    }
}