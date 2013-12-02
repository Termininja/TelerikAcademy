//Task 5: Write a program that calculates N!*K! / (K-N)! for given N and K (1 < N < K).

using System;

public class FactorialDivision2
{
    public static void Main()
    {
        // Read the numbers N and K 
        Console.WriteLine("Please, enter two positive integer numbers N and K > N:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        Console.Write("   K = ");
        ulong K = ulong.Parse(Console.ReadLine());

        // If K > N > 1
        if (N < K && N > 1)
        {
            double result = 1;

            // The product of K to K-N+1
            for (ulong k = K; k >= K - N + 1; k--) result *= k;

            // The product from N!
            for (ulong n = N; n >= 1; n--) result *= n;

            // Print the result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   K!N!");
            Console.WriteLine(" ──────── = N!.K.(K-1)...(K-N+1) = {0}", result);
            Console.WriteLine("  (K-N)!");
            Console.ResetColor();
        }
    }
}