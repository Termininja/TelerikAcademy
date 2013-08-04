using System;
using System.Numerics;
 
class QuadronacciRectangle
{
    static void Main()
    {
        BigInteger x1 = long.Parse(Console.ReadLine());
        BigInteger x2 = long.Parse(Console.ReadLine());
        BigInteger x3 = long.Parse(Console.ReadLine());
        BigInteger x4 = long.Parse(Console.ReadLine());
        byte R = byte.Parse(Console.ReadLine());
        byte C = byte.Parse(Console.ReadLine());
 
        BigInteger result = 0;
 
        for (byte r = 1; r <= R; r++)
        {
            for (byte c = 1; c <= C; c++)
            {
                if (r == 1 && c <= 4)
                {
                    Console.Write("{0} {1} {2} {3}", x1, x2, x3, x4);
                    c = 4;
                    continue;
                }
                result = x1 + x2 + x3 + x4;
 
                if (c != 1)
                {
                    Console.Write(" ");
                }
                Console.Write(result);
                x1 = x2;
                x2 = x3;
                x3 = x4;
                x4 = result;
            }
            Console.WriteLine();
        }
    }
}