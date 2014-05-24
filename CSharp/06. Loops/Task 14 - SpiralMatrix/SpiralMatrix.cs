//Task 14*: Write a program that reads a positive integer number N (N < 20) from console
//          and outputs in the console the numbers 1,N numbers arranged as a spiral.

using System;
using System.Threading;

public class SpiralMatrix
{
    static int i = 0;                                   // count each one ring of numbers 
    static int x = 0;                                   // 'x' position
    static int y = 0;                                   // 'y' position
    static int number = 1;                              // start from number 1
    static int coor;                                    // value of x or y coordinate

    // The position of the number
    static void N(int m, int start, int stop, int f)
    {
        for (coor = start; coor < stop; coor += f)
        {
            Thread.Sleep(150);
            switch (m)
            {
                case 0: Console.SetCursorPosition(Math.Abs(coor) + 4, Math.Abs(y) + 3); break;
                case 1: Console.SetCursorPosition(Math.Abs(x) + 4, Math.Abs(coor) + 3); break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(number);
            Console.ResetColor();
            number++;
        }
        switch (m)
        {
            case 0: x = coor -= f; break;               // the distance between the numbers;
            case 1: y = coor -= f; break;               // remove the previous "z += f"
        }
    }

    // One row from the table
    static void T(int y, int n, char ch1, char ch2, char ch3, char space)
    {
        Console.SetCursorPosition(3, y);
        Console.Write(ch1);
        Console.Write(new string(space, 4 * n - 1));
        Console.Write(ch2);
        for (int z = 7; z <= n * 4; z += 4)
        {
            Console.SetCursorPosition(z, y);
            Console.Write(ch3);
        }
    }

    public static void Main()
    {
        int n = 0;
        while (n < 1 || n > 19)                         // the number has to be from 1 to 19
        {
            Console.Clear();
            Console.Write("Enter some positive integer number (1-19): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            n = int.Parse(Console.ReadLine());          // the numbers for one row
            Console.ResetColor();
        }
        /*Table */
        T(2, n, '┌', '┐', '┬', '─');                    // the 1st row
        T(3, n, '│', '│', '│', ' ');                    // the 2nd row
        for (int z = 3; z < 2 * n; z += 2)              // if the rows are more than 1
        {
            T(z + 1, n, '├', '┤', '┼', '─');
            T(z + 2, n, '│', '│', '│', ' ');
        }
        T(4 + 2 * (n - 1), n, '└', '┘', '┴', '─');      // the last row

        Thread.Sleep(500);
        while (number <= n * n)                         // one ring of numbers is one loop
        {
            N(0, 4 * i, 4 * (n - i), 4);                // 1st part of the ring (left-to-right)
            N(1, 2 * (i + 1), 2 * (n - i), 2);          // 2nd part of the ring (up-to-down)
            N(0, 4 * (i + 2 - n), 1 - 4 * i, 4);        // 3rd part of the ring (right-to-left)
            N(1, 2 * (i + 2 - n), -2 * i, 2);           // 4th part of the ring (down-to-top)
            i++;                                        // go to the next ring
        }
        Console.SetCursorPosition(0, 2 * n + 4);        // remove the cursor from the center of the ring 
    }
}