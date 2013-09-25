//Taks 1: Write a program that fills and prints a matrix of size (n, n) as shown below:
//        a)               b)               c)               d)       
//            1  5  9 13       1  8  9 16       7 11 14 16       1 12 11 10
//            2  6 10 14       2  7 10 15       4  8 12 15       2 13 16  9
//            3  7 11 15       3  6 11 14       2  5  9 13       3 14 15  8
//            4  8 12 16       4  5 12 13       1  3  6 10       4  5  6  7

using System;

class Matrix
{
    static void Main()
    {
        Console.Write("Please, enter the number: n = ");
        int N = int.Parse(Console.ReadLine());
        int[,] M = new int[N, N];

        Console.WriteLine();
        PrintMatrix(VariantA(N, M));
        Console.WriteLine();
        PrintMatrix(VariantB(N, M));
        Console.WriteLine();
        PrintMatrix(VariantC(N, M));
        Console.WriteLine();
        PrintMatrix(VariantD(N, M));
    }

    static int[,] VariantA(int N, int[,] M)
    {
        int col = -1;
        for (int n = 0; n < N * N; n++)
        {
            if (n % N == 0)
            {
                col++;
            }
            M[n % N, col] = n + 1;
        }
        return M;
    }

    static int[,] VariantB(int N, int[,] M)
    {
        int col = -1;
        int row = 0;
        for (int n = 0; n < N * N; n++)
        {
            if (n % N == 0)
            {
                col++;
            }
            if (n % N != 0)
            {
                row = col % 2 == 0 ? (row + 1) % N : (row - 1) % N;
            }

            M[row, col] = n + 1;
        }
        return M;
    }

    static int[,] VariantC(int N, int[,] M)
    {
        int col = 0;
        int row = N - 1;
        int specialPos = N - 1;
        for (int n = 1; n <= N * N; n++)
        {
            M[row, col] = n;
            if (row == N - 1 || col == N - 1)
            {
                specialPos--;
                col = specialPos >= 0 ? 0 : -specialPos;
                row = specialPos >= 0 ? specialPos : 0;
            }
            else
            {
                col++;
                row++;
            }
        }
        return M;
    }

    static int[,] VariantD(int N, int[,] M)
    {
        int col = 0;
        int row = 0;
        int rowMin = 0;
        int rowMax = N - 1;
        int colMin = 1;
        int colMax = N - 1;
        char dir = 'd';

        for (int n = 1; n <= N * N; n++)
        {
            M[row, col] = n;

            switch (dir)
            {
                case 'd': row++;
                    if (row > rowMax)
                    {
                        row--; col++; rowMax--; dir = 'r';
                    }
                    break;
                case 'r': col++;
                    if (col > colMax)
                    {
                        col--; row--; colMax--; dir = 'u';
                    }
                    break;
                case 'u': row--;
                    if (row < rowMin)
                    {
                        col--; row++; rowMin++; dir = 'l';
                    }
                    break;
                case 'l': col--;
                    if (col < colMin)
                    {
                        col++; row++; colMin++; dir = 'd';
                    }
                    break;
                default: break;
            }
        }
        return M;
    }

    static void PrintMatrix(int[,] M)
    {
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                Console.Write(M[i, j].ToString().PadLeft(2, ' ') + " ");
            }
            Console.WriteLine();
        }
    }
}