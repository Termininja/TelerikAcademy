//Task 7*: Write a program that finds the largest area of equal neighbor elements
//         in a rectangular matrix and prints its size. Example:
//
//         1 3 2 2 2 4
//         3 3 3 2 4 4
//         4 3 1 2 3 3  -> 13
//         4 3 1 3 3 1
//         4 3 3 3 1 1

using System;

class LargestArea
{
    static void Main()
    {
        // Given matrix of elements
        int[,] m = { 
                { 1, 3 ,2 ,2 ,2, 4 }, 
                { 3, 3 ,3 ,2 ,4, 4 }, 
                { 4, 3 ,1 ,2 ,3, 3 }, 
                { 4, 3 ,1 ,3 ,3, 1 }, 
                { 4, 3 ,3 ,3 ,1, 1 } 
                              };

        // Finds the largest area of equal neighbor elements
        int maxPath = 0;
        for (int r = 0; r < m.GetLength(0); r++)
        {
            for (int c = 0; c < m.GetLength(1); c++)
            {
                int count = 1;
                bool[,] tempM = new bool[m.GetLength(0), m.GetLength(1)];
                tempM[r, c] = true;
                FindPath(m, m[r, c], tempM, r, c, ref count);
                if (count > maxPath) maxPath = count;
            }
        }
        Console.WriteLine(maxPath);
    }

    // Find the longest path for some element
    private static void FindPath(int[,] m, int n, bool[,] tempM, int r, int c, ref int count)
    {
        if (r > 0 && tempM[r - 1, c] == false && m[r - 1, c] == n) count = Count(m, n, tempM, count, r - 1, c);
        if (r < m.GetLength(0) - 1 && tempM[r + 1, c] == false && m[r + 1, c] == n) count = Count(m, n, tempM, count, r + 1, c);
        if (c > 0 && tempM[r, c - 1] == false && m[r, c - 1] == n) count = Count(m, n, tempM, count, r, c - 1);
        if (c < m.GetLength(1) - 1 && tempM[r, c + 1] == false && m[r, c + 1] == n) count = Count(m, n, tempM, count, r, c + 1);
    }

    // Count the elements included in the path
    private static int Count(int[,] m, int n, bool[,] tempM, int count, int nr, int nc)
    {
        tempM[nr, nc] = true;
        count++;
        FindPath(m, n, tempM, nr, nc, ref count);
        return count;
    }
}