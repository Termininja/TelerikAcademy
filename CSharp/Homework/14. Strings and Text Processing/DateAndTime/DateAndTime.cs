//Task17: Write a program that reads a date and time given in the format:
//        day.month.year hour:minute:second and prints the date and time after 6 hours
//        and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;

class DateAndTime
{
    static void Main()
    {
        // reads some date and time in format "d.M.yyyy H:m:s"
        Console.Write("Please, enter some date and time (d.M.yyyy H:m:s): ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy H:m:s", CultureInfo.InvariantCulture);
        Console.ResetColor();

        // prints the date and time after 6 hours and 30 min
        Console.Write("The date and time after 390 min will be: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(dateTime.AddMinutes(390).ToString("dd MMMM yyyy (dddd) H:m:s", new CultureInfo("bg-BG")));
        Console.ResetColor();
    }
}