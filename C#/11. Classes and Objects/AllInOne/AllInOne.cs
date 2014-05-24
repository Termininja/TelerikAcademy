using System;
using System.Threading;

class AllTasks
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        InOut("Welcome!");
        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Contents();
            ConsoleKeyInfo key = Console.ReadKey();
            Console.CursorVisible = true;
            while (true)
            {
                Console.Clear();
                try
                {
                    if (key.Key == ConsoleKey.D1) LeapYear.Main();
                    else if (key.Key == ConsoleKey.D2) RandomValues.Main();
                    else if (key.Key == ConsoleKey.D3) DayOfTheWeek.Main();
                    else if (key.Key == ConsoleKey.D4) TriangleSurface.Main();
                    else if (key.Key == ConsoleKey.D5) Workdays.Main();
                    else if (key.Key == ConsoleKey.D6) SumFromString.Main();
                    else if (key.Key == ConsoleKey.D7) ArithmeticalExpression.Main();
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        InOut("Goodbye!");
                        Environment.Exit(0);
                    }
                    else break;

                    TextButton("\n\nThis was the end of the program.\nPress ", "Enter");
                    TextButton(" to try again or ", "Esc");
                    TextButton(" to go to Main Menu . . .", null);

                    ConsoleKeyInfo k = Console.ReadKey();
                    while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape)
                    {
                        Console.Write("\b \b");
                        k = Console.ReadKey();
                    }
                    if (k.Key == ConsoleKey.Escape) break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n\nYou made something wrong!\nPress any key to try again . . .");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }

    static void Contents()
    {
        TextButton("\n\n   Homework 5. Classes and Objects\n", null);
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
        Console.ResetColor();
        TextButton("   Please, select a task number from ", "1");
        TextButton(" to ", "7");
        TextButton(" or press ", "ESC");
        TextButton(" to exit... ", null);
    }

    private static void TextButton(string text, string key)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(text);
        if (key != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
        }
        Console.ResetColor();
    }

    static void InOut(string text)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(47, 10);
        Console.Write(text);
        Thread.Sleep(2000);
    }
}