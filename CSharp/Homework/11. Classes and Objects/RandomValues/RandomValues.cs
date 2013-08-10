//Task2: Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
using System.Threading;

class RandomValues
{
    static void Main()
    {
        Random RandomGenerator = new Random();                      // sets a random generator
        for (int i = 0; i < 10; i++)                                // for each 10 values
        {
            for (int j = 0; j < 100; j++)                           // takes the last from 99 times
            {
                Console.SetCursorPosition(0, i);
                Console.Write("Random value {0:00}: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(RandomGenerator.Next(100, 201));  // prints the result
                Console.ResetColor();
                Thread.Sleep(20);                                   // sleep the program for 20ms
            }
        }
    }
}