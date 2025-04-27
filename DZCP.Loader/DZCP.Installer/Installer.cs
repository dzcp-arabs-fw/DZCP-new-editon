using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DZCP.Logging;

namespace DZCP.Installer
{
    public static class Installer
    {
        public static async Task InstallDependencies()
        {
            string depPath = Path.Combine("DZCP", "dependencies");
            Directory.CreateDirectory(depPath);

            var dependencies = new[]
            {
                ("YamlDotNet", "https://example.com/packages/YamlDotNet.dll"),
                ("Newtonsoft.Json", "https://example.com/packages/Newtonsoft.Json.dll")
            };

            
            foreach (var (name, url) in dependencies)
            {
                string filePath = Path.Combine(depPath, $"{name}.dll");
                if (!File.Exists(filePath))
                {
                    try
                    {
                        var response =  typeof(HttpClient);
                        await using var fs = new FileStream(filePath, FileMode.CreateNew);
                        Logger.Info($"Installed dependency: {name}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to install {name}: {ex.Message}");
                    }
                }
            }
        }

        public static void CreateDirectoryStructure()
        {
            var directories = new[]
            {
                "configs",
                "plugins",
                "resources/translations",
                "resources/schemas",
                "logs"
            };

            foreach (var dir in directories)
            {
                Directory.CreateDirectory(Path.Combine("DZCP", dir));
            }
        }
    }
}