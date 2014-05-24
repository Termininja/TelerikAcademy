//Task 13*: Write a program that calculates for given N how many trailing
//          zeros present at the end of the number N!. Examples:
//	                N=10 → N!=3628800 → 2
//	                N=20 → N!=2432902008176640000 → 4
//	        Does your program work for N=50 000? Hint: The trailing zeros
//          in N! are equal to the number of its prime divisors of 5.

using System;
using System.Numerics;

public class CountsAZeros
{
    public static void Main()
    {
        // Read some integer number
        Console.Write("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\n   N = ");
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        Console.ResetColor();

        // If the number is positive
        if (N >= 0)
        {
            BigInteger zeros = 0;
            BigInteger divider = 5;

            // Calculate the trailing zeros
            while (divider <= N)
            {
                zeros += N / divider;
                divider *= 5;
            }

            // Print the result
            Console.Write("\nAt the end of N! there are ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(zeros);
            Console.ResetColor();
            Console.WriteLine(" trailing zeroes.");
        }
    }
}