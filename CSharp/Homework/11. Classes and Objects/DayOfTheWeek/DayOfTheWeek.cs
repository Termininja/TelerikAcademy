//Task3: Write a program that prints to the console which day of the week is today.
//       Use System.DateTime.

using System;

class DayOfTheWeek
{
    static void Main()
    {
        Console.Write("Today is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine((DateTime.Now).DayOfWeek);        // prints the day of the week
        Console.ResetColor();
    }
}