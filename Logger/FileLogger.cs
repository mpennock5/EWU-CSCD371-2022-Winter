using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    
    public FileLogger(string Name, string FilePath)
    {
        _Name = Name;
        _FilePath = FilePath;
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
                throw new ArgumentNullException(nameof(value));
            }
            _Name = value;
        }

    }

    public string? FilePath
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

    // Handled by File.AppendAllText
    // Candidate for deletion
    public void CreateFileIfNoneExists()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }
    }

    public bool CheckForFile()
    {
        return File.Exists(FilePath);
    }
}

