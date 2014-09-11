namespace ToysStore.DataGenerator.Logger
{
    using System;

    public class ConsoleLogger : IConsoleLogger
    {
        public void LogMessage(string message)
        {
            Console.Write(message);
        }
    }
}
