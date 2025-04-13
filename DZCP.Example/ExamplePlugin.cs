using System;
using DZCP.Example;
using DZCP.API;
using DZCP.API.Models;
using DZCP.Events;
using DZCP.Commands;
using DZCP.Config;
using DZCP.Logging;

namespace DZCP.Example
{
    public class ExamplePlugin : IPlugin
    {
        public string Name => "Example Plugin";
        public string Author => "DZCP Team";
        public Version Version => new(1, 0, 0);
        public void Initialize()
        {
            EventManager.OnPlayerJoin += OnPlayerJoin ;

        }

        public void Shutdown()
        {
            EventManager.OnPlayerJoin -= OnPlayerJoin;
        }

        public void OnEnable()
        {
            EventManager.OnPlayerJoin -= OnPlayerJoin;
        }

        public void OnDisable()
        {
            EventManager.OnPlayerJoin -= OnPlayerJoin;
        }

        private ExampleConfig _config;

        public void OnEnabled()
        {
            _config = ConfigManager.Load<ExampleConfig>("configs/example_config.yml");

            EventManager.OnPlayerJoin += OnPlayerJoin;
            CommandManager.RegisterCommands(this);

            Logger.Info($"{Name} loaded! Debug mode: {_config.DebugMode}");
        }

        public void OnDisabled()
        {
            EventManager.OnPlayerJoin -= OnPlayerJoin;

            Logger.Info($"{Name} unloaded!");
        }

        private void OnPlayerJoin(PlayerJoinEventArgs args)
        {
            args.Player.SendMessage(_config.WelcomeMessage);
        }

        [Command("example", "Example command", "example.use")]
        public void ExampleCommand(Player player, string[] args)
        {
            player.SendMessage("This is an example command!");
        }
    }
}
