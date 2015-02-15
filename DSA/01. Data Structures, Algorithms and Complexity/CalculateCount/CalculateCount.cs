using System;

class CalculateCount
{
    static long complexity = 0;

    static void Main()
    {
        // Worst case matrix
        int[,] matrix = new int[,] { 
                {2, 5, 7, 6, 4, 2, 3, 4, 7, 5, 9, 7, 3, 5, 6, 7, 6, 4, 6, 2},
                {4, 8, 1, 2, 4, 2, 1 ,4 ,6 ,7, 9, 3, 9, 6, 6, 6, 3, 5, 1, 2},
                {8, 7, 9, 6, 2, 1, 1, 5, 9, 6, 8, 3, 2, 4, 5, 2, 8, 7, 2, 1},
        };
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        CalcCount(matrix);

        Console.WriteLine("n = {0}\nm = {1}", n, m);
        Console.WriteLine("\nIn the worst case the complexity is: O(n*m)=O({0})", n * m);
        Console.WriteLine("In the best case the complexity is: O(n)=O({0})", n);
        Console.WriteLine("\nComplexity from the test in the worst case: " + complexity);
    }

    private static long CalcCount(int[,] matrix)
    {
        long count = 0;

        // Repeated n times (n = matrix.GetLength(0))
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            // Repeated n times if the first element in the row is even
            if (matrix[row, 0] % 2 == 0)
            {
                // Repeated m times (m = matrix.GetLength(1)) for each n
                // or n*m times in the worst case
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // Repeated n*m times if the element is positive
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        complexity++;
                    }
                }
            }
        }

        return count;
    }
}
