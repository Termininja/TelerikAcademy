// Task 3: We are given a matrix of strings of size N x M. Sequences in the matrix we define
//         as sets of several neighbor elements located on the same line, column or diagonal.
//         Write a program that finds the longest sequence of equal strings in the matrix. Example:
//
//         ha  fifi  ho  hi                            s qq s    
//         fo  ha    hi  xx   ->  ha,ha,ha            pp pp s    -> s,s,s
//         xxx ho    ha  xx                           pp qq s    

using System;

class SequencesInMatrix
{
    static int maxLength = 0;
    static string maxWord = String.Empty;

    static void Main()
    {
        // Print some given matrix
        string[,] Matrix = { { "ha", "fifi", "ho", "hi" }, { "fo", "ha", "hi", "xx" }, { "xxx", "ho", "ha", "xx" } };
        Console.WriteLine("The given matrix:");
        PrintMatrix(Matrix);

        // Checks all elements in the matrix
        for (int row = 0; row < Matrix.GetLength(0); row++)
        {
            for (int col = 0; col < Matrix.GetLength(1); col++)
            {
                string currWord = Matrix[row, col];
                int currLengthRow = 1;                      // the maximum length of sequence by row
                int currLengthCol = 1;                      // the maximum length of sequence by column
                int currLengthDiag1 = 1;                    // the maximum length of sequence by diagonal 1 (right-top)
                int currLengthDiag2 = 1;                    // the maximum length of sequence by diagonal 2 (right-down)
                while (row > 0 && row < Matrix.GetLength(0) && Matrix[row, col] == Matrix[row - 1, col])
                {
                    currLengthRow++;                        // the lenght of current sequence by row
                    row++;
                }
                while (col > 0 && col < Matrix.GetLength(1) && Matrix[row, col] == Matrix[row, col - 1])
                {
                    currLengthCol++;                        // the lenght of current sequence by column
                    col++;
                }
                while (col > 0 && col < Matrix.GetLength(1) && row > 0 && row < Matrix.GetLength(0) && Matrix[row, col] == Matrix[row + 1, col - 1])
                {
                    currLengthDiag1++;                      // the lenght of current sequence by diagonal 1
                    col++;
                    row--;
                }
                while (col > 0 && col < Matrix.GetLength(1) && row > 0 && row < Matrix.GetLength(0) && Matrix[row, col] == Matrix[row - 1, col - 1])
                {
                    currLengthDiag2++;                      // the lenght of current sequence by diagonal 2
                    col++;
                    row++;
                }

                CheckMax(currWord, currLengthRow);          // is the current length by row bigger than max value
                CheckMax(currWord, currLengthCol);          // is the current length by column bigger than max value
                CheckMax(currWord, currLengthDiag1);        // is the current length by diagonal 1 bigger than max value
                CheckMax(currWord, currLengthDiag2);        // is the current length by diagonal 2 bigger than max value
            }
        }

        // Prints the longest sequence
        Console.Write("\nThe longest sequence of equal strings in the matrix is: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        PrintSequence(maxLength, maxWord);
        Console.ResetColor();
    }

    private static void CheckMax(string currWord, int currLen)
    {
        if (currLen >= maxLength)
        {
            maxLength = currLen;
            maxWord = currWord;
        }
    }

    // Prints the max sequence
    private static void PrintSequence(int len, string word)
    {
        for (int i = 0; i < len; i++)
        {
            Console.Write(word);
            if (i != len - 1) Console.Write(", ");
        }
        Console.WriteLine("\n");
    }

    // Prints some matrix
    static void PrintMatrix(string[,] M)
    {
        Console.WriteLine();
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                Console.Write(M[i, j].PadRight(5, ' ') + " ");
            }
            Console.WriteLine();
        }
    }
}