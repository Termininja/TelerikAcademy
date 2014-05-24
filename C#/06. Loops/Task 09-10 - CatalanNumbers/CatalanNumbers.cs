//Task 9-10: In the combinatorial mathematics, the Catalan numbers are calculated
//           by the following formula: Cn=(2n)!/(n+1)!n!, for n>=0
//           Write a program to calculate the Nth Catalan number by given N.

using System;
using System.Collections.Generic;

public class CatalanNumbers
{
    public static void Main()
    {
        // Lists of numerator and denominator numbers
        List<decimal> Numerator = new List<decimal>();
        List<decimal> Denominator = new List<decimal>();

        // Read some integer number
        Console.WriteLine("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        uint N = uint.Parse(Console.ReadLine());
        Console.ResetColor();

        // Calculation of the Catalan number
        double Cn = 1;
        for (uint i = N + 2; i <= 2 * N; i++) Numerator.Add(i);
        for (uint j = 2; j <= N; j++) Denominator.Add(j);
        for (int k = 0; k < N - 1; k++)
        {
            if (N == 0) break;
            Cn *= (double)(Numerator[k] / Denominator[k]);
        }

        // Print the result
        Console.WriteLine("\nThe {0} Catalan number is:", N);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n          (2n)!    2n(2n-1)...(n+2)");
        Console.WriteLine("   Cn = ──────── = ──────────────── = {0}", Cn);
        Console.WriteLine("        (n+1)!n!          n!");
        Console.ResetColor();
    }
}