//Task3: Write a program to check if in a given expression the brackets are put correctly.
//       Example of correct expression: ((a+b)/5-d).
//       Example of incorrect expression: )(a+b)).

using System;

class CheckBrackets
{
    static void Main()
    {
        Console.Write("Please, write some expression: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        char[] expression = Console.ReadLine().ToCharArray();   // reads some expression and put it in array
        Console.ResetColor();

        bool correct = true;                                    // if the brackets are put correctly
        int count = 0;                                          // the number of not closed open-brackets
        for (int i = 0; i < expression.Length; i++)             // checks the brackets
        {
            if (expression[i] == '(')
            {
                count++;
            }
            if (expression[i] == ')')
            {
                count--;
            }
            if (count < 0)                                      // if some bracket is closed before to be opened
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