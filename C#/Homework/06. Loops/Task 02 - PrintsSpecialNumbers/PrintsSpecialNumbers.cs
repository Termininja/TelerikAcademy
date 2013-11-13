//Task 2: Write a program that prints all the numbers from 1 to N,
//        that are not divisible by 3 and 7 at the same time.

using System;
using System.Threading;

class PrintsSpecialNumbers
{
    static void Main()
    {
        // Read some integer number
        Console.Write("Please, enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // If the number is positive
        if (N > 0)
        {
            // All number in the range [1 - N]
            Console.Write("\nThe numbers not divisible by 3 and 7 at the same time are: ");
            for (int n = 1; n <= N; n++)
            {
                Thread.Sleep(50);

                // Only the numbers not devisible by 3 and 7
                if (!(n % 3 == 0 && n % 7 == 0))
                {
                    // Print the numbers
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(n);
                    Console.ResetColor();
                    if (n < N) Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}