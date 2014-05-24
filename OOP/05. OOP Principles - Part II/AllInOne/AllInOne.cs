using System;
using System.Threading;

class AllTasks
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        Console.WindowHeight = 34;
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
                    if (key.Key == ConsoleKey.D1) Shapes.Program.Main();
                    else if (key.Key == ConsoleKey.D2) Bank.Program.Main();
                    else if (key.Key == ConsoleKey.D3) Exceptions.Program.Main();
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
        TextButton("\n\n   Homework 4. OOP Principles - Part I\n", null);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Define abstract class Shape  with only  one abstract method CalculateSurface() and
              fields width and height. Add two new classes Triangle and Rectangle that implement
              the virtual method  and return the surface of the figure. Define class  Circle and
              suitable constructor so that at initialization height must be kept equal to  width
              and implement  the CalculateSurface()  method. Write a  program to  tests the last
              method for different shapes (Circle, Rectangle, Triangle) stored in an array.

      Task 2: A bank holds different types of accounts for its customers: deposit accounts, loan
              accounts  and mortgage accounts. Customers could be  individuals or companies. All
              accounts have customer, balance and interest  rate. Deposit  accounts are  allowed
              to deposit and with draw money. Loan and mortgage accounts can only deposit money.
              All  accounts can calculate their interest amount for a  given period (in months).
              Loan accounts  have no interest for the first 3 months if are held by  individuals
              and for  the first  2 months  if are held  by a company. Deposit accounts  have no
              interest if their balance  is positive  and less than 1000. Mortgage accounts have
              half interest for  the first 12 months for companies and no interest for the first
              6 months for individuals. You have to write a  program to model the bank system by
              classes and interfaces. You should identify the  classes, interfaces, base classes
              and abstract  actions and implement the  calculation of the interest functionality
              through overridden methods.

      Task 3: Define a class InvalidRangeException<T> that holds information about an related to
              invalid  range. It should hold error message and a range definition [start … end].
              Write  a sample application  that demonstrates  the InvalidRangeException<int> and
              InvalidRangeException<DateTime>  by  entering numbers in the range → [1 … 100] and
              dates in the range → [1.1.1980 … 31.12.2013].
                         ");
        Console.ResetColor();
        TextButton("   Please, select a task number from ", "1");
        TextButton(" to ", "3");
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