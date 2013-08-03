//Task 5: Write a program that calculates N!*K! / (K-N)! for given N and K (1 < N < K).

using System;

class FactorialDivision2
{
    static void Main()
    {
        Console.WriteLine("Please, enter two positive integer numbers N and K > N:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        Console.Write("   K = ");
        ulong K = ulong.Parse(Console.ReadLine());
        if (N < K && N > 1)
        {
            double result = 1;                                      // we can use BigInteger also
            for (ulong k = K; k >= K - N + 1; k--)                  // production of K to K-N+1
            {
                result *= k;
            }
            for (ulong n = N; n >= 1; n--)                          // production from N!
            {
                result *= n;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   K!N!");
            Console.WriteLine(" ──────── = N!.K.(K-1)...(K-N+1) = {0}", result);
            Console.WriteLine("  (K-N)!");
            Console.ResetColor();
        }
        else
        {
            throw new Exception();                                  // generates an exception
        }
    }
}