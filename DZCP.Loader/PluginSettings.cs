using System.IO;
using Newtonsoft.Json;

public class PluginSettings
{
    public static T Load<T>(string pluginName) where T : new()
    {
        var path = Path.Combine("Plugins", pluginName, "config.json");
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
        return new T();
    }

    public static void Save<T>(string pluginName, T settings)
    {
        var path = Path.Combine("Plugins", pluginName, "config.json");
        var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}