using System;
using DZCP.API.Interfaces;
using DZCP.Logging;

namespace DZCP.API.Services
{
    public class LoggerServiceDzcp : ILogger
    {
        private readonly string _pluginName;

        public LoggerServiceDzcp(string pluginName)
        {
            _pluginName = pluginName;
        }

        public void LogDebug(string message)
        {
            Logger.Debug($"[{_pluginName}] {message}");
        }

        public void LogInfo(string message)
        {
            Logger.Info($"[{_pluginName}] {message}");
        }

        public void LogWarning(string message)
        {
            Logger.Warn($"[{_pluginName}] {message}");
        }

        public void LogError(string message)
        {
            Logger.Error($"[{_pluginName}] {message}");
        }

        public void LogException(Exception ex, string message = null)
        {
            Logger.Error(ex, $"[{_pluginName}] {message}");
        }
    }
}