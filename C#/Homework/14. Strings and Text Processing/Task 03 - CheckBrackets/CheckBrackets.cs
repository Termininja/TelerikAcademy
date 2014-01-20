//Task3: Write a program to check if in a given expression the brackets are put correctly.
//       Example of correct expression: ((a+b)/5-d).
//       Example of incorrect expression: )(a+b)).

using System;

class CheckBrackets
{
    static void Main()
    {
        // Reads some expression and put it in array
        Console.Write("Please, write some expression: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        char[] expression = Console.ReadLine().ToCharArray();
        Console.ResetColor();

        bool correct = true;
        int count = 0;

        // Checks the brackets
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(') count++;
            if (expression[i] == ')') count--;

            // If some bracket is closed before to be opened
            if (count < 0)
            {
                correct = false;
                break;
            }
        }
        if (correct && count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe brackets are put correctly!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe brackets are not put correctly!");
        }
        Console.ResetColor();
    }
}