//Task10: Write a program to calculate n! for each n in the range [1..100].
//        Hint: Implement first a method that multiplies a number
//        represented as array of digits by given integer number.

using System;
using System.Numerics;

class Factorial
{
    static BigInteger F(int num)
    {
        BigInteger product = 1;
        for (int i = num; i > 0; i--)
        {
            product *= i;
        }
        return product;
    }
    static void Main()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(F(i));
        }
    }
}