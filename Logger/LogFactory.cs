namespace Logger;

public class LogFactory
{
    public BaseLogger CreateLogger(string className)
    {
        FileLogger fileLogger = new FileLogger
        {
            
            Name = className
        };
        return fileLogger;
    }
}
