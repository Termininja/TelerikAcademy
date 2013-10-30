//Task 13*: Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	        N=10 → N!=3628800 → 2
//	        N=20 → N!=2432902008176640000 → 4
//	        Does your program work for N=50 000? Hint: The trailing zeros in N! are equal to the number of its prime divisors of 5.

using System;
using System.Numerics;

class CountsAZeros
{
    static void Main()
    {
        Console.Write("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\n   N = ");
        BigInteger N = BigInteger.Parse(Console.ReadLine());            // reads the number
        Console.ResetColor();
        if (N >= 0)                                                     // if the number is positive
        {
            BigInteger zeros = 0;                                       // start from 0 zeros
            BigInteger divider = 5;                                   
            while (divider <= N)                                        // counts the zeros at the end of N!
            {
                zeros += N / divider;
                divider *= 5;
            }
            Console.Write("\nAt the end of N! there are ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(zeros);                                       // prints the result
            Console.ResetColor();
            Console.WriteLine(" trailing zeroes.");
        }
        else                                                            // if the number is not positive
        {
            throw new Exception();                                      // generates an exception
        }
    }
}