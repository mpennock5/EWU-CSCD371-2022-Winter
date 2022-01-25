using System.IO;
namespace Logger;

public class LogFactory
{
    private string? filePath;

    public BaseLogger CreateLogger(string? className)
    {
        if(filePath is null)
        {
            return null!;
        }
        // Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt")
        FileLogger fileLogger = new(className!, filePath);
        
        return fileLogger;
    }

    public string ConfigureFileLogger(string? loggerPath)
    {
        return filePath = loggerPath!;
    }
}
