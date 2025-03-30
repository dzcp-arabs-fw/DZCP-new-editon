# بدء استخدام DZCP

## المتطلبات الأساسية
- .NET 4.8 SDK
- SCP: Secret Laboratory Server

## خطوات التثبيت
1. انسخ مجلد `DZCP` إلى `PluginAPI/`
2. عدل ملف التكوين الأساسي:
```yaml
# configs/main-config.yml
debug_mode: false
plugin_directory: "plugins"
```

## إنشاء أول بلغن
```csharp
using DZCP.API;

public class MyFirstPlugin : IPlugin
CosmeticManager
    public string Name => "My Plugin";
    public void OnEnabled() => Logger.Info("Plugin loaded!");
}
```
