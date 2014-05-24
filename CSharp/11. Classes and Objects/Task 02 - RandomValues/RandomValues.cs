//Task2: Write a program that generates and prints to the console
//       10 random values in the range [100, 200].

using System;
using System.Threading;

public class RandomValues
{
    public static void Main()
    {
        // Create a random generator
        Random RandomGenerator = new Random();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("  Random value {0:00}: ", i + 1);

                // Prints the result
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(RandomGenerator.Next(100, 201));
                Console.ResetColor();
                Thread.Sleep(10);
            }
        }
    }
}