using CleanArchitecture.Application.Interfaces;
using NLog;

namespace CleanArchitecture.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();

    public void LogDebug(string message) => logger.Debug(message);
    public void LogError(string message) => logger.Error(message);
    public void LogInfo(string message) => logger.Info(message);
    public void LogWarning(string message) => logger.Warn(message);
}