using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_TakesFilePath_True()
    {
        // Arrange
        string filePath = "this will be a file path";
        // Act
        FileLogger logger = new FileLogger
        {
            FilePath = filePath
        };
        // Assert
        Assert.AreEqual<string>(logger.FilePath, filePath);
    }
}
