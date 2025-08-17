using NLog;

public static class Logger
{
    private static readonly ILogger logger;
    static Logger()
    {
        var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
        string logFilePath = Path.Combine(logDirectory, "automation.log");
        if (!File.Exists(logFilePath))
        {
            using (var stream = File.Create(logFilePath))
            {

            }
        }
        logger = LogManager.GetCurrentClassLogger();
    }
    public static void Info(string message)
    {
        logger.Info(message);
    }
    public static void Error(string message)
    {
        logger.Info(message);
    }
    public static void Warn(string message)
    {
        logger.Info(message);
    }

}