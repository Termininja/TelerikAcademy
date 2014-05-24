//Task19: Write a program that extracts from a given text all dates that match
//        the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        // Reads some text including dates
        Console.WriteLine("Please, enter some text including dates in format day.month.year: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        // For each date in the text
        Console.WriteLine("\nThe dates are:");
        foreach (var date in Regex.Matches(text, @"\d\d?\.\d\d?\.\d{4}"))
        {
            // The real date
            DateTime result;

            // Prints all dates
            Console.ForegroundColor = ConsoleColor.Green;
            if (DateTime.TryParseExact(date.ToString(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                Console.WriteLine(result.ToShortDateString().ToString(new CultureInfo("en-CA")));
            }
            Console.ResetColor();
        }
    }
}