//Task 8: Write a program that, depending on the user's choice inputs int, double or string variable.
//        If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end.
//        The program must show the value of that variable as a console output. Use switch statement.

using System;

class DifferentInputs
{
    static void Main()
    {
    start:
        Console.WriteLine("Please, choose:\n\n   I for int\n   D for double\n   S for string");
        ConsoleKeyInfo key = Console.ReadKey();                                     // reads the user's choice
        switch (key.Key)
        {
            case ConsoleKey.I:                                                      // if the choice is "Integer"
                Console.Clear();
                Console.Write("Please, enter some integer number: ");
                int Integer = int.Parse(Console.ReadLine());
                Console.WriteLine("The result is {0}", Integer + 1);
                break;
            case ConsoleKey.D:                                                      // if the choice is "Double"
                Console.Clear();
                Console.Write("Please, enter some number: ");
                double Double = double.Parse(Console.ReadLine());
                Console.WriteLine("The result is {0}", Double + 1);
                break;
            case ConsoleKey.S:                                                      // if the choice is "String"
                Console.Clear();
                Console.Write("Please, enter some string: ");
                string String = Console.ReadLine();
                Console.WriteLine("The result is {0}", String + "*");
                break;
            default:                                                                // if the choice is wrong
                Console.Clear();                                                    // clear the screen
                goto start;                                                         // go to top and ask the user again for some input
        }
    }
}