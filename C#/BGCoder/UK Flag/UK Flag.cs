using System;

class UK_Flag
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                Console.Write((row == col && row == N / 2) ?
                    "*" : ((col == N / 2) ?
                    "|" : ((row == N / 2) ?
                    "-" : ((row == col) ?
                    "\\" : ((col == N - row - 1) ?
                    "/" : ".")))));
            }
            Console.WriteLine();
        }
    }
}