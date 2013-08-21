//Task19: Write a program that extracts from a given text all dates that match
//        the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        Console.WriteLine("Please, enter some text including dates in format day.month.year: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                                       // reads some text including dates
        Console.ResetColor();

        Console.WriteLine("\nThe dates are:");
        foreach (var date in Regex.Matches(text, @"\d\d?\.\d\d?\.\d{4}"))       // for each date in the text
        {
            DateTime result;                                                    // the real date
            Console.ForegroundColor = ConsoleColor.Green;
            if (DateTime.TryParseExact(date.ToString(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                Console.WriteLine(result.ToShortDateString().ToString(new CultureInfo("en-CA")));   // prints the all dates
            }
            Console.ResetColor();
        }
    }
}