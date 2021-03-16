using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Weather_App.Services
{
    class Logger : ILogger
    {
        private const string LoggerFileName = "logger.txt";
        public void LogError(string message, Exception exception)
        {
            string logger = $"[{DateTime.Now.ToLongDateString()}]: {message}\nException:\n{exception.Message}\n";
            File.AppendAllText(LoggerFileName, logger);
        }

        public void LogInfo(string message)
        {
            string logger = $"[{DateTime.Now.ToLongDateString()}]: {message}\n";
            File.AppendAllText(LoggerFileName, logger);
        }
    }
}
