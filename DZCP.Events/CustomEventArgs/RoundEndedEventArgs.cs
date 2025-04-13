using System;

public class RoundEndedEventArgs : EventArgs
{
    public string WinningTeam { get; }

    public RoundEndedEventArgs(string winningTeam)
    {
        WinningTeam = winningTeam;
    }
}