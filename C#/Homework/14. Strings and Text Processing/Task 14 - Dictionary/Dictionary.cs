//Task14: A dictionary is stored as a sequence of text lines containing words and their explanations.
//        Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
//              ".NET – platform for applications from Microsoft
//              CLR – managed execution environment for .NET
//              namespace – hierarchical organization of classes"

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {
        try
        {
            Dictionary<string, string> D = new Dictionary<string, string>();    // creates a new dictionary

            //put some words and their explanations in the dictionary
            D[".NET"] = "platform for applications from Microsoft";
            D["CLR"] = "managed execution environment for .NET";
            D["namespace"] = "hierarchial organization of classes";

            Console.Write("Please, enter some word: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string word = Console.ReadLine();               // reads some word
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} - {1}", word, D[word]);  // prints the result for the word from the dictionary
            Console.ResetColor();
        }
        catch (System.Collections.Generic.KeyNotFoundException)     // if the word is missing in the dictionary
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The word is not found!");            // prints some error message
            Console.ResetColor();
        }
    }
}