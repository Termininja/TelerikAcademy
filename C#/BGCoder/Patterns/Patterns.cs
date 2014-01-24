using System;
using System.Numerics;

class Patterns
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];

        for (int row = 0; row < N; row++)
        {
            string[] R = Console.ReadLine().Split(' ');
            for (int r = 0; r < N; r++)
            {
                matrix[row, r] = int.Parse(R[r]);
            }
        }

        BigInteger maxSum = 0;
        bool finded = false;
        for (int i = 0; i < N - 2; i++)
        {
            for (int j = 0; j <= N - 5; j++)
            {
                if (
                       matrix[i + 2, j + 3] == matrix[i + 2, j + 4] - 1 &&
                       matrix[i + 2, j + 2] == matrix[i + 2, j + 3] - 1 &&
                       matrix[i + 1, j + 2] == matrix[i + 2, j + 2] - 1 &&
                       matrix[i, j + 2] == matrix[i + 1, j + 2] - 1 &&
                       matrix[i, j + 1] == matrix[i, j + 2] - 1 &&
                       matrix[i, j] == matrix[i, j + 1] - 1
                    )
                {
                    finded = true;
                    BigInteger sum =
                        matrix[i, j] +
                        matrix[i, j + 1] +
                        matrix[i, j + 2] +
                        matrix[i + 1, j + 2] +
                        matrix[i + 2, j + 2] +
                        matrix[i + 2, j + 3] +
                        matrix[i + 2, j + 4];
                    if (sum > maxSum) maxSum = sum;
                }
            }
        }

        if (finded) Console.WriteLine("YES " + maxSum);
        else Console.WriteLine("NO " + Diagonal(matrix, N));
    }

    private static BigInteger Diagonal(int[,] m, int n)
    {
        BigInteger result = new BigInteger();
        for (int i = 0; i < n; i++)
        {
            result += m[i, n - i - 1];
        }
        return result;
    }
}