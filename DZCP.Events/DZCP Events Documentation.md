# DZCP Events Documentation

## Introduction
This document serves as a comprehensive guide to the new events and additions introduced to the DZCP framework. It covers player events, SCP events, map events, item events, server events, and miscellaneous events. Each event is designed with a consistent DZCP style, providing seamless integration and enhanced functionality.

---

## Table of Contents
1. [Player Events](#player-events)
2. [SCP Events](#scp-events)
3. [Map Events](#map-events)
4. [Item Events](#item-events)
5. [Server Events](#server-events)
6. [Miscellaneous Events](#miscellaneous-events)
7. [Integrations](#integrations)
8. [Code Examples](#code-examples)

---

## Player Events

### 1. OnPlayerEscape
- **Description**: Triggered when a player escapes the facility.
- **Code Example**:
```csharp
public static void HandlePlayerEscape(PlayerEscapeEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} escaped using {e.EscapeType}.", ConsoleColor.Magenta);
}
```
### 2. OnPlayerBan
- **Description**: Triggered when a player is banned.
- **Code Example**:
```csharp
public static void HandlePlayerBan(PlayerBanEvent e)
{
ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} was banned for: {e.Reason}.", ConsoleColor.Red);
}
```
### 3. OnPlayerKicked
- **Description**: Triggered when a player is kicked.
- **Code Example**:
```csharp
public static void HandlePlayerKicked(PlayerKickedEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} was kicked for: {e.Reason}.", ConsoleColor.Yellow);
}
```
### 4. OnPlayerSpawn
- **Description**: Triggered when a player spawns in the game.
- **Code Example**:
```csharp
public static void HandlePlayerSpawn(PlayerSpawnEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} spawned as {e.RoleName}.", ConsoleColor.Green);
}
```
### 5. OnPlayerRevive
- **Description**: Triggered when a player is revived.
- **Code Example**:
```csharp
public static void HandlePlayerRevive(PlayerReviveEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} was revived.", ConsoleColor.DarkYellow);
}
```
### 6. OnPlayerChangeRole
- **Description**: Triggered when a player changes their role.
- **Code Example**:
```csharp
public static void HandlePlayerChangeRole(PlayerChangeRoleEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} changed role from {e.OldRole} to {e.NewRole}.", ConsoleColor.Cyan);
}
```
### 7. OnPlayerEnterPocketDimension
- **Description**: Triggered when a player enters the pocket dimension.
- **Code Example**:
```csharp
public static void HandlePlayerEnterPocketDimension(PlayerEnterPocketDimensionEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} entered the Pocket Dimension.", ConsoleColor.DarkGray);
}
```
### 8. OnPlayerExitPocketDimension
- **Description**: Triggered when a player exits the pocket dimension.
- **Code Example**:
```csharp
public static void HandlePlayerExitPocketDimension(PlayerExitPocketDimensionEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} exited the Pocket Dimension.", ConsoleColor.DarkGreen);
}
```
### 9. OnPlayerIntercomSpeak
- **Description**: Triggered when a player starts speaking on the intercom.
- **Code Example**:
```csharp
public static void HandlePlayerIntercomSpeak(PlayerIntercomSpeakEvent e)
{
    ServerConsole.AddLog($"[DZCP] Player {e.PlayerName} is speaking on the intercom.", ConsoleColor.Gray);
}
```
### 1. OnScpEscape
- **Description**: Triggered when an SCP escapes the facility.
- **Code Example**:
```csharp
public static void HandleScpEscape(ScpEscapeEvent e)
{
    ServerConsole.AddLog($"[DZCP] SCP {e.ScpName} escaped!", ConsoleColor.Yellow);
}
```
### and more and more you can see all events in project files : DZCP.evnt>CustomEventArgs>see