namespace Company.DataGenerator.Logger
{
    using System;

    public class ConsoleLogger : IConsoleLogger
    {
        private const char DotCharacter = '.';

        public void LogMessage(string message)
        {
            Console.Write(message);
        }

        public void Dot()
        {
            Console.Write(DotCharacter);
        }
    }
}
