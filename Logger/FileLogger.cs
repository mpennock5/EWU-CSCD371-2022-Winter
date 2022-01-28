using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    
    public FileLogger(string name, string filePath)
    {
        Name = name;
        FilePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        switch (logLevel)
        {
            case LogLevel.Error:
                File.AppendAllText(FilePath, (DateTime.Now + " " + Name + " Error: " + message) + Environment.NewLine);              
                break;

            case LogLevel.Warning:
                File.AppendAllText(FilePath, (DateTime.Now + " " + Name + " Warning: " + message) + Environment.NewLine);        
                break;

            case LogLevel.Information:
                File.AppendAllText(FilePath, (DateTime.Now + " " + Name + " Information: " + message) + Environment.NewLine);               
                break;

            case LogLevel.Debug:
                File.AppendAllText(FilePath, (DateTime.Now + " " + Name + " Debug: " + message) + Environment.NewLine);
                break;
        }
    }
    
    public override string Name
    {
        get => _Name!;

        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
            }
            _Name = value;
        }

    }
    private string? _Name;

    public override string? FilePath
    {
        get => _FilePath!;

        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _FilePath = value;
        }

    }
    private string? _FilePath;
  
}

