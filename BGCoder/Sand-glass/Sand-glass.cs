using System;
 
class SandGlass
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N / 2; i++)
        {
            Console.WriteLine(new string('.', i) + new string('*', N - 2 * i) + new string('.', i));
        }
        for (int j = N / 2; j >= 0; j--)
        {
            Console.WriteLine(new string('.', j) + new string('*', N - 2 * j) + new string('.', j));
        }
    }
}