//Task3: Write a program that prints to the console which day
//       of the week is today. Use System.DateTime.

using System;

public class DayOfTheWeek
{
    public static void Main()
    {
        // Prints the day of the week
        Console.Write("Today is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine((DateTime.Now).DayOfWeek);
        Console.ResetColor();
    }
}