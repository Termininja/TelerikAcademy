//Task5: Write a method that calculates the number of workdays between today and given date,
//       passed as parameter. Consider that workdays are all days from Monday to Friday
//       except a fixed list of public holidays specified preliminary as array.

using System;

class Workdays
{
    static void Main()
    {
        DateTime[] holidays = Holidays();

        Console.Write("Please, enter some date in format MM/DD/YYYY: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime date = DateTime.Parse(Console.ReadLine());                 // reads some date
        Console.ResetColor();

        WorkDays(holidays, date);
    }

    static void WorkDays(DateTime[] holidays, DateTime date)
    {
        DateTime now = DateTime.Parse(DateTime.Now.ToShortDateString());    // what is today date

        int allDays = (int)Math.Abs(now.ToOADate() - date.ToOADate());      // calculates the all days

        if (now > date)                                                     // is the date before now
        {
            DateTime temp = now;
            now = date;
            date = temp;
        }

        int holiday = 0;
        for (DateTime d = now; d < date; d = d.AddDays(1))                  // checks for all days
        {
            if (d.DayOfWeek.ToString() == "Sunday" || d.DayOfWeek.ToString() == "Saturday")
            {
                holiday++;                                                  // calculates the holidays from the weekends
            }
            else
            {
                foreach (DateTime h in holidays)                            // checks for some other holidays
                {
                    if (h.Day == d.Day && h.Month == d.Month)
                    {
                        holiday++;
                    }
                }
            }
        }
        Console.Write("\nFrom {0} to {1} there are ", now.ToString("dd MMMM yyyy"), date.ToString("dd MMMM yyyy"));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(allDays - holiday);                                   // prints the workdays 
        Console.ResetColor();
        Console.Write(" workdays and ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(holiday);                                             // prints the holidays
        Console.ResetColor();
        Console.WriteLine(" holidays");
    }

    static DateTime[] Holidays()
    {
        DateTime[] h = new DateTime[]                                       // list of holidays
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