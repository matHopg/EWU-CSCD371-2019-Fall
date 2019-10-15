using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void Not_Configured_Return_Null()
        {
            LogFactory logFactory = new LogFactory();

            var testLogger = logFactory.CreateLogger(this.GetType().Name);

            Assert.IsNull(testLogger);
        }

        [TestMethod]
        public void Configured_Return_Correct_Logger()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                LogFactory logFactory = new LogFactory();
                logFactory.ConfigureFileLogger(filePath);

                var testLogger = logFactory.CreateLogger(this.GetType().Name);


                Assert.IsNotNull(testLogger);
                Assert.AreEqual(this.GetType().Name, testLogger.className);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
