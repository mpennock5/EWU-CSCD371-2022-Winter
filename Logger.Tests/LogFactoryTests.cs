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
            logFactory.ConfigureFileLogger(Directory.GetCurrentDirectory());
            var baseLogger = logFactory.CreateLogger("fileLogger");
            // Assert
            Assert.AreEqual<string>(baseLogger.Name, "fileLogger");
        }

        [TestMethod]
        public void LogFactory_ConfigureFileLoggerUsesPrivateMember_True()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            logFactory.ConfigureFileLogger(Directory.GetCurrentDirectory());
            var logger = logFactory.CreateLogger("fileLogger");
            
            // Assert
            Assert.AreEqual<string>(logger.FilePath!, Directory.GetCurrentDirectory());

        }

        [TestMethod]
        public void LogFactory_IfFileLoggerNotConfiguredReturnNull_True()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            var logger = logFactory.CreateLogger("fileLogger");

            // Assert
            Assert.IsNull(logger);

        }
        [TestMethod]
        public void LogFactory_IfFileLoggerPathNotValidReturnNull_True()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            logFactory.ConfigureFileLogger("This Is Not A Path In My System");
            var logger = logFactory.CreateLogger("fileLogger");

            // Assert
            Assert.IsNull(logger);

        }
    }
}
