// Task 17: Write a program to return the string with maximum length from an array of strings. Use LINQ.

using System;
using System.Linq;

class ArrayOfStrings
{
    static void Main()
    {
        // Create an array of strings
        string[] array = new string[] { "cat", "house", "jumping", "chair", "blue" };

        // Print the string with maximum length
        Console.WriteLine(Max(array));
    }

    private static string Max(string[] array)
    {
        // First variant
        return Array.Find(array, m => m.Length == array.Max(n => n.Length));

        // Second variant
        return array.OrderBy(m => m.Length).Last();
    }
}