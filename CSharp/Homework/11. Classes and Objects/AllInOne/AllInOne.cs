using System;
using System.Numerics;
using System.Threading;
using System.Collections.Generic;

class AllTasks
{
    static void Color(string w, string s)
    {
        switch (s)
        {
            case "darkred": Console.ForegroundColor = ConsoleColor.DarkRed; break;
            case "green": Console.ForegroundColor = ConsoleColor.Green; break;
            case "darkgray": Console.ForegroundColor = ConsoleColor.DarkGray; break;
            default: break;
        }
        Console.Write(w);
        Console.ResetColor();
    }

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        Console.SetCursorPosition(47, 10);
        Console.Write("Welcome!");
        Thread.Sleep(2000);

        while (true)
        {
            Console.Clear();
            Content();
            Color("   Please, select a task number from ", "darkgray");
            Color("<", "green");
            Color("1", "darkgray");
            Color(">", "green");
            Color(" to ", "darkgray");
            Color("<", "green");
            Color("7", "darkgray");
            Color(">", "green");
            Color(" or press ", "darkgray");
            Color("<", "green");
            Color("Esc", "darkgray");
            Color(">", "green");
            Color(" to exit: ", "darkgray");
            Console.ForegroundColor = ConsoleColor.Cyan;

            ConsoleKeyInfo key = Console.ReadKey();
            for (ConsoleKey k = ConsoleKey.D1; k <= ConsoleKey.D7; k++)
            {
                if (key.Key == k)
                {
                    Tasks(int.Parse(k.ToString().TrimStart('D')));
                }
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Exit();
            }
        }
    }

    static void Content()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n\t\t\t\t\t     C# - Part 2");
        Console.WriteLine("\n   Homework 5. Classes and Objects");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Write a program that reads a year and checks is it a leap. Use DateTime.

      Task 2: Write a program that generates and prints to the console 10 random values in
              the range [100, 200].

      Task 3: Write a program that prints which day of the week is today. Use DateTime.

      Task 4: Write methods that calculate the surface of a triangle by given: Side and an
              altitude to it; 3 sides; 2 sides and an angle between them. Use System.Math.

      Task 5: Write a method that calculates the number of workdays between today and given
              date, passed as parameter. Consider that workdays are all days from Monday to
              Friday except a fixed list of public holidays specified preliminary as array.

      Task 6: You are given a sequence of positive integer values written into a string,
              separated by spaces. Write a function that reads these values from one string
              and calculates their sum. Example: string = ""43 68 9 23 318"" → result = 461

      Task 7: Write a program that calculates the value of given arithmetical expression.
              The expression can contain the following elements only: Real numbers, e.g.
              5, 18.33, 3.14159, 12.6; Arithmetic operators: +, -, *, / ; Mathematical
              functions: ln(x), sqrt(x), pow(x,y); Brackets (for changing the priorities).
              Examples:
                        (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) → ~ 10.6
                        pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) → ~ 21.22
              Hint: Use the ""shunting yard"" algorithm and ""reverse Polish notation"".
                         ");
    }

    static void Exit()
    {
        Console.Clear();
        Console.SetCursorPosition(47, 10);
        Console.ResetColor();
        Console.Write("Goodbye!");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }

    static void Tasks(int choose)
    {
    start: try
        {
            Console.ResetColor();
            Console.Clear();
            switch (choose)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
            }
            Color("\n\nThis was the end of the program.\nPress ", "darkgray");
            Color("<", "green");
            Color("Enter", "darkgray");
            Color(">", "green");
            Color(" to try again or ", "darkgray");
            Color("<", "green");
            Color("Esc", "darkgray");
            Color(">", "green");
            Color(" to go to Main Menu . . .", "darkgray");
        keys:
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                goto start;
            }
            if (key.Key != ConsoleKey.Escape)
            {
                Console.Write("\b \b");
                goto keys;
            }
            Console.Clear();
        }
        catch (Exception)
        {
            Color("\n\nYou made something wrong!\nPress any key to try again . . .", "darkred");
            Console.ReadKey();
            Console.Clear();
            goto start;
        }
    }

    static void Task1()
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
    static void Task2()
    {
        Random RandomGenerator = new Random();                      // sets a random generator
        for (int i = 0; i < 10; i++)                                // for each 10 values
        {
            for (int j = 0; j < 100; j++)                           // takes the last from 99 times
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("  Random value {0:00}: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(RandomGenerator.Next(100, 201));  // prints the result
                Console.ResetColor();
                Thread.Sleep(20);                                   // sleep the program for 20ms
            }
        }
    }
    static void Task3()
    {
        Console.Write("Today is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine((DateTime.Now).DayOfWeek);        // prints the day of the week
        Console.ResetColor();
    }
    static void Task4()
    {
        Console.Write(@"Please, select some method:
  1 - Side and an altitude to it
  2 - Three sides
  3 - Two sides and an angle between them");

    Tasks:
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)                                        // to select some method
        {
            case ConsoleKey.D1: TaskMethods.Choose(1); TaskMethods.SideAndAltitude(); break;
            case ConsoleKey.D2: TaskMethods.Choose(2); TaskMethods.ThreeSides(); break;
            case ConsoleKey.D3: TaskMethods.Choose(3); TaskMethods.TwoSidesAndAngle(); break;
            default: Console.Write("\b \b"); goto Tasks;
        }
    }
    static void Task5()
    {
        DateTime[] holidays = TaskMethods.Holidays();

        Console.Write("Please, enter some date in format MM/DD/YYYY: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime date = DateTime.Parse(Console.ReadLine());                 // reads some date
        Console.ResetColor();

        TaskMethods.WorkDays(holidays, date);
    }
    static void Task6()
    {
        Console.Write("Please, enter some sequence of integer values: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] numbers = Console.ReadLine().Split(' ');       // reads and splits the values
        Console.ResetColor();

        int sum = 0;
        foreach (var item in numbers)                           // checks each one value
        {
            sum += int.Parse(item);                             // sums the values
        }
        Console.Write("The sum of these values is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(sum);                                 // prints the result
        Console.ResetColor();
    }
    static void Task7()
    {
        try
        {
            Console.WriteLine("Please, write some arithmetical expression: ");
            TaskMethods.Examples(1, "3/(1.2*5) - pow(3/8.9E-3 +ln(7/sqrt(12-2.3/4)), sqrt(25/4))*2 - 12");
            TaskMethods.Examples(2, "1/cos(45*4) -tan(7-(3.1*7/sin(12-2.3/4)))/ sqrt(3/4.5-1.2)");
            TaskMethods.Examples(3, "2*(3+(2-(7+(3/sqrt(9*(2+(7/(3*(sin(9*(3-(4/(3-4)))))))))))))-cot(-45)");
            TaskMethods.Examples(4, "cot(sin(tan(ln(cos(sqrt(pow(sin(tan(ln(1))),1)))))))");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n x = ");
            string E = Console.ReadLine();                                  // reads some arithmetical expression
            Console.ResetColor();

            E = E.Replace(" ", "").Replace(',', '_');                       //  removes the all empty intervals and replace ',' with '_'
            E = E.Replace("sin", "v").Replace("cos", "x").Replace("tan", "y").Replace("cot", "z");

            string check = "";
            while (E != check)                                              // it will finish when the result is a number
            {
                check = E;
                foreach (var item in TaskMethods.Operators)                 // checks for each one operator
                {
                    E = TaskMethods.BasicArithmeticOperations(E, item);     // calculates *, /, + or -
                    for (int i = 0; i < E.Length; i++)                      // removes the brackets ( )
                    {
                        E = TaskMethods.PowFunction(E);                     // calculates the Square function
                        TaskMethods.isFunction = false;
                        if (E[i] == '(')                                    // if the bracket is open
                        {
                            if (i > 0)
                            {
                                E = TaskMethods.Functions(E, i, 'n');       // calculates the Natural logarithm function
                                E = TaskMethods.Functions(E, i, 't');       // calculates the Square root function
                                E = TaskMethods.Functions(E, i, 'v');       // calculates the Sinus function
                                E = TaskMethods.Functions(E, i, 'x');       // calculates the Cosinus function
                                E = TaskMethods.Functions(E, i, 'y');       // calculates the Tangens function
                                E = TaskMethods.Functions(E, i, 'z');       // calculates the Cotangens function
                            }
                            if (!TaskMethods.isFunction)                    // if some function is used
                            {
                                E = TaskMethods.BracketsPriority(E, i);
                            }
                        }
                    }
                }
            }

            Console.Write("\n x = ");
            E = E.Contains("NaN") ? "NaN" : E;                  // checks for NaN
            double R = 0;
            if (double.TryParse(E, out R))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(R.ToString("E2"));            // prints the result
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong expression!");         // if there is some error in expression
            }
            Console.ResetColor();
        }
        catch (Exception)                                       // if catch some exception in the program
        {
            Console.Write("\n x = ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong expression!");
            Console.ResetColor();
        }
    }
}

class TaskMethods
{
    public static bool isFunction = false;
    public static char[] Operators = { '*', '/', '+', '-' };
    public static void Choose(byte num)
    {
        Console.Write("\b \b\n\nYour choice was: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(num);
        Console.ResetColor();
        Console.WriteLine("\n");
    }
    public static void SideAndAltitude()
    {
    task1:
        try                                                     // looks for errors
        {
            Console.Write("a = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            decimal a = decimal.Parse(Console.ReadLine());      // reads a one side
            Console.ResetColor();
            Console.Write("h = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            decimal h = decimal.Parse(Console.ReadLine());      // reads the altitude to side 'a'
            Console.ResetColor();
            Console.Write("\nThe area is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("S = a.h /2 = {0}", a * h / 2);   // calculates the triangle area
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ResetColor();
            goto task1;                                         // repeats the task1 when there is some error
        }
    }
    public static void ThreeSides()
    {
    task2:
        try                                                     // looks for errors
        {
            Console.Write("a = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double a = double.Parse(Console.ReadLine());        // reads the first side
            Console.ResetColor();
            Console.Write("b = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double b = double.Parse(Console.ReadLine());        // reads the second side
            Console.ResetColor();
            Console.Write("c = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double c = double.Parse(Console.ReadLine());        // reads the third side
            Console.ResetColor();
            Console.WriteLine("\nThe area is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nS = Sqrt[p.(p-a).(p-b).(p-c)], where p = (a+b+c)/2");

            double p = (a + b + c) / 2;
            Console.WriteLine("\nS = {0}", Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ResetColor();
            goto task2;                                         // repeats the task2 when there is some error
        }
    }
    public static void TwoSidesAndAngle()
    {
    task3:
        try                                                     // looks for errors
        {
            Console.Write("a = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double a = double.Parse(Console.ReadLine());        // reads the first side
            Console.ResetColor();
            Console.Write("b = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double b = double.Parse(Console.ReadLine());        // reads the second side
            Console.ResetColor();
            Console.Write("alpha = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double alpha = double.Parse(Console.ReadLine());    //reads the angle between side 'a' and 'b'
            Console.ResetColor();
            Console.Write("\nThe area is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("S = a.b.sin(alpha)/2 = {0}", a * b * Math.Sin(Math.PI * alpha / 180) / 2);
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ResetColor();
            goto task3;                                         // repeats the task3 when there is some error
        }
    }
    public static void WorkDays(DateTime[] holidays, DateTime date)
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
    public static DateTime[] Holidays()
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
    public static void Examples(int n, string s)
    {
        Console.Write("Example{0}: ", n);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(s);
        Console.ResetColor();
    }
    public static string BracketsPriority(string E, int i)
    {
        double num = 0;
        string temp = "";
        for (int j = i + 1; j < E.Length; j++)
        {
            temp += E[j];

            /* calculates the expression in the brackets */
            if (double.TryParse(temp, out num) && E[j + 1] == ')')
            {
                E = (E.Remove(i, 1)).Remove(j, 1);
                E = TempResult(E);
                break;
            }
        }
        return E;
    }
    public static string PowFunction(string E)
    {
        E = E.Replace("_+", "_");                               // replaces the "_+" with "_"
        for (int p = 0; p < E.Length; p++)
        {
            if (E[p] == '_')                                    // looking for position of "_" (",")
            {
                bool available1, available2;                    // are there two numbers in Pow function
                int before, after;                              // the positions before and after the "_" symbol
                double num1 = SearchNumber(E, p, out available1, out before, 0, p);
                double num2 = SearchNumber(E, p, out available2, out after, p + 1, E.Length);
                if (available1 && available2 && E[before - 1] == '(' && E[E.Length + p - after + 1] == ')')
                {
                    double result = Math.Pow(num1, num2);
                    E = (E.Remove(before - 4, E.Length + p - after - before + 6)).Insert(before - 4, result.ToString());
                    p = 0;
                    E = TempResult(E);
                }
            }
        }
        return E;                                               // returns the calculated Pow function
    }
    public static string Functions(string E, int i, char f)
    {
        if (!isFunction)
        {
            if (E[i - 1] == f)                                  // what is this function
            {
                byte word_len = 0;                              // the length of the function word
                double num = 0;
                string temp = "";
                for (int j = i + 1; j < E.Length; j++)
                {
                    temp += E[j];
                    if (double.TryParse(temp, out num) && E[j + 1] == ')')
                    {
                        /* calculates the expression in the brackets for the respective function*/
                        double result = 0;
                        switch (f)
                        {
                            case 'n': result = Math.Log(num); word_len = 2; break;
                            case 't': result = Math.Sqrt(num); word_len = 4; break;
                            case 'v': result = Math.Sin(num * Math.PI / 180); word_len = 1; break;
                            case 'x': result = Math.Cos(num * Math.PI / 180); word_len = 1; break;
                            case 'y': result = Math.Tan(num * Math.PI / 180); word_len = 1; break;
                            case 'z': result = 1 / Math.Tan(num * Math.PI / 180); word_len = 1; break;
                            default: break;
                        }
                        E = (E.Remove(i - word_len, j - i + word_len + 2)).Insert(i - word_len, result.ToString());
                        E = TempResult(E);
                        isFunction = true;                      // some function is used
                        break;
                    }
                }
            }
        }
        return E;                                               // returns the result from this function
    }
    public static string BasicArithmeticOperations(string E, char symbol)
    {
        for (int i = 0; i < E.Length; i++)
        {
            if (E[i] == symbol)                                 // looking for position of *, /, + or -
            {
                bool available1, available2;
                int before, after;
                double num1 = SearchNumber(E, i, out available1, out before, 0, i);
                double num2 = SearchNumber(E, i, out available2, out after, i + 1, E.Length);

                double result = 0;
                switch (symbol)
                {
                    case '*': result = num1 * num2; break;
                    case '/': result = num1 / num2; break;
                    case '+': result = num1 + num2; break;
                    case '-': result = num1 - num2; break;
                    default: break;
                }

                /* calculates the expression from *, /, + or - operators */
                if (available1 && available2)
                {
                    string sign = "";
                    sign = result > 0 || result.ToString().Contains("NaN") ? "+" + result.ToString() : result.ToString();
                    E = (E.Remove(before, E.Length + i - after - before + 1)).Insert(before, sign);
                    i = 0;
                    E = TempResult(E);
                }
            }
        }
        return E;                                               // returns the result from calculations
    }
    public static double SearchNumber(string E, int i, out bool available, out int limit, int start, int end)
    {
        available = false;                                      // is there some number
        double num = 0;                                         // the value of the number
        limit = 0;                                              // the length of the number
        for (limit = start; limit < end; limit++)
        {
            int k = start == 0 ? limit : start;

            if (double.TryParse(E.Substring(k, end - limit), out num))
            {
                available = true;                               // if the number is found
                if (E[i] == '+' || E[i] == '-')                 // checks the priority of '*' and '/'
                {
                    if (i - (end - limit + 1) >= 0 && start < i)
                    {
                        if (E[i - (end - limit + 1)] == '*' || E[i - (end - limit + 1)] == '/')
                        {
                            available = false;                  // this number will not be used
                        }
                    }
                    if (i + (end - limit) + 1 < E.Length && start > i)
                    {
                        if (E[i + (end - limit) + 1] == '*' || E[i + (end - limit) + 1] == '/')
                        {
                            available = false;                  // this number will not be used
                        }
                    }
                }
                break;
            }
        }
        return num;                                             // returns the value of the number
    }
    public static string TempResult(string E)
    {
        E = E.Replace("-+", "-");
        Thread.Sleep(500);                                      // sleep for a half second
        Console.WriteLine(" x = {0}", E.Replace('_', ',').Replace("v", "sin").Replace("x", "cos").Replace("y", "tan").Replace("z", "cot"));
        return E;
    }
}