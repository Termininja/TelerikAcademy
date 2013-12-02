using System;
using System.Threading;

class AllInOne
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        InOut("Welcome!");
        while (true)
        {
            Console.Clear();
            Contents();

            Console.ForegroundColor = ConsoleColor.Cyan;
            string task = Console.ReadLine();
            bool end = false;
            while (!end)
            {
                try
                {
                    Console.Clear();
                    switch (task)
                    {
                        case "1": PrintsANumbers.Main(); break;
                        case "2": PrintsSpecialNumbers.Main(); break;
                        case "3": MinAndMaxOfSequence.Main(); break;
                        case "4": FactorialDivision.Main(); break;
                        case "5": FactorialDivision2.Main(); break;
                        case "6": SumOfSequence.Main(); break;
                        case "7": SequenceOfFibonacci.Main(); break;
                        case "8": GreatestCommonDivisor.Main(); break;
                        case "9": CatalanNumbers.Main(); break;
                        case "10": CatalanNumbers.Main(); break;
                        case "11": CardNames.Main(); break;
                        case "12": MatrixOfNumbers.Main(); break;
                        case "13": CountsAZeros.Main(); break;
                        case "14": SpiralMatrix.Main(); break;
                        case "exit": InOut("Goodbye!"); Environment.Exit(0); break;
                        default: end = true; continue;
                    }

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
        TextButton("\n\n   Homework 6. Loops\n", null);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Write a program that prints all the numbers from 1 to N.
      Task 2: Write a program that prints all the numbers from 1 to N, that are not divisible
              by 3 and 7 at the same time.
      Task 3: Write a program that reads from the console a sequence of N integer numbers and
              returns the minimal and maximal of them.
      Task 4: Write a program that calculates N!/K! for given N and K (1 < K < N).
      Task 5: Write a program that calculates N!*K! / (K-N)! for given N and K (1 < N < K).
      Task 6: Write a program that, for a given 2 integer numbers N and X, calculates the sum
              S = 1 + 1!/X + 2!/X^2 + … + N!/X^N
      Task 7: Write a program that reads a number N and calculates the sum of first N members
              of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...
      Task 8: Write a program that calculates the greatest common divisor of given 2 numbers.
              Use the Euclidean algorithm (find it in Internet).
      Task 9: The same like task 10: The Catalan numbers are calculated by the next formula:
              Cn = (2n)! / (n+1)! n!, for n >= 0. Write a program that calculate N-th Catalan
              number by given N.
     Task 11: Write a program that prints all possible cards from a standard deck of 52 cards
              with their English names. Use nested for loops and switch-case.
     Task 12: Write a program that reads from the console a positive integer number N < 20
              and outputs a matrix like:              N = 3 →  1 2 3             
                                                               2 3 4             
                                                               3 4 5             
     Task 13: Write a program that calculates for number N how many trailing 0 present at the
              end of the N! Example: N=10→N!=3628800→2; Does your program work for N = 50000?
              Hint: The trailing 0 in N! are equal to the number of its prime divisors of 5.
     Task 14: Write a program that reads a positive integer number N (N < 20) from console
              and outputs in the console the numbers 1,N numbers arranged as a spiral.
                         ");
        Console.ResetColor();
        TextButton("   Please, enter a task number from 1 to 14 or type \"exit\" to exit: ", null);
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
        Console.ResetColor();
        Console.SetCursorPosition(47, 10);
        Console.Write(text);
        Console.SetCursorPosition(99, 33);
        Thread.Sleep(2000);
    }
}