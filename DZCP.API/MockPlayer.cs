using System;

namespace DZCP.API
{
    public class MockPlayer : IPlayer
    {
        public IPlayer Nickname { get; }

        public MockPlayer(IPlayer name)
        {
            Nickname = name;
        }

        public MockPlayer(string scpMido)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"[DM to {Nickname}] {message}");
        }
    }
}