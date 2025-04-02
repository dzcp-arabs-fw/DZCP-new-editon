// DZCP/Models/PluginUpdate.cs

using System;

namespace DZCP.Models
{
    public class PluginUpdate
    {
        public string PluginId { get; set; }
        public string PluginName { get; set; }
        public Version Version { get; set; }
        public string Url { get; set; }
    }
}
