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
                if (row == col && row == N / 2)
                {
                    Console.Write("*");
                }
                else if (col == N / 2)
                {
                    Console.Write("|");
                }
                else if (row == N / 2)
                {
                    Console.Write("-");
                }
                else if (row == col)
                {
                    Console.Write("\\");
                }
                else if (col == N - row - 1)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}