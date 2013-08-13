//Task1: Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Please, enter some year: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int year = int.Parse(Console.ReadLine());           // reads the year
        Console.ResetColor();
        Console.SetCursorPosition(30, 0);                   // sets the cursor position on the same row
        Console.Write(" →  ");
        Console.ForegroundColor = ConsoleColor.Green;
        if (DateTime.IsLeapYear(year))                      // is this year leap
        {
            Console.WriteLine("This is a leap year!");
        }
        else                                                // if this year is not a leap
        {
            Console.WriteLine("This is not a leap year!");
        }
        Console.ResetColor();
    }
}