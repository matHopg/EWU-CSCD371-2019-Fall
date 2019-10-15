namespace Logger
{
    public abstract class BaseLogger
    {
        //Auto property of className which is set in logFactory
        public string className { get; set; }
        public abstract void Log(LogLevel logLevel, string message);
        
    }
}
