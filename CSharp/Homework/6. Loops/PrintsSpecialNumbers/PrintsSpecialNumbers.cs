//Task 2: Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;
using System.Threading;

class PrintsSpecialNumbers
{
    static void Main()
    {
        Console.Write("Please, enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());                          // reads the limit number
        Console.ResetColor();
        if (N > 0)                                                      // if the number is positive
        {
            Console.Write("\nThe numbers not divisible by 3 and 7 at the same time are: ");
            for (int n = 1; n <= N; n++)                                // all numbers from 1 to N
            {
                Thread.Sleep(50);                                       // the program will sleep for 50ms
                if (!(n % 3 == 0 && n % 7 == 0))                        // the numbers not devisible by 3 and 7
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(n);                                   // prints the number
                    Console.ResetColor();
                    if (n < N)                                          // without comma after the last number 
                    {
                        Console.Write(", ");
                    }
                }
            }
            Console.WriteLine();
        }
        else                                                            // if the number is not positive
        {
            throw new Exception();                                      // generates an exception
        }
    }
}