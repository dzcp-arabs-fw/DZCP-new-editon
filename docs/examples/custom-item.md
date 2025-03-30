# Creating Custom Items

## Basic Example:
```csharp
public class GrenadeLauncher : CustomItem
{
    public override uint Id => 1001;
    public override string Name => "Grenade Launcher";
    public override ItemType Type => ItemType.GunLogicer;

    public override void OnSpawn(Player player)
    {
        player.SendMessage("You picked up a grenade launcher!");
    }
}
```
# Registering the Item:
```csharp
public void OnEnabled()
{
    CustomItemManager.Register<GrenadeLauncher>();
}
```

هذه هي جميع الملفات المتبقية التي تكمل نظام DZCP بالكامل. كل مكون الآن:

1. له كود مصدري كامل
2. متكامل مع بقية النظام
3. جاهز للبناء والتشغيل
4. مدعوم بوثائق وأمثلة

لبدء استخدام النظام:

1. انشئ قاعدة بيانات إذا كنت تستخدم MySQL
2. عدل ملفات التكوين في مجلد `configs`
3. شغل `build.ps1` لبناء الحل
4. انقل الملفات الناتجة إلى سيرفر SCP:SL
5. ابدأ بتطوير بلغناتك باستخدام `DZCP.Example` كنموذج

هل تحتاج إلى أي إيضاحات إضافية أو تعديلات على أي من هذه الملفات؟