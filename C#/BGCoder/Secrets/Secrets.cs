using System;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger tempN = N;
        if (N < 0) N = -1 * N;

        BigInteger specialSum = 0;
        int count = 0;
        while (N > 0)
        {
            count++;
            BigInteger n = N % 10;
            specialSum += (count % 2 == 0) ? n * n * count : n * count * count;
            N = N / 10;
        }
        Console.WriteLine(specialSum);

        string alphaSequence = String.Empty;
        BigInteger first = 65 + specialSum % 26;
        for (BigInteger i = first; i < first + specialSum % 10; i++)
        {
            alphaSequence += (char)((i <= 90) ? i : (i - 65) % 26 + 65);
        }

        Console.WriteLine((specialSum % 10 > 0) ? alphaSequence : tempN + " has no secret alpha-sequence");
    }
}