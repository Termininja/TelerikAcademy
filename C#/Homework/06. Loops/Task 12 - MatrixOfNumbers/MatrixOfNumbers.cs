//Task 12: Write a program that reads from the console a positive integer number N < 20 and outputs a matrix like:
//
//         N = 3 →  1 2 3               N = 4 →  1 2 3 4
//                  2 3 4                        2 3 4 5
//                  3 4 5                        3 4 5 6
//                                               4 5 6 7

using System;
using System.Threading;

class MatrixOfNumbers
{
    // Start from number 1
    static int number = 1;

    // The position of the number
    static void Number(int numJ, int numI, int num)
    {
        Thread.Sleep(150);
        Console.SetCursorPosition(4 * numJ + 1, 2 * numI + 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(num);
        Console.ResetColor();
    }

    // One row from the table
    static void T(int y, int n, char ch1, char ch2, char ch3, char space)
    {
        Console.SetCursorPosition(3, y);
        Console.Write(ch1);                                     // the left character of the row
        Console.Write(new string(space, 4 * n - 1));            // the space between 'ch1' and 'ch2'
        Console.Write(ch2);                                     // the right character of the row
        for (int z = 7; z <= n * 4; z += 4)                     // marks the columns from the table
        {
            Console.SetCursorPosition(z, y);
            Console.Write(ch3);
        }
    }

    static void Main()
    {
        int n = 0;
        while (n < 1 || n > 19)                                 // the number has to be from 1 to 19
        {
            Console.Clear();
            Console.Write("Enter some positive integer number (1-19): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            n = int.Parse(Console.ReadLine());                  // numbers for one row
            Console.ResetColor();
        }

        // The table
        T(2, n, '┌', '┐', '┬', '─');                            // the 1st row
        T(3, n, '│', '│', '│', ' ');                            // the 2nd row
        for (int z = 3; z < 2 * n; z += 2)                      // if the rows are more than 1
        {
            T(z + 1, n, '├', '┤', '┼', '─');
            T(z + 2, n, '│', '│', '│', ' ');
        }
        T(4 + 2 * (n - 1), n, '└', '┘', '┴', '─');              // the last row

        Thread.Sleep(500);
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                Number(j, i, number);
                number++;
            }
            number = i + 1;
            Console.WriteLine();
        }
        Console.SetCursorPosition(0, 2 * n + 4);
    }
}