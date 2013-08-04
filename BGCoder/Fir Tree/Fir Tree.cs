using System;
  
class FirTree
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N - 1; i++)
        {
            Console.WriteLine(new string('.', N - 2 - i) + new string('*', 2 * i + 1) + new string('.', N - 2 - i));
        }
        Console.WriteLine(new string('.', N - 2) + "*" + new string('.', N - 2));
    }
}