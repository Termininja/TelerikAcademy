//Task13: Write a program that reverses the words in given sentence. Example:
//        "C# is not C++, not PHP and not Delphi!" → "Delphi not and PHP, not C++ not is C#!".

using System;

class ReverseWords
{
    static void Main()
    {
        // Reads some text
        Console.WriteLine("Please, enter some sentence:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string t = Console.ReadLine();
        Console.ResetColor();

        // List of special signs
        string[] Signs = { ",", ".", ":", "!", "?", ";" };

        foreach (var item in Signs)
        {
            t = t.Replace(item, " " + item);
        }

        // The splitted text with signs
        string[] text = t.Trim().Split(' ');

        // Removes all signs from the text
        string w = t;
        foreach (var item in Signs)
        {
            w = w.Replace(item, "");
        }

        // The splitted text without any signs
        string[] words = w.Replace("  ", " ").Trim().Split(' ');

        // Reverses the list of words
        Array.Reverse(words);

        // List of the reverses words with signs
        string[] result = new string[text.Length];

        int k = 0;
        for (int i = 0; i < text.Length; i++)
        {
            // Import any sign in the result list
            bool sign = false;
            foreach (var sym in Signs)
            {
                if (sym == text[i])
                {
                    result[i] = text[i];
                    k++;
                    sign = true;
                    break;
                }
            }

            // Imports the reversed words in the result list
            if (!sign) result[i] = words[i - k];
        }
        Console.WriteLine("\nThe result is:");
        for (int i = 0; i < result.Length; i++)
        {
            // Prints the result list
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result[i]);
            Console.ResetColor();

            // Put space between words in the sentence
            if (i < result.Length - 1)
            {
                bool space = false;
                foreach (var item in Signs)
                {
                    if (result[i + 1] == item)
                    {
                        space = true;
                        break;
                    }
                }
                if (!space)
                {
                    // Write a space
                    Console.Write(" ");
                    space = false;
                }
            }
        }
        Console.WriteLine();
    }
}