using System;
using System.Collections.Generic;

class OddNumber
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        List<long> Numbers = new List<long>();
        long sum = 0;

        for (int i = 0; i < N; i++) Numbers.Add(long.Parse(Console.ReadLine()));
        foreach (var num in Numbers) sum ^= num;

        Console.WriteLine(sum);
    }
}