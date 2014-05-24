//Task11. Write a program that deletes from a text file all words that start with the prefix "test".
//        Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeleteWordsFromFile
{
    static void Main()
    {
        StringBuilder contents = new StringBuilder();
        StringBuilder result = new StringBuilder();

        // Reads some text file
        StreamReader read = new StreamReader("file.txt");
        using (read) contents.Append(read.ReadToEnd());

        // Deletes all words starting with the prefix "test"
        result.Append(Regex.Replace(contents.ToString(), @" (test\w*)", String.Empty));

        // Prints the result
        Console.WriteLine("Input text:\n" + contents);
        Console.WriteLine("\nOutput text:\n" + result);
    }
}