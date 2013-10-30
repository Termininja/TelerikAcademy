//Task16: Write a program that reads two dates in the format: day.month.year
//        and calculates the number of days between them. Example:
//              Enter the first date: 27.02.2006
//              Enter the second date: 3.03.2006
//              Distance: 4 days

using System;
using System.Globalization;

class TwoDates
{
    static void Main()
    {
        bool end = false;
        while (!end)        // to repeat if some date is wrong
        {
            try
            {
                // reads the 1st date in format "d.M.yyyy"
                Console.Write("Please, enter the 1st date (d.M.yyyy): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                DateTime date1 = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
                Console.ResetColor();

                // reads the 2nd date in format "d.M.yyyy"
                Console.Write("Please, enter the 2nd date (d.M.yyyy): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                DateTime date2 = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
                Console.ResetColor();

                //prints the number of days between date1 and date2
                Console.Write("Distance: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Math.Abs((date1 - date2).TotalDays) + " days");
                Console.ResetColor();
                end = true;                 // stops the loop
            }
            catch (FormatException)         // if some date is wrong
            {
                Console.ResetColor();
                continue;
            }
        }
    }
}