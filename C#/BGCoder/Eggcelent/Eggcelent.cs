using System;

class Eggcelent
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('.', N + 1) + new string('*', N - 1) + new string('.', N + 1));
        int m = 0;
        for (int i = N - 1; i >= 3; i -= 2, m++)
        {
            Console.WriteLine(new string('.', i) + "*" + new string('.', 3 * N - 2 * i - 1) + "*" + new string('.', i));
        }
        for (int i = 0; i < N - 2 - m; i++) Console.Write(".*" + new string('.', 3 * N - 3) + "*.\n");
        Cracks(N, 0, 3);
        Cracks(N, 1, 2);
        for (int i = 0; i < N - 2 - m; i++) Console.Write(".*" + new string('.', 3 * N - 3) + "*.\n");
        for (int i = 3; i <= N - 1; i += 2)
        {
            Console.WriteLine(new string('.', i) + "*" + new string('.', 3 * N - 2 * i - 1) + "*" + new string('.', i));
        }
        Console.WriteLine(new string('.', N + 1) + new string('*', N - 1) + new string('.', N + 1));
    }

    private static void Cracks(int N, int start, int end)
    {
        Console.Write(".*");
        for (int i = start; i < 3 * N - end; i++) Console.Write((i % 2 == 0) ? "@" : ".");
        Console.WriteLine("*.");
    }
}