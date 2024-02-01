namespace BronzeEngine.Utils;

public static class BLogger
{
    public enum LogLevel
    {
        Info,
        Warning,
#if DEBUG
        Debug
#endif
    }

    public static void Log(string message, LogLevel level = LogLevel.Info)
    {
        switch (level)
        {
            case LogLevel.Info:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"INFO: {message}");
                Console.ResetColor();
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNING: {message}");
                Console.ResetColor();
                break;
#if DEBUG
            case LogLevel.Debug:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"DEBUG: {message}");
                Console.ResetColor();
                break;
#endif
        }
    }

    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        throw new Exception($"ERROR: {message}");
    }
}