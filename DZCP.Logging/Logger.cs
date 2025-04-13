using System;
using System.IO;

namespace DZCP.Logging
{
    public static class Logger
    {
        private static string _logFilePath;
        private static LogLevel _minimumLevel = LogLevel.Info;

        public static void Initialize(string logDirectory, LogLevel minimumLevel)
        {
            _minimumLevel = minimumLevel;
            
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            _logFilePath = Path.Combine(logDirectory, $"dzcp_{DateTime.Now:yyyyMMdd_HHmmss}.log");
            
            Info("Logger initialized");
        }

        public static void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public static void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public static void Warn(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public static void Error(string message, Exception exception)
        {
            Log(LogLevel.Error, message);
        }

        public static void Error(Exception ex, string message = null)
        {
            Log(LogLevel.Error, $"{message}\n{ex}");
        }

        private static void Log(LogLevel level, string message)
        {
            if (level < _minimumLevel)
                return;

            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
            
            Console.WriteLine(logMessage);
            
            try
            {
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex}");
            }
        }

        public static void Error(string message)
        {
            throw new NotImplementedException();
        }
    }

    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3
    }
}