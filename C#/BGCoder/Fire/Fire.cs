using System;

class Fire
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N / 2; i++)
        {
            Console.WriteLine(new string('.', N / 2 - i - 1) + "#" + new string('.', 2 * i) + "#" + new string('.', N / 2 - i - 1));
        }
        for (int i = 0; i < (N / 2 + 1) / 2; i++)
        {
            Console.WriteLine(new string('.', i) + "#" + new string('.', N - 2 * i - 2) + "#" + new string('.', i));
        }
        Console.WriteLine(new string('-', N));
        for (int i = 0; i < N / 2; i++)
        {
            Console.WriteLine(new string('.', i) + new string('\\', N / 2 - i) + new string('/', N / 2 - i) + new string('.', i));
        }
    }
}