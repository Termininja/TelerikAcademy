using System;
using System.Threading;

class AllTasks
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        InOut("Welcome!");
        Console.CursorVisible = true;
        while (true)
        {
            Console.Clear();
            Contents();
            ConsoleKeyInfo key = Console.ReadKey();
            while (true)
            {
                Console.Clear();
                try
                {
                    if (key.Key == ConsoleKey.D1) Program.Main();
                    else if (key.Key == ConsoleKey.D2) IEnumerableExtension.Main();
                    else if (key.Key == ConsoleKey.D3) Students.Program.Main();
                    else if (key.Key == ConsoleKey.D4) Students.Program.Main();
                    else if (key.Key == ConsoleKey.D5) Students.Program.Main();
                    else if (key.Key == ConsoleKey.D6) IntegerNumbers.Program.Main();
                    else if (key.Key == ConsoleKey.D7) Timer.Program.Main();
                    else if (key.Key == ConsoleKey.D8) Events.Program.Main();
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        InOut("Goodbye!");
                        Environment.Exit(0);
                    }
                    else break;

                    Console.CursorVisible = true;
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

    // All homework problems
    static void Contents()
    {
        TextButton("\n\n   Homework 3. Extension Methods, Delegates, Lambda and LINQ\n", null);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Implement an extension method  Substring(int index, int length)  for the  class
              StringBuilder that returns new  StringBuilder and has the same functionality as
              Substring in the class String.
      Task 2: Implement  a set of  extension  methods for  IEnumerable<T>  that implement the
              following group functions: sum, product, min, max, average.
      Task 3: Write a method  that from a given  array of students  finds all students  whose
              first name is before its last name alphabetically. Use LINQ query operators.
      Task 4: Write a LINQ query that finds the first name and last name of all students with
              age between 18 and 24.
      Task 5: Using the extension methods OrderBy() and ThenBy() with lambda expressions sort
              the students by first name and last name in descending order.  Rewrite the same
              with LINQ.
      Task 6: Write  a program  that prints  from given array  of integers  all numbers  that
              are  divisible  by 7 and 3.  Use the  built-in  extension  methods  and  lambda
              expressions. Rewrite the same with LINQ.
      Task 7: Using delegates write a class Timer that has can execute certain method at each
              t seconds.
      Task 8: Read in MSDN about the keyword event in C# and how to publish events.
              Re-implement the above using .NET events and following the best practices.
                         ");
        Console.ResetColor();
        TextButton("\n   Please, select a task number from ", "1");
        TextButton(" to ", "8");
        TextButton(" or press ", "ESC");
        TextButton(" to exit... ", null);
    }

    // Print some button
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

    // Welcome and Goodbye screen
    static void InOut(string text)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(47, 10);
        Console.Write(text);
        Thread.Sleep(2000);
    }
}