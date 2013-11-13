//Task 8: Write a program that calculates the greatest common divisor (GCD)
//        of given two numbers. Use the Euclidean algorithm (find it in Internet).

using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        /* First variant */
        int x = 84;
        int y = 18;
        int res = 1;
        for (int i = 2; i <= Math.Max(x, y); i++) if (x % i == 0 && y % i == 0) if (i > res) res = i;

        /* Second variant (Euclidean algorithm) */
        Console.WriteLine("Please, enter two numbers X and Y:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   X = ");
        int X = int.Parse(Console.ReadLine());
        Console.Write("   Y = ");
        int Y = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int remainder = 1;
        int numerator = Math.Max(X, Y);                         // the numerator is max of the both numbers
        int denominator = Math.Min(X, Y);                       // the denominator is min of the both numbers
        while (remainder != 0)                                  // the loop will stop when remainder is 0
        {
            remainder = numerator % denominator;
            numerator = denominator;
            denominator = remainder;
        }
        Console.Write("\nThe greatest common divisor of {0} and {1} is: ", X, Y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(numerator);                           // the result is numerator (the last denominator)
        Console.ResetColor();
    }
}