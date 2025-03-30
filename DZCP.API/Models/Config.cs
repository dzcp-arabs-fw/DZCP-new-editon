using YamlDotNet.Serialization;

namespace DZCP.API.Models
{
    public class Config
    {
        [YamlMember(Alias = "plugin_directory")]
        public string PluginDirectory { get; set; } = "plugins";

        [YamlMember(Alias = "debug_mode")]
        public bool DebugMode { get; set; } = false;

        [YamlMember(Alias = "database_type")]
        public string DatabaseType { get; set; } = "SQLite";

        [YamlMember(Alias = "auto_update")]
        public bool AutoUpdate { get; set; } = true;
    }
}