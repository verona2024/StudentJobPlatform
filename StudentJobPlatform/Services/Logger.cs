using System;
using System.IO;

namespace StudentJobPlatform.Services
{
    public static class Logger
    {
        private static readonly string FilePath = "logs.txt";

        public static void Log(string message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(message))
                    return;

                File.AppendAllText(
                    FilePath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}"
                );
            }
            catch
            {
            }
        }

        public static void Log(Exception ex)
        {
            try
            {
                if (ex == null)
                    return;

                File.AppendAllText(
                    FilePath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {ex.Message}{Environment.NewLine}" +
                    $"STACK TRACE: {ex.StackTrace}{Environment.NewLine}{Environment.NewLine}"
                );
            }
            catch
            {
            }
        }
    }
}
