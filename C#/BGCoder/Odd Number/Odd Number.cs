using System;
using System.Collections.Generic;

class OddNumber
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        List<long> Numbers = new List<long>();
        long sum = 0;

        for (int i = 0; i < N; i++)
        {
            long number = long.Parse(Console.ReadLine());
            Numbers.Add(number);
        }
        foreach (var num in Numbers) sum = sum ^ num;
        Console.WriteLine(sum);
    }
}