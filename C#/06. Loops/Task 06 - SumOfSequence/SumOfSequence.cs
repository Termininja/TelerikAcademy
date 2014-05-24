//Task 6: Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

using System;

public class SumOfSequence
{
    public static void Main()
    {
        // Read the number N
        Console.WriteLine("Please, enter two integer numbers N and X:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());

        // If the number N is positive
        if (N > 0)
        {
            // Read the second number X
            Console.Write("   X = ");
            long X = long.Parse(Console.ReadLine());

            decimal sum = 1;
            for (uint i = 1; i <= N; i++)
            {
                // Calculates the numerator N!
                ulong factorial = 1;
                for (ulong f = i; f > 1; f--) factorial *= f;

                // Calculate the sum
                sum += factorial / (decimal)Math.Pow(X, i);
            }

            // Print the result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n          1!    2!          N!");
            Console.WriteLine(" S = 1 + ─── + ─── + ... + ─── = {0:0.00}", sum);
            Console.WriteLine("         X^1   X^2         X^N");
            Console.ResetColor();
        }
    }
}