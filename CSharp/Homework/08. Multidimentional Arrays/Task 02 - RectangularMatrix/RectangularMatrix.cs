//Task 2: Write a program that reads a rectangular matrix of size N x M
//        and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class RectangularMatrix
{
    static void Main()
    {
        Random Generator = new Random();

        Console.Write("Please, enter some number: N = ");   // reads the number N
        int N = int.Parse(Console.ReadLine());
        Console.Write("Please, enter some number: M = ");   // reads the number M
        int M = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = Generator.Next(0, 10);       // fills the matrix by random generator
            }
        }
        PrintMatrix(matrix);                                // prints the matrix

        int Smax = 0;                                       // the maximal sum in matrix
        int[,] SMmax = new int[3, 3];                       // the matrix 3x3 with Smax 

        for (int i = 0; i < N - 2; i++)
        {
            for (int j = 0; j < M - 2; j++)
            {
                int S = 0;                                  // temporary sum
                int[,] SM = new int[3, 3];                  // temporary matrix

                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        S += matrix[i + x, j + y];          // calculates the current sum in this sub-matrix
                        SM[x, y] = matrix[i + x, j + y];    // takes all elements from the current sub-matrix
                    }
                }
                if (S >= Smax)                              // compares with previous sum
                {
                    Smax = S;
                    SMmax = SM;
                }
            }
        }
        Console.WriteLine();
        PrintMatrix(SMmax);                                 // prints the sub-matrix with the maximal sum
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