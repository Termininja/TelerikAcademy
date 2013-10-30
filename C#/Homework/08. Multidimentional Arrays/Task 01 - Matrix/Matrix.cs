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
        int N = int.Parse(Console.ReadLine());                  // reads some number N
        int[,] M = new int[N, N];                               // creates one matrix NxN       

        Console.WriteLine();
        PrintMatrix(VariantA(N, M));                            // prints the result for variant A
        Console.WriteLine();
        PrintMatrix(VariantB(N, M));                            // prints the result for variant B
        Console.WriteLine();
        PrintMatrix(VariantC(N, M));                            // prints the result for variant C
        Console.WriteLine();
        PrintMatrix(VariantD(N, M));                            // prints the result for variant D
    }

    static int[,] VariantA(int N, int[,] M)
    {
        int col = -1;
        for (int n = 0; n < N * N; n++)
        {
            if (n % N == 0)                                     // go to the next column
            {
                col++;
            }
            M[n % N, col] = n + 1;                              // the row depends on current N
        }
        return M;
    }

    static int[,] VariantB(int N, int[,] M)
    {
        int col = -1;
        int row = 0;
        for (int n = 0; n < N * N; n++)
        {
            if (n % N == 0)                                     // go to the next column 
            {
                col++;
            }
            if (n % N != 0)                                     // calculates the current row
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
        int specialPos = N - 1;                                 // the new start position
        for (int n = 1; n <= N * N; n++)
        {
            M[row, col] = n;
            if (row == N - 1 || col == N - 1)                   // the limit of matrix
            {
                specialPos--;
                col = specialPos >= 0 ? 0 : -specialPos;        // go to new column
                row = specialPos >= 0 ? specialPos : 0;         // go to new row
            }
            else
            {
                col++;                                          // calculates the current column
                row++;                                          // calculates the current row
            }
        }
        return M;
    }

    static int[,] VariantD(int N, int[,] M)
    {
        int col = 0;
        int row = 0;
        int rowMin = 0;                                         // minimum rows for spiral
        int rowMax = N - 1;                                     // the limit of rows for spiral
        int colMin = 1;                                         // minimim columns for spiral
        int colMax = N - 1;                                     // the limit of columns for spiral
        char dir = 'd';

        for (int n = 1; n <= N * N; n++)
        {
            M[row, col] = n;

            switch (dir)                                        // checks the current direction
            {
                case 'd': row++;                                // if direction is "down"
                    if (row > rowMax)
                    {
                        row--; col++; rowMax--; dir = 'r';
                    }
                    break;
                case 'r': col++;                                // if direction is "right"
                    if (col > colMax)
                    {
                        col--; row--; colMax--; dir = 'u';
                    }
                    break;
                case 'u': row--;                                // if direction is "up"
                    if (row < rowMin)
                    {
                        col--; row++; rowMin++; dir = 'l';
                    }
                    break;
                case 'l': col--;                                // if direction is "left"
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
        for (int i = 0; i < M.GetLength(0); i++)                    // prints the matrix
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                Console.Write(M[i, j].ToString().PadLeft(2, ' ') + " ");
            }
            Console.WriteLine();
        }
    }
}