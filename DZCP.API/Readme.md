### FOR NEW ADDS :

# DZCP New Edition Framework - Complete Documentation

## Introduction
DZCP New Edition is a comprehensive framework for developing and managing SCP:SL servers, providing:

- Advanced plugin loading system
- Comprehensive event system
- Standardized data types
- Powerful development tools

## Project Structure

# 1. Event System
### DZCP.NewEdition/Events/
### ├── PlayerEvents.cs // Player-related events
### ├── RoundEvents.cs // Round-related events
### ├── ScpEvents.cs // SCP-related events
### ├── ItemEvents.cs // Item-related events
### ├── ServerEvents.cs // Server-related events
### └── MapEvents.cs // Map-related events

# 2. Data Types
### DZCP.NewEdition/Types/
### ├── AmmoType.cs // Ammunition types
### ├── DamageType.cs // Damage types
### ├── DoorType.cs // Door types
### ├── Effect.cs // Status effects
### ├── EscapeType.cs // Escape methods
### ├── GeneratorInteract.cs // Generator interactions
### ├── GrenadeType.cs // Grenade types
### ├── ItemInteractState.cs // Item interaction states
### ├── Layer.cs // Game layers
### ├── NukeState.cs // Warhead states
### ├── PlayerType.cs // Player types
### ├── RaCategory.cs // RA message categories
### ├── ScpAttackType.cs // SCP attack types
### ├── Scp079ContainmentStatus.cs // SCP-079 containment status
### ├── Scp079PingType.cs // SCP-079 ping types
### ├── StatType.cs // Statistic types
### ├── VersionType.cs // Version types
### └── WorkStationState.cs // Workstation states


# Core Features

### Event System

#### PlayerEvents.cs
- `OnPlayerJoined`: When a player joins
- `OnPlayerLeft`: When a player leaves
- `OnPlayerDeath`: When a player dies

#### RoundEvents.cs
- `OnRoundStart`: When round starts
- `OnRoundEnd`: When round ends

#### ScpEvents.cs
- `OnScp079LevelUp`: When SCP-079 levels up
- `OnScp096Enrage`: When SCP-096 becomes enraged

### Core Data Types

#### AmmoType.cs
- `Nato556`: 5.56mm ammunition
- `Nato762`: 7.62mm ammunition
- `Ammo12Gauge`: Shotgun shells

#### DamageType.cs
- `Firearm`: Firearm damage
- `Scp`: SCP damage
- `PocketDimension`: Pocket dimension damage

#### DoorType.cs
- `Checkpoint`: Checkpoint doors
- `Gate`: Large gates
- `Elevator`: Elevators

## Usage Guide

### Registering Events
```csharp
[PluginEvent(ServerEventType.PlayerJoined)]
public void OnPlayerJoined(Player player)
{
    // Code to execute when player joins
}
```
# Using Data Types
```csharp
public void HandleDamage(DamageType type)
{
    if (type == DamageType.Scp)
    {
        // Handle SCP damage
    }
}
```
# Plugins Examples:
### Example 1: Alarm System
```csharp
[PluginEvent(ServerEventType.GeneratorActivated)]
public void OnGeneratorActivated(Generator generator)
{
    Cassie.Message("Warning. Generator activated. .g1");
}
```
### Example 2: Stat Tracking
```csharp
[PluginEvent(ServerEventType.PlayerDeath)]
public void OnPlayerDeath(Player victim, Player killer, DamageType type)
{
    if (killer != null)
    {
        killer.IncrementStat(StatType.Kills);
    }
    victim.IncrementStat(StatType.Deaths);
}
```
# System Requirements
SCP:SL Server version 14.0.+

.NET Framework 4.8

PluginAPI last version

### Customization
You can modify any of these files according to your server's needs while maintaining the core DZCP structure.
