using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string filePath;

        public FileLogger(string fileLogPath)
        {
            filePath = fileLogPath;
        }
        public override void Log(LogLevel logLevel, string message)
        {
            if(!(filePath is null) && File.Exists(filePath))
            {
                string appendText = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + " " + className
                    + " " + logLevel + ": " + message + Environment.NewLine;
                File.AppendAllText(filePath, appendText);
            }
        }
    }
}
