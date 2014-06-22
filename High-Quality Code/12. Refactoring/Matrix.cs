namespace Matrix
{
    using System;

    public class WalkInMatrix
    {
        public static void Main()
        {
            Console.Write("Enter some positive number: ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number!");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[n, n];
            int step = n;
            int k = 1;
            int i = 0;
            int j = 0;
            FindSeries(n, matrix, ref k, ref i, ref j);

            FindCell(matrix, out i, out j);
            k++;

            FindSeries(n, matrix, ref k, ref i, ref j);

            PrintMatrix(n, matrix);
        }

        private static void FindSeries(int n, int[,] matrix, ref int k, ref int i, ref int j)
        {
            int dx = 1;
            int dy = 1;

            while (true)
            {
                matrix[i, j] = k;

                if (!Check(matrix, i, j))
                {
                    break;
                }

                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                {
                    while (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        Change(ref dx, ref dy);
                    }
                }

                i += dx;
                j += dy;
                k++;
            }
        }

        private static void Change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;
            for (int i = 0; i < 8; i++)
            {
                if (dirX[i] == dx && dirY[i] == dy)
                {
                    cd = i;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        private static bool Check(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    Console.Write("{0,3}", matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
