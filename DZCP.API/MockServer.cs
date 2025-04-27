using System;
using System.Collections.Generic;

namespace DZCP.API
{
    public class MockServer : IServer
    {
        public void Log(string msg) => Console.WriteLine("[LOG] " + msg);
        public IEnumerable<IPlayer> GetPlayers() => new List<IPlayer>();
    }
}