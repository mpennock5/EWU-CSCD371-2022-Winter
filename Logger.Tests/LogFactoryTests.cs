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
            var baseLogger = logFactory.CreateLogger("fileLogger");
            // Assert
            Assert.AreEqual<string>(baseLogger.Name, "fileLogger");
        }
    }
}
