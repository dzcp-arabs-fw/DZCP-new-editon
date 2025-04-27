using System;
using System.IO;
using DZCP_new_editon;

namespace DZCP_loader
{
    public static class LoggerLoader
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log.txt");

        /// <summary>
        /// Initializes the log file directory.
        /// </summary>
        static LoggerLoader()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
        }

        /// <summary>
        /// Logs a message with the specified prefix.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(logMessage);
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        public static void LogError(string message)
        {
            Log("ERROR: " + message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        public static void LogWarning(string message)
        {
            Log("WARNING: " + message);
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        /// <param name="info"></param>
        public static void LogInfo(string message, LogLevel info)
        {
            Log("INFO: " + message);
        }
    }
}