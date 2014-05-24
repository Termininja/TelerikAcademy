//Task1: Write a program that reads a year from the console
//       and checks whether it is a leap. Use DateTime.

using System;

public class LeapYear
{
    public static void Main()
    {
        // Reads some year
        Console.Write("Please, enter some year: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int year = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // Check whether the year is a leap and print the result
        Console.SetCursorPosition(30, 0);
        Console.Write(" →  ");
        Console.ForegroundColor = ConsoleColor.Green;
        if (DateTime.IsLeapYear(year)) Console.WriteLine("This is a leap year!");
        else Console.WriteLine("This is not a leap year!");
        Console.ResetColor();
    }
}