namespace _0_Framework.Log
{
    public interface ILogService
    {
        void LogInformation(string location, string message);
        void LogError(string location, string message);
        void LogWarning(string location, string message);
        void LogException(Exception ex, string className, string message);
    }
}
