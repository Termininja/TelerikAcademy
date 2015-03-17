/*
 * Problem 8. Matrix:
 *     Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
 * 
 * Problem 9. Matrix indexer:
 *     Implement an indexer this[row, col] to access the inner matrix cells.
 * 
 * Problem 10. Matrix operations:
 *     Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
 *     Throw an exception when the operation cannot be performed.
 *     Implement the true operator (check for non-zero elements).
 */

namespace Matrix
{
    using System;

    public class Program
    {
        // Rows and columns of the matrices
        private const int Rows = 4;
        private const int Cols = 4;

        private static Random rand = new Random();

        public static void Main()
        {
            // Creates two matrices of the same size
            var matrix1 = new Matrix<float>(Rows, Cols);
            var matrix2 = new Matrix<float>(Rows, Cols);

            // Generate values for the matrices by random generator
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    matrix1[r, c] = rand.Next(-100, 100) * 0.37f;
                    matrix2[r, c] = rand.Next(-100, 100) * 0.37f;
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
            Console.WriteLine("Matrix 1 is: {0}ero matrix!", matrix1 ? "Non-z" : "Z");

            matrix2.Clear();
            Console.WriteLine("Matrix 2 is: {0}ero matrix!", matrix2 ? "Non-z" : "Z");
            Console.WriteLine("Matrix 1 is: {0}ero matrix!", !matrix1 ? "Z" : "Non-z");
        }

        // Prints some matrix
        private static void Print(object matrix, string text)
        {
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(matrix);
            Console.ResetColor();
        }
    }
}