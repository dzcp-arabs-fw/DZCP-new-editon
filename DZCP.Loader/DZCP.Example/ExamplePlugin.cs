using System;
using System.Collections.Generic;
using DZCP.Events;
using DZCP.NewEdition;
using PluginAPI.Core;

namespace MyPlugin
{
    public class MyPlugin : IDZCPPlugin
    {
        public string Name { get; }= "MyPlugin";
        public string Prefix { get; }
        public string Author { get; }= "DZCP";
        public Version Version { get; }= typeof(MyPlugin).Assembly.GetName().Version;
        public int Priority { get; }
        public IDZCPTranslation InternalTranslation { get; }
        public Version dzcpversion { get; } = typeof(MyPlugin).Assembly.GetName().Version;

        public void OnEnabled()
        {
            EventManager.OnPlayerJoin += OnPlayerJoin;
        }

        public void OnDisabled()
        {
            EventManager.OnPlayerJoin -= OnPlayerJoin;
        }

        public IDZCPTranslation LoadTranslation(Dictionary<string, object> rawTranslations = null)
        {
            throw new NotImplementedException();
        }

        private void OnPlayerJoin(PlayerJoinEventArgs e)
        {
            Log.Info($"🚀 اللاعب {e.Player} دخل السيرفر");
            
        }
    }
}