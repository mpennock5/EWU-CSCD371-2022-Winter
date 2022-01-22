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

    public void CreateFileIfNoneExists()
    {
        if (!File.Exists(FilePath))
        {
            FileStream fs = File.Create(FilePath);
        }
    }

    public bool CheckForFile()
    {
        return File.Exists(FilePath);
    }
}