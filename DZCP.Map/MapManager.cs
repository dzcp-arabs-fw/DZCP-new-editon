using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class MapManager
{
    public void LoadMapCustomizations()
    {
        string path = Path.Combine("Configs", "map_config.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<MapConfig>(json);

            foreach (var spawn in config.SpawnPoints)
            {
                CreateSpawnPoint(spawn.Position, spawn.Rotation, spawn.Role);
            }

            foreach (var item in config.CustomItems)
            {
                SpawnItem(item.Position, item.Item);
            }
        }
    }

    private void CreateSpawnPoint(float[] position, float[] rotation, string role)
    {
        // منطق إنشاء نقطة الظهور
    }

    private void SpawnItem(float[] position, string itemName)
    {
        // منطق إنشاء العنصر في الخريطة
    }
}

public class MapConfig
{
    public List<SpawnPoint> SpawnPoints { get; set; }
    public List<CustomItem> CustomItems { get; set; }
}

public class SpawnPoint
{
    public float[] Position { get; set; }
    public float[] Rotation { get; set; }
    public string Role { get; set; }
}

public class CustomItem
{
    public float[] Position { get; set; }
    public string Item { get; set; }
}