namespace Company.DataGenerator.Logger
{
    public interface IConsoleLogger
    {
        void LogMessage(string message);

        void Dot();
    }
}
