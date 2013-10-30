using System;
 
class Trapezoid
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('.', N) + new string('*', N));
        for (int i = 0; i < N - 1; i++)
        {
            Console.WriteLine(new string('.', N - i - 1) + "*" + new string('.', N + i - 1) + "*");
        }
        Console.WriteLine(new string('*', 2 * N));
    }
}