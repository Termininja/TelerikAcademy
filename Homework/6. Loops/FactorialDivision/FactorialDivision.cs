//Task 4: Write a program that calculates N!/K! for given N and K (1 < K < N).

using System;

class FactorialDivision
{
    static void Main()
    {
        Console.WriteLine("Please, enter two positive integer numbers N and K < N:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        Console.Write("   K = ");
        ulong K = ulong.Parse(Console.ReadLine());
        if (K < N && K > 1)
        {
            double result = 1;                                      // we can use BigInteger also
            for (ulong i = N; i >= K + 1; i--)                      // production from N to K+1
            {
                result *= i;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   N!       N.(N-1)...2.1");
            Console.WriteLine(" ────── = ───────────────── = N.(N-1)...(K+1) = {0}", result);
            Console.WriteLine("   K!       K.(K-1)...2.1");
            Console.ResetColor();
        }
        else
        {
            throw new Exception();                                  // generates an exception
        }
    }
}