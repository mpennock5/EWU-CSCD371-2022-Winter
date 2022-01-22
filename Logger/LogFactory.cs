using System.IO;

namespace Logger;

public class LogFactory
{
    public BaseLogger CreateLogger(string className)
    {
        FileLogger fileLogger = new(className, Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt"));
        
        return fileLogger;
    }
}
