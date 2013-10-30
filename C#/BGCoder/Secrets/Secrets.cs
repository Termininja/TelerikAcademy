using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger tempN = N;
        int len = N.ToString().Length;
        if (N < 0) len--;
        BigInteger S = 0;
        for (int i = 1; i <= len; i++)
        {
            BigInteger left;
            if (N < 0) left = -(N % 10);
            else left = N % 10;
            if (i % 2 == 0) S += left * left * i;
            else S += left * i * i;
            N /= 10;
        }
        
        BigInteger LastSum = S % 10;
        Console.WriteLine(S);
        if (LastSum == 0) Console.WriteLine("{0} has no secret alpha-sequence", tempN);
        else
        {
            int k = 0;
            int m = 1;
            BigInteger R = S % 26;
            for (int i = 0; i < LastSum; i++)
            {
                BigInteger temp = 65 + R + i;
                Console.Write((char)(temp - k));
                if (temp == 64 + 26 * m)
                {
                    k = 26;
                    m++;
                }
            }
            Console.WriteLine();
        }
    }
}