//Task 9-10: In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
//           Cn=(2n)!/(n+1)!n!, for n>=0
//           Write a program to calculate the Nth Catalan number by given N.

using System;
using System.Collections.Generic;

class CatalanNumbers
{
    static void Main()
    {
        List<decimal> Numerator = new List<decimal>();      // list of numerator numbers
        List<decimal> Denominator = new List<decimal>();    // list of denominator numbers
        Console.WriteLine("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        uint N = uint.Parse(Console.ReadLine());
        Console.ResetColor();
        double Cn = 1;                                      // the Catalan number is 1 for N = 0
        for (uint i = N + 2; i <= 2 * N; i++)
        {
            Numerator.Add(i);                               // adds all numbers from N + 2 to 2N in Numerator list
        }
        for (uint j = 2; j <= N; j++)
        {
            Denominator.Add(j);                             // adds all numbers from 2 to N in Denominator list
        }
        for (int k = 0; k < N - 1; k++)                     // calculates each one multiplier
        {
            if (N == 0)                                     
            {
                break;
            }
            Cn *= (double)(Numerator[k] / Denominator[k]);  // the Catalan number
        }
        Console.WriteLine("\nThe {0} Catalan number is:", N);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n          (2n)!    2n(2n-1)...(n+2)");
        Console.WriteLine("   Cn = ──────── = ──────────────── = {0}", Cn);
        Console.WriteLine("        (n+1)!n!          n!");
        Console.ResetColor();
    }
}