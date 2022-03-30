namespace E_Commerce.Shared.Services.Interfaces
{
    public interface ILoggingTool
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogCritical(string message);
    }
}
