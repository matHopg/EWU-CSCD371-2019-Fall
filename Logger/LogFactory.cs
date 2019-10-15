using System;

namespace Logger
{
    public class LogFactory
    {
        private string filePath;
        public BaseLogger CreateLogger(string className)
        {
            if(filePath is null)
            {
                return null;
            }
            return new FileLogger(filePath) { className = className };
        }
        public void ConfigureFileLogger(string configPath)
        {
            filePath = configPath;
        }
    }
}
