using System;

class SevenlandNumbers
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        Console.WriteLine(K + ((K % 1000 == 666) ? 334 : ((K % 100 == 66) ? 34 : ((K % 10 == 6) ? 4 : 1))));
    }
}