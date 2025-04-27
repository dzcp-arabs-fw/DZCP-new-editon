using System;
using UnityEngine;

public class DZCPPlayer : IDZCPPlayer
{
    public string Name { get; private set; }
    public Vector3 Position { get; private set; }
    public bool IsAlive { get; private set; }

    public DZCPPlayer(string name, Vector3 position, bool isAlive)
    {
        Name = name;
        Position = position;
        IsAlive = isAlive;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"Message to {Name}: {message}");
    }

    public void Teleport(Vector3 newPosition)
    {
        Position = newPosition;
        Console.WriteLine($"{Name} teleported to {Position}");
    }
}