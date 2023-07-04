using NLog;

namespace Core;

public class LogSession
{
    public static LogSession CurrentSession { get; private set; } = new LogSession(LogManager.GetCurrentClassLogger());

    private readonly ILogger logger;

    private LogSession(ILogger logger)
    {
        this.logger = logger;
    }

    public void Info(string message)
    {
        logger.Info(message);
    }

    public void Debug(string message)
    {
        logger.Debug(message);
    }

    public void Error(string message)
    {
        logger.Error(message);
    }
}