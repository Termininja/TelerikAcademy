//Task24: Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;

class SortingWords
{
    static void Main()
    {
        Console.Write("Please, enter some list of words: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] text = Console.ReadLine().Trim().Split(' ');   // imports all words in array
        Console.ResetColor();

        Array.Sort(text);                                       // sorts the array

        Console.WriteLine("\nThe list in an alphabetical order is:");
        foreach (var word in text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(word);                            // prints all sorted words
            Console.ResetColor();
        }
    }
}