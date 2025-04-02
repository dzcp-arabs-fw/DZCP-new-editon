using System;

namespace DZCP.API
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        
        void OnEnabled();
        void OnDisabled();
    }
}