using System;
using System.Collections.Generic;

class KaspichanNumbers
{
    static void Main()
    {
        ulong N = ulong.Parse(Console.ReadLine());
        List<ulong> Result = new List<ulong>();
        if (N == 0) Console.Write("A");
        while (N > 0)
        {
            Result.Insert(0, N % 256);
            N /= 256;
        }
        foreach (var item in Result)
        {
            char left = ' ';
            if (item > 25)
            {
                left = (char)(item / 26 + 96);            
            }
            Console.Write((left.ToString() + ((char)(item % 26 + 65)).ToString()).Trim());
        }
    }
}