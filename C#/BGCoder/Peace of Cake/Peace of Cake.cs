using System;
using System.Numerics;
 
class PeaceOfCake
{
    static void Main()
    {
        BigInteger A = BigInteger.Parse(Console.ReadLine());
        BigInteger B = BigInteger.Parse(Console.ReadLine());
        BigInteger C = BigInteger.Parse(Console.ReadLine());
        BigInteger D = BigInteger.Parse(Console.ReadLine());
        BigInteger nominator = A * D + C * B;
        BigInteger denominator = B * D;
        BigInteger result = nominator / denominator;
        Console.WriteLine((result < 1) ? (String.Format("{0:F22}", (decimal)nominator / (decimal)denominator)) : result.ToString());
        Console.WriteLine("{0}/{1}", A * D + C * B, B * D);
    }
}