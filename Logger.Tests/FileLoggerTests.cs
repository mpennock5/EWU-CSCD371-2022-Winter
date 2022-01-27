using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_TakesFilePath_True()
    {
        // Arrange
        string filePath = Directory.GetCurrentDirectory();

        // Act
        FileLogger fileLogger = new("logger", Directory.GetCurrentDirectory());

        // Assert
        Assert.AreEqual<string>(fileLogger.FilePath!, filePath);
    }
    
    [TestMethod]
    public void FileLogger_LogGeneratesLogBasedOnLogLevel_true()
    {
        // Arrange
        FileLogger fileLogger = new("logger", Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt"));
        LogLevel logLevel = new();
        string message = "Test Message";
        bool messageWritten = false;

        // Act
        fileLogger.Log(logLevel, message);
        
        foreach (string line in File.ReadLines(fileLogger.FilePath!))
        {
            if (line.Contains(message))
            {
                messageWritten = true;
            }
        }

        // Assert
        Assert.IsTrue(messageWritten);

    }
}