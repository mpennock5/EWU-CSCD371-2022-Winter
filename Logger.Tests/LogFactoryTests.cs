using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
    
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_ClassNameAssigned_True()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();
            // Act
            logFactory.ConfigureFileLogger(Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt"));
            var baseLogger = logFactory.CreateLogger("FileLogger");
            // Assert
            Assert.AreEqual<string>(baseLogger.Name, "FileLogger");
        }

        [TestMethod]
        public void LogFactory_ConfigureFileLoggerUsesPrivateMember_True()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            logFactory.ConfigureFileLogger(Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt"));
            var logger = logFactory.CreateLogger("FileLogger");
            
            // Assert
            Assert.AreEqual<string>(logger.FilePath!, Path.Combine(Directory.GetCurrentDirectory(), "Logs.txt"));

        }

        [TestMethod]
        public void LogFactory_IfFileLoggerNotConfiguredReturnNull_True()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            var logger = logFactory.CreateLogger("FileLogger");

            // Assert
            Assert.IsNull(logger);

        }
        
    }
}
