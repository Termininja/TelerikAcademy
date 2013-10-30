//Task 9: Write a program that prints an isosceles triangle of 9 copyright symbols ©.
//Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

using System;
using System.Text;

class DrawTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char copyright = '\u00A9';

        //First variant: very simple
        //Console.WriteLine("   {0}\n  {0} {0}\n {0}   {0}\n{0} {0} {0} {0}", copyright);

        //Second variant: with numbers of rows by choice (n = 4 for our case)
        Console.Write("Please, enter the number of the rows: ");
        int n = int.Parse(Console.ReadLine());
        for (int row = 1; row < n; row++)            		    // it's draw the top of the isosceles triangle 
        {
            int prevRow = row - 1;                                  // the previous row number
            for (int col = 1; col <= 2 * n - 1; col++)
            {
                if (col < n - prevRow || col > n + prevRow)         // this draw the full triangle
                {
                    Console.Write(" ");
                }
                else
                {
                    if (col < n - (prevRow - 1) || col > n + (prevRow - 1))	// this remove the interior part
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(copyright);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
        }
        for (int i = 1; i <= 2 * n - 1; i++)                            // it's draw the bottom side
        {
            if (i % 2 == 0)
            {
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(copyright);
                Console.ResetColor();
            }
        }
        Console.WriteLine("\n");
    }
}