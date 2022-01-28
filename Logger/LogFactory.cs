using System.IO;
namespace Logger;

public class LogFactory
{
    private string? filePath;

    public BaseLogger CreateLogger(string className)
    {
        if (filePath is null)
        {
            return null!;
        }
        switch (className)
        {
            case "FileLogger":
                FileLogger fileLogger = new(className, filePath);
                return fileLogger;

            default:
                return null!;
        }
    }

    public string ConfigureFileLogger(string? loggerPath)
    {   
        return this.filePath = loggerPath!;
    }
}
