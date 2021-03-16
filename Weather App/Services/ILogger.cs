using System;
using System.Collections.Generic;
using System.Text;

namespace Weather_App.Services
{
    interface ILogger
    {
        void LogError(string message, Exception exception);
        void LogInfo(string message);
    }
}
