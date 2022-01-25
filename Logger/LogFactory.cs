using System.IO;
namespace Logger;

public class LogFactory
{
    private string? _testPath;

    public BaseLogger CreateLogger(string className)
    {
        if(_testPath is null)
        {
            return null!;
        }
        // Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt")
        FileLogger fileLogger = new(className, _testPath!);
        
        return fileLogger;
    }
    
    public string ConfigureFileLogger(string testPath) => _testPath = testPath;
}
