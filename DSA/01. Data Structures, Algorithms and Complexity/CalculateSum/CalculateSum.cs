using System;

class CalculateSum
{
    static long complexity = 0;

    static void Main()
    {
        int[,] matrix = new int[,] { 
                {2, 5, 7, 6, 4, 2, 3, 4, 7, 5, 9, 7, 3, 5, 6, 7, 6, 4, 6, 2},
                {4, 8, 1, 2, 4, 2, 1 ,4 ,6 ,7, 9, 3, 9, 6, 6, 6, 3, 5, 0, 2},
                {3, 7, 9, 6, 2, 1, 1, 5, 9, 6, 0, 3, 2, 4, 5, 2, 8, 7, 2, 1},
            };
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        try
        {
            Console.WriteLine(CalcSum(matrix, 0));
        }
        catch (Exception)
        {
            Console.WriteLine("n = {0}\nm = {1}", n, m);
            Console.WriteLine("\nWithout exception the final complexity would be: O(n*m) = O({0})", n * m);
            Console.WriteLine("In our case m=n, so the complexity is: O(n*m) = O(n*n) = O({0})", n * n);
            Console.WriteLine("\nComplexity from the test: " + complexity);
        }
    }

    private static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;

        // repeated n times (n = matrix.GetLength(0))
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            sum += matrix[row, col];
            complexity++;
        }

        // normaly should repeate m times (m = matrix.GetLength(1))
        // but actually stop when m=n with IndexOutOfRangeException 
        if (row + 1 < matrix.GetLength(1))
        {
            sum += CalcSum(matrix, row + 1);
        }

        return sum;
    }
}