//Task24: Write a program that reads a list of words, separated
//        by spaces and prints the list in an alphabetical order.

using System;

class SortingWords
{
    static void Main()
    {
        // Imports all words in array
        Console.Write("Please, enter some list of words: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] text = Console.ReadLine().Trim().Split(' ');
        Console.ResetColor();

        // Sorts the array
        Array.Sort(text);

        Console.WriteLine("\nThe list in an alphabetical order is:");
        foreach (var word in text)
        {
            // prints all sorted words
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(word);
            Console.ResetColor();
        }
    }
}