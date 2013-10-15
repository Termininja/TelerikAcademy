// Task 06. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
//          Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Threading;

namespace IntegerNumbers
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                // Create and print some array of integers
                Console.WriteLine("Array of random integers:");
                IntegerNumbers[] numbers = new IntegerNumbers[25];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Random generator = new Random();
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = new IntegerNumbers(generator.Next(10, 100));
                    Console.Write(numbers[i].N + " ");
                }
                Console.ResetColor();

                // Prints all numbers that are divisible by 7 and 3
                Print(IntegerNumbers.DivisibleBy21usingLambda(numbers), "Lambda");      // by using lambda expressions
                Print(IntegerNumbers.DivisibleBy21usingLINQ(numbers), "LINQ");          // by using LINQ

                Console.WriteLine("\n\n\nPress any key to stop the test...");
                Thread.Sleep(500);
                if (Console.KeyAvailable)                                               // stop the loop
                {
                    Console.ReadKey(false);
                    Console.Write("\b \b");
                    break;
                }
                Console.Clear();
            }
        }

        private static void Print(dynamic arr, string str)
        {
            Console.Write("\n\nNumbers that are divisible by 7 and 3 (using {0})\t══►    ", str);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in arr) Console.Write(item.N + " ");
            Console.ResetColor();
        }
    }
}
