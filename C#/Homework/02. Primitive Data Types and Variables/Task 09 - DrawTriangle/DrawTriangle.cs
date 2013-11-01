//Task 9: Write a program that prints an isosceles triangle of 9 copyright
//        symbols ©. Use Windows Character Map to find the Unicode code of
//        the © symbol. Note: the © symbol may be displayed incorrectly.

using System;
using System.Text;

class DrawTriangle
{
    static void Main()
    {
        // Declaring a char variable with value ©
        Console.OutputEncoding = Encoding.UTF8;
        char copyright = '\u00A9';

        // First variant
        // Console.WriteLine("   {0}\n  {0} {0}\n {0}   {0}\n{0} {0} {0} {0}", copyright);

        // Second variant
        Console.Write("Please, enter the number of the rows: ");
        int N = int.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string(' ', N - 1) + copyright);  // top of the isosceles triangle
        for (int row = 0; row < N - 2; row++)
        {
            Console.WriteLine(new string(' ', N - row - 2) + copyright + new string(' ', 2 * row + 1) + copyright);
        }
        for (int i = 1; i <= 2 * N - 1; i++)                    // the bottom side
        {
            if (i % 2 == 0) Console.Write(" ");
            else Console.Write(copyright);
        }
        Console.ResetColor();
        Console.WriteLine("\n");
    }
}