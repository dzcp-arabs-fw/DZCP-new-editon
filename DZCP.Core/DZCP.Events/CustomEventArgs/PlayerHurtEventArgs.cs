using System;

public class PlayerHurtEventArgs : EventArgs
{
    public string PlayerName { get; }
    public int Damage { get; }
    public string Source { get; }

    public PlayerHurtEventArgs(string playerName, int damage, string source)
    {
        PlayerName = playerName;
        Damage = damage;
        Source = source;
    }
}