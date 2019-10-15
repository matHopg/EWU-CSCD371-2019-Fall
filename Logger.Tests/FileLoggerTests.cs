using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_Output()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                string[] emptySpace = new string[] { "" };
                File.AppendAllLines(filePath, emptySpace);
                FileLogger fileLogger = new FileLogger(filePath) { className = this.GetType().Name };
                fileLogger.Error("{0} {1}", "Hello", "World");
                string[] text = File.ReadAllLines(filePath);
                string output = text[text.Length - 1];
                Assert.AreEqual(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + " " + fileLogger.className + " Error: Hello World", output);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
