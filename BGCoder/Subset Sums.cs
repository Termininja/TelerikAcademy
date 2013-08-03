using System;
using System.Collections.Generic;
 
class SubsetSums
{
    static void Main()
    {
        long count = 0;
        long S = long.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        long[] MyList = new long[N];
        for (int n = 0; n < N; n++)
        {
            MyList[n] = long.Parse(Console.ReadLine());
        }
        for (int i = 1; i < Math.Pow(2, N); i++)
        {
            long Sum = 0;
            for (int j = 0; j < N; j++)
            {
                if ((i & (1 << j)) >> j == 1)
                {
                    Sum += MyList[j];
                }
            }
            if (Sum == S) 
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}