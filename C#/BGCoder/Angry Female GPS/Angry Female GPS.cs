using System;
using System.Numerics;
 
class AngryFemaleGPS
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        int evenSum = 0;
        int oddSum = 0;
 
        if (N < 0) N *= -1;
        while (N > 0)
        {
            byte curr = (byte)(N % 10);
            if (curr % 2 == 0) evenSum += curr;
            else oddSum += curr;
            N /= 10;
        }
        if (evenSum > oddSum) Console.WriteLine("right {0}", evenSum);
        else if (evenSum < oddSum) Console.WriteLine("left {0}", oddSum);
        else Console.WriteLine("straight {0}", evenSum);
    }
}