using System;

namespace AcademyEcosystem
{
    public class Program
    {
        private static Engine GetEngineInstance()
        {
            return new ExtendedEngine();
        }

        public static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
