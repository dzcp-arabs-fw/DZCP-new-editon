using System;
using System.IO;
using DZCP.Logging;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DZCP.Config
{
    public static class ConfigManager
    {
        public static T Load<T>(string path) where T : new()
        {
            try
            {
                if (!File.Exists(path))
                {
                    var config = new T();
                    Save(path, config);
                    return config;
                }

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .Build();

                string yaml = File.ReadAllText(path);
                return deserializer.Deserialize<T>(yaml);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load config: {ex}");
                return new T();
            }
        }

        public static void Save<T>(string path, T config)
        {
            try
            {
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .Build();

                string yaml = serializer.Serialize(config);
                File.WriteAllText(path, yaml);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to save config: {ex}");
            }
        }
    }
}
