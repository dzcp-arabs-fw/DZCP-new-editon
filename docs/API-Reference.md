# DZCP API Reference

## Core Namespaces

### `DZCP.API`
- `IPlugin`: Base interface for all plugins
- `Player`: Represents a connected player
- `Item`: Base class for in-game items

### `DZCP.Events`
```csharp
// Subscribe to player join event
EventManager.OnPlayerJoin += args => {
    args.Player.SendMessage("Welcome!");
};
```

### `DZCP.Commands`
```csharp
[Command("hello", "Says hello")]
public void HelloCommand(Player player, string[] args)
{
    player.SendMessage("Hello!");
}
```

## Extension Methods
- `Player.IsAdmin()`
- `Player.SendWarning(string)`