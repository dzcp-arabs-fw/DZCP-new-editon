using System;

namespace DZCP.API.Interfaces
{
    public interface ILogger
    {
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogException(Exception ex, string message = null);
    }
}