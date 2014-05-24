//Task4: Write a program to print the numbers 1, 101 and 1001.

using System;

class PrintNumbers
{
    static void Main()
    {
        // First variant
        Console.WriteLine("1\n101\n1001\n");

        // Second variant
        Console.WriteLine(1 + "\n" + 101 + "\n" + 1001 + "\n");

        // Third variant
        for (int i = 1; i < 101; i *= 10)
        {
            Console.WriteLine(i + ((i != 1) ? "1" : null));
        }
    }
}