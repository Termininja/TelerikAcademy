//Task 1: Write a program that prints all the numbers from 1 to N.

using System;
using System.Threading;

class PrintsANumbers
{
    static void Main()
    {
        Console.Write("Please, enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());                      // reads the limit number
        Console.ResetColor();
        if (N > 0)                                                  // if the number is positive
        {
            Console.Write("\nAll numbers from 1 to N are: ");
            for (int n = 1; n <= N; n++)                            // all numbers from 1 to N
            {
                Thread.Sleep(50);                                   // the program will sleep for 50ms
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(n);                                   // prints the number
                Console.ResetColor();
                if (n < N)                                          // without comma after the last number 
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
        else                                                        // if the number is not positive
        {
            throw new Exception();                                  // generates a new exception
        }
    }
}