using System;

namespace Logger;

public class FileLogger : BaseLogger
{
   

    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }
    

    public override string Name
    {
        get => _Name!;

        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _Name = value;
        }

    }

    public string? FilePath { get; set; }
}