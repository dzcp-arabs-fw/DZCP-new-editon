using System.IO;
using Newtonsoft.Json;

public class ConfigManager<T> where T : new()
{
    private string configPath;
    public T Config { get; private set; }

    public ConfigManager(string path)
    {
        configPath = path;
        LoadConfig();
    }

    public void LoadConfig()
    {
        if (File.Exists(configPath))
        {
            var json = File.ReadAllText(configPath);
            Config = JsonConvert.DeserializeObject<T>(json);
        }
        else
        {
            Config = new T();
            SaveConfig();
        }
    }

    public void SaveConfig()
    {
        var json = JsonConvert.SerializeObject(Config, Formatting.Indented);
        File.WriteAllText(configPath, json);
    }
}