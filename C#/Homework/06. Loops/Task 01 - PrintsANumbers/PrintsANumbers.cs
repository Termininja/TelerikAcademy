//Task 1: Write a program that prints all the numbers from 1 to N.

using System;
using System.Threading;

public class PrintsANumbers
{
    public static void Main()
    {
        while (true)
        {
            try
            {
                // Read some integer number
                Console.Write("Please, enter some positive integer number: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("N = ");
                int N = int.Parse(Console.ReadLine());
                Console.ResetColor();

                // If the number is positive
                if (N > 0)
                {
                    // Print all number in the range: [1 - N]
                    Console.Write("\nAll numbers from 1 to {0} are: ", N);
                    for (int n = 1; n <= N; n++)
                    {
                        Thread.Sleep(50);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(n);
                        Console.ResetColor();
                        if (n < N) Console.Write(", ");
                    }
                    Console.WriteLine();
                    break;
                }
                else
                {
                    // If the value is negative number
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is not positive!");
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                // If the value is not integer number
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is not integer number!");
                Console.ResetColor();
            }
        }
    }
}