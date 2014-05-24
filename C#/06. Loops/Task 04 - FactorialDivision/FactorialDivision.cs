//Task 4: Write a program that calculates N!/K! for given N and K (1 < K < N).

using System;

public class FactorialDivision
{
    public static void Main()
    {
        // Read the numbers N and K
        Console.WriteLine("Please, enter two positive integer numbers N and K < N:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        Console.Write("   K = ");
        ulong K = ulong.Parse(Console.ReadLine());

        // If N > K > 1
        if (K < N && K > 1)
        {
            double result = 1;

            // The product from N to K+1
            for (ulong i = N; i >= K + 1; i--) result *= i;

            // Print the result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   N!       N.(N-1)...2.1");
            Console.WriteLine(" ────── = ───────────────── = N.(N-1)...(K+1) = {0}", result);
            Console.WriteLine("   K!       K.(K-1)...2.1");
            Console.ResetColor();
        }
    }
}