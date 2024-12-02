using System.Diagnostics;
using Serilog;

namespace _0_Framework.Log
{
    public class LogService : ILogService
    {
        private readonly ILogger _seriLog;
        public LogService(ILogger seriLog)
        {
            _seriLog = seriLog;
        }
        public void LogError(string location, string message)
        {
            _seriLog.Error(@$"Location: {location} ||| Message: {message}");
        }

        public void LogInformation(string location, string message)
        {
            _seriLog.Information(message);
        }

        public void LogWarning(string location, string message)
        {
            _seriLog.Warning(message);
        }

        public void LogException(Exception ex, string className, string message)
        {
            var stackTrace = new StackTrace(ex, true); // `true` includes file information
            var location = stackTrace?.GetFrame(0)?.GetFileName();  // File name
            var lineNumber = stackTrace?.GetFrame(0)?.GetFileLineNumber();  // Line number

            _seriLog.Error(ex, message, className, location, lineNumber);
        }
    }
}
