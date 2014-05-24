// Task 10: Write a program to calculate n! for each n in the range [1..100].
//          Hint: Implement first a method that multiplies a number
//          represented as array of digits by given integer number.

using System;
using System.Numerics;
using System.Threading;

class Factorial
{
    static void Main()
    {
        // Calculate n! for each number from 1 to 100
        for (int i = 1; i <= 100; i++)
        {
            Thread.Sleep(50);
            Console.WriteLine(F(i));
        }
    }

    // Calculates a factorial of some number
    static BigInteger F(int number)
    {
        BigInteger product = 1;
        for (int i = number; i > 0; i--)
        {
            product *= i;
        }
        return product;
    }
}