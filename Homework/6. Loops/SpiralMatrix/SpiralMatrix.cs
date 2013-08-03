﻿//Task 14*: Write a program that reads a positive integer number N (N < 20) from console
//          and outputs in the console the numbers 1,N numbers arranged as a spiral.

using System;
using System.Threading;

class SpiralMatrix
{
    static int i = 0;                                           // this count each one ring of numbers 
    static int x = 0;                                           // 'x' position
    static int y = 0;                                           // 'y' position
    static int number = 1;                                      // we start from number 1
    static int z;                                               // value of x or y coordinate
    static void N(int m, int start, int stop, int f)            // position of the number
    {
        for (z = start; z < stop; z += f)
        {
            Thread.Sleep(150);
            switch (m)                                          // x or y coordinate
            {
                case 0: Console.SetCursorPosition(Math.Abs(z) + 4, Math.Abs(y) + 3); break;
                case 1: Console.SetCursorPosition(Math.Abs(x) + 4, Math.Abs(z) + 3); break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(number);
            Console.ResetColor();
            number++;                                           // go to next number
        }
        switch (m)
        {
            case 0: x = z -= f; break;                          // distance between numbers;
            case 1: y = z -= f; break;                          // remove the previous "z += f"
        }
    }

    static void T(int y, int n, char ch1, char ch2, char ch3, char space)   // one row of the table
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
        /*Table */
        T(2, n, '┌', '┐', '┬', '─');                            // the 1st row
        T(3, n, '│', '│', '│', ' ');                            // the 2nd row
        for (int z = 3; z < 2 * n; z += 2)                      // if the rows are more than 1
        {
            T(z + 1, n, '├', '┤', '┼', '─');
            T(z + 2, n, '│', '│', '│', ' ');
        }
        T(4 + 2 * (n - 1), n, '└', '┘', '┴', '─');              // the last row

        Thread.Sleep(500);
        while (number <= n * n)                                 // one ring of numbers is one loop
        {
            N(0, 4 * i, 4 * (n - i), 4);                        // 1st part of the ring (left-to-right)
            N(1, 2 * (i + 1), 2 * (n - i), 2);                  // 2nd part of the ring (up-to-down)
            N(0, 4 * (i + 2 - n), 1 - 4 * i, 4);                // 3rd part of the ring (right-to-left)
            N(1, 2 * (i + 2 - n), -2 * i, 2);                   // 4th part of the ring (down-to-top)
            i++;                                                // go to the next ring
        }
        Console.SetCursorPosition(0, 2 * n + 4);                // remove the cursor from the center of the ring 
    }
}