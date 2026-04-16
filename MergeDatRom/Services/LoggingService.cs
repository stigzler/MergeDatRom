using System;
using System.Collections.Generic;
using System.Text;

namespace MergeDatRom.Services
{
    public class LoggingService
    {
        private static readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        private static readonly object LockObject = new object();

        public void LogClear()
        {
            try
            {
                lock (LockObject)
                {
                    File.WriteAllText(LogPath, string.Empty, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to clear log file: {ex.Message}");
            }
        }

        public void Log(string message)
        {
            try
            {
                lock (LockObject)
                {
                    string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}";
                    File.AppendAllText(LogPath, logLine, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log to file: {ex.Message}");
            }
        }
    }
}
