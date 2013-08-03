using System;
using System.Numerics;
 
class Tribonacci
{
    static void Main()
    {
        BigInteger x1 = int.Parse(Console.ReadLine());
        BigInteger x2 = int.Parse(Console.ReadLine());
        BigInteger x3 = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
 
        BigInteger next = 0;
        switch (N)
        {
            case 1: Console.WriteLine(x1); break;
            case 2: Console.WriteLine(x2); break;
            case 3: Console.WriteLine(x3); break;
            default:
                for (int i = 4; i <= N; i++)
                {
                    next = x1 + x2 + x3;
                    x1 = x2;
                    x2 = x3;
                    x3 = next;
                }
                Console.WriteLine(x3);
                break;
        }
    }
}