// Task 2: Write a program that reads a rectangular matrix of size N x M
//         and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class RectangularMatrix
{
    static void Main()
    {
        // Reads the matrix's size
        Console.Write("Please, enter the matrix's size: N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the matrix's size: M = ");
        int M = int.Parse(Console.ReadLine());

        // Fills the matrix by random generator
        Random Generator = new Random();
        int[,] matrix = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = Generator.Next(0, 10);
            }
        }

        // Prints the matrix
        Console.WriteLine("\nA matrix with size {0}x{1} is created by Random Generator:", N, M);
        PrintMatrix(matrix, int.MaxValue, int.MaxValue);

        int Smax = 0;
        int[,] SmaxMatrix = new int[3, 3];
        int maxI = 0;
        int maxJ = 0;

        for (int i = 0; i < N - 2; i++)
        {
            for (int j = 0; j < M - 2; j++)
            {
                int tempSum = 0;
                int[,] tempMatrix = new int[3, 3];

                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        // Calculates the current Sum in this sub-matrix
                        tempSum += matrix[i + x, j + y];

                        // Takes all elements from the current sub-matrix
                        tempMatrix[x, y] = matrix[i + x, j + y];
                    }
                }

                // Compare the current with previous Sum
                if (tempSum >= Smax)
                {
                    Smax = tempSum;
                    SmaxMatrix = tempMatrix;
                    maxI = i;
                    maxJ = j;
                }
            }
        }

        // Prints the sub-matrix with the maximal Sum
        Console.Write("Press any key to find the maximal Sum in this matrix . . .");
        Console.ReadKey();
        Console.WriteLine();
        PrintMatrix(matrix, maxI, maxJ);

        Console.WriteLine("The sub-matrix with maximum Sum of its elements is:");
        PrintMatrix(SmaxMatrix, 0, 0);
    }

    // Print some matrix
    static void PrintMatrix(int[,] M, int mi, int mj)
    {
        Console.WriteLine();
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                if (i >= mi && i < mi + 3 && j >= mj && j < mj + 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.Write(M[i, j].ToString().PadLeft(2, ' ') + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}