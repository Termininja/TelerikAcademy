//Task21: Write a program that reads a string from the console and prints all different letters
//        in the string along with information how many times each letter is found. 

using System;
using System.Text.RegularExpressions;
using System.Threading;

class DifferentLetters
{
    static void Main()
    {
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                           // reads some text
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine("All letters in the text are:");
        int w = 0;                                                  // how many are the different letters
        for (int i = 65; i <= 122; i++)                             // for each letters (case sensitive)
        {
            int count = 0;                                          // count each one letter
            foreach (var letter in Regex.Matches(text, @"\w"))      // for each letter in the text
            {
                if (((char)i).ToString() == (letter.ToString()))
                {
                    if (count == 0)                                 // marks different word
                    {
                        w++;
                    }
                    count++;
                    Console.SetCursorPosition(2, 5 + w);            // different row for each one letter
                    Console.Write("{0}: ", letter);                 // prints the letter which is found
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(count);                       // prints how many times the letter is found
                    Console.ResetColor();
                    Thread.Sleep(200);                              // sleeps for 200ms
                }
            }

            if (i == 90)                                            // to check only the letters
            {
                i = 96;
            }
        }
    }
}