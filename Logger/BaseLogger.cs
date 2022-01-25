using System;

namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);
    public abstract string Name { get; set; }
    public virtual string? FilePath { get; set; }

}
