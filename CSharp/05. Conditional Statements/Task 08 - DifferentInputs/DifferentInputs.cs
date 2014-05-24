//Task 8: Write a program that, depending on the user's choice inputs int, double or
//        string variable. If the variable is integer or double, increases it with 1.
//        If the variable is string, appends "*" at its end. The program must show
//        the value of that variable as a console output. Use switch statement.

using System;

class DifferentInputs
{
    static void Main()
    {
        while (true)
        {
            // Read some key from the user
            Console.Write("Press: [I] for int, [D] for double, [S] for string or [Q] to exit. . .");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                // If the choice is "Integer"
                case ConsoleKey.I:
                    Console.Write("\b \nPlease, enter some integer number: ");
                    PrintResult(int.Parse(Console.ReadLine()) + 1);
                    break;

                // If the choice is "Double"
                case ConsoleKey.D:
                    Console.Write("\b \nPlease, enter some number: ");
                    PrintResult(double.Parse(Console.ReadLine()) + 1);
                    break;

                // If the choice is "String"
                case ConsoleKey.S:
                    Console.Write("\b \nPlease, enter some string: ");
                    PrintResult(Console.ReadLine() + "*");
                    break;

                case ConsoleKey.Q: Environment.Exit(0); break;
                default: Console.Write("\b \n"); break;
            }
        }
    }

    // Print the result from some statement
    private static void PrintResult(dynamic value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The result is: {0}", value);
        Console.ResetColor();
    }
}