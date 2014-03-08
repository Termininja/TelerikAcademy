/*
 * Task 08: Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
 * 
 * Task 09: Implement an indexer this[row, col] to access the inner matrix cells.
 * 
 * Task 10: Implement the operators + and - (addition and subtraction of matrices of the same size)
 *          and * for matrix multiplication. Throw an exception when the operation cannot be performed.
 *          Implement the true operator (check for non-zero elements).
 */

using System;

namespace Matrix
{
    class Program
    {
        // Rows and columns of the matrices
        private const int Rows = 4;
        private const int Cols = 4;

        static void Main()
        {
            // Creates two matrices of the same size
            Matrix<float> matrix1 = new Matrix<float>(Rows, Cols);
            Matrix<float> matrix2 = new Matrix<float>(Rows, Cols);

            // Generate values for the matrices by random generator
            Random Generator = new Random();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    matrix1[r, c] = Generator.Next(-100, 100) * 0.37f;
                    matrix2[r, c] = Generator.Next(-100, 100) * 0.37f;
                }
            }
            matrix2[1, 2] = 0;

            // Print the result
            Print(matrix1, "Matrix 1");
            Print(matrix2, "Matrix 2");
            Print(matrix1 + matrix2, "Matrix 1 + Matrix 2");
            Print(matrix1 - matrix2, "Matrix 1 - Matrix 2");
            Print(matrix1 * matrix2, "Matrix 1 * Matrix 2");

            // Checks for non-zero elements
            Console.WriteLine("Matrix 1 is: {0}", matrix1 ? "Non-zero matrix!" : "Zero matrix!");

            matrix2.Clear();
            Console.WriteLine("Matrix 2 is: {0}", matrix2 ? "Non-zero matrix!" : "Zero matrix!");

            Console.Write("Matrix 1 is: ");
            if (!matrix1) Console.WriteLine("Zero matrix!");
            else Console.WriteLine("Non-zero matrix!");
        }

        // Prints some matrix
        private static void Print(object matrix, string text)
        {
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(matrix);
            Console.ResetColor();
        }
    }
}