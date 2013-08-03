using System;
  
class SevenlandNumbers
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        if (K % 1000 == 666)
        {
            Console.WriteLine(K + 334);
        }
        else if (K % 100 == 66)
        {
            Console.WriteLine(K + 34);
        }
        else if (K % 10 == 6)
        {
            Console.WriteLine(K + 4);
        }
        else
        {
            Console.WriteLine(K + 1);
        }
    }
}