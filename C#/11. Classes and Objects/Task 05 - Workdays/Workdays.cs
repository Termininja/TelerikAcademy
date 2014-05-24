//Task5: Write a method that calculates the number of workdays between today and given date,
//       passed as parameter. Consider that workdays are all days from Monday to Friday
//       except a fixed list of public holidays specified preliminary as array.

using System;

public class Workdays
{
    public static void Main()
    {
        // Reads some date
        Console.Write("Please, enter some date in format MM/DD/YYYY: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.ResetColor();

        // Calculates the number of workdays
        WorkDays(Holidays(), date);
    }

    static void WorkDays(DateTime[] holidays, DateTime date)
    {
        // Calculates today date
        DateTime now = DateTime.Parse(DateTime.Now.ToShortDateString());

        // Calculates all days
        int allDays = (int)Math.Abs(now.ToOADate() - date.ToOADate());

        // If the date is before today
        if (now > date)
        {
            DateTime temp = now;
            now = date;
            date = temp;
        }


        // Checks all days
        int holiday = 0;
        for (DateTime d = now; d < date; d = d.AddDays(1))
        {
            // Calculates the holidays from the weekends
            if (d.DayOfWeek.ToString() == "Sunday" || d.DayOfWeek.ToString() == "Saturday") holiday++;
            else
            {
                // Checks for some other holidays
                foreach (DateTime h in holidays)
                {
                    if (h.Day == d.Day && h.Month == d.Month) holiday++;
                }
            }
        }

        // Print the result
        Console.Write("\nFrom {0} to {1} there are ", now.ToString("dd MMMM yyyy"), date.ToString("dd MMMM yyyy"));

        // Prints the workdays 
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(allDays - holiday);
        Console.ResetColor();
        Console.Write(" workdays and ");

        // Prints the holidays
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(holiday);
        Console.ResetColor();
        Console.WriteLine(" holidays");
    }

    // List of some holidays
    static DateTime[] Holidays()
    {
        DateTime[] h = new DateTime[]                                      
            {
                new DateTime(2013, 01, 01),
                new DateTime(2013, 03, 03),
                new DateTime(2013, 05, 01),
                new DateTime(2013, 05, 06),
                new DateTime(2013, 05, 24),
                new DateTime(2013, 09, 06),
                new DateTime(2013, 09, 22),
                new DateTime(2013, 11, 01),
                new DateTime(2013, 12, 24),
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2013, 12, 31),
            };
        return h;
    }
}