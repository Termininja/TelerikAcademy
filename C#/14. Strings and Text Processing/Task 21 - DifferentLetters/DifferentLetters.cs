//Task21: Write a program that reads a string from the console and prints all different letters
//        in the string along with information how many times each letter is found. 

using System;
using System.Text.RegularExpressions;
using System.Threading;

class DifferentLetters
{
    static void Main()
    {
        // Reads some text
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();
        Console.WriteLine();

        // How many are the different letters
        Console.WriteLine("All letters in the text are:");
        int w = 0;

        // For each letters (case sensitive)
        for (int i = 65; i <= 122; i++)
        {
            int countLetters = 0;

            // For each letter in the text
            foreach (var letter in Regex.Matches(text, @"\w"))
            {
                if (((char)i).ToString() == (letter.ToString()))
                {
                    // Marks different word
                    if (countLetters == 0) w++;
                    countLetters++;

                    // Different row for each one letter
                    Console.SetCursorPosition(2, 5 + w);

                    // Prints the letter which is found
                    Console.Write("{0}: ", letter);

                    // Prints how many times the letter is found
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(countLetters);
                    Console.ResetColor();

                    // Sleeps for 200ms
                    Thread.Sleep(200);
                }
            }

            // Check only the letters
            if (i == 90) i = 96;
        }
    }
}