using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, "");

            // Assert
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }
        [TestMethod]
        public void Debug_Data_LogMessage()
        {
            var testLogger = new TestLogger();

            testLogger.Debug("Message{0}", 42);

            Assert.AreEqual(1, testLogger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, testLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message42", testLogger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_NullLogger_ThrowsException()
        {
            BaseLoggerMixins.Debug(null, "");
        }

        [TestMethod]
        public void Information_Data_LogsMessage()
        {
            var testLogger = new TestLogger();

            testLogger.Information("Message {0}", 42);

            Assert.AreEqual(1, testLogger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, testLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", testLogger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_NullLogger_ThrowsException()
        {
            BaseLoggerMixins.Information(null, "");
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            var testLogger = new TestLogger();

            testLogger.Warning("Message {0}", 42);

            Assert.AreEqual(1, testLogger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, testLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", testLogger.LoggedMessages[0].Message);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_NullLogger_ThrowsException()
        {
            BaseLoggerMixins.Warning(null, "");
        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
