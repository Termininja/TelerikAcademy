//Task22: Write a program that reads a string from the console and lists all different words
//        in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class DifferentWords
{
    static void Main()
    {
        // Reads some text
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        // Creates empty Dictionary
        Dictionary<string, int> D = new Dictionary<string, int>();

        // For each one word in the text
        foreach (var word in Regex.Matches(text, @"\w+"))
        {
            // If the word is in the Dictionary
            if (D.ContainsKey(word.ToString())) D[word.ToString()] += 1;
            else D.Add(word.ToString(), 1);
        }

        Console.WriteLine();
        foreach (var w in D)
        {
            // Prints the words from the Dictionary
            Console.Write("{0,15}: ", w.Key);

            // Prints how many times each word is found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(w.Value);
            Console.ResetColor();
        }
    }
}