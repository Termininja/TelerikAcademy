//Task5: Write a program that reads a text file containing a square matrix of numbers
//       and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
//       The first line in the input file contains the size of matrix N.
//       Each of the next N lines contain N numbers separated by space.
//       The output should be a single number in a separate text file.
//       Example:      4
//                     2 3 3 4
//                     0 2 3 4  →  17
//                     3 7 1 2
//                     4 3 3 2

using System;
using System.IO;

class SquareMatrix
{
    static void Main()
    {
        StreamReader file = new StreamReader("file.txt");           // reads some text file
        using (file)
        {
            int size = int.Parse(file.ReadLine());                  // reads the first line
            int[,] matrix = new int[size, size];                    // creates some empty matrix

            for (int line = 0; line < size; line++)                 // fills the matrix
            {
                // Reads each one line from matrix in the file
                string[] currentLine = file.ReadLine().Split(' ');  

                // Reads each line element from the matrix in the file
                for (int col = 0; col < size; col++)                
                {
                    matrix[line, col] = int.Parse(currentLine[col]);
                }
            }

            // Calculates the maximum sum of elements in an area of size 2 x 2
            int sumMax = int.MinValue;
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    int currentSum = 
                        matrix[i - 1, j - 1] +
                        matrix[i, j - 1] + 
                        matrix[i - 1, j] + 
                        matrix[i, j];
                    if (currentSum >= sumMax) sumMax = currentSum;
                }
            }

            // Write the result in some output file
            StreamWriter write = new StreamWriter("output.txt");   
            using (write) write.WriteLine(sumMax);
        }
    }
}