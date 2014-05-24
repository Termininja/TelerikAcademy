// Task 5: You are given an array of strings. Write a method that sorts the array
//         by the length of its elements (the number of characters composing them).

using System;
using System.Linq;

class SortByLength
{
    static void Main()
    {
        // Some given array of strings
        string[] strings = new string[] { "shark", "elephant", "ball", "tower", "run", "point" };

        Console.WriteLine("The given array of strings:");
        foreach (var element in strings) Console.Write(element + " ");
        Console.WriteLine("\n");

        // First variant: sorting by loop
        Console.WriteLine("Variant 1: Sorting by loop:\n");
        Sort(strings);
        foreach (var item in strings) Console.WriteLine(item);

        // Second variant: sorting by LINQ
        Console.WriteLine("\nVariant 2: Sorting by LINQ:\n");
        var sorted = from n in strings orderby n.Length ascending select n;
        foreach (var item in sorted) Console.WriteLine(item);

        // Third variant: sorting by Lambda
        Console.WriteLine("\nVariant 3: Sorting by Lambda:\n");
        foreach (var item in strings.OrderBy(m => m.Length)) Console.WriteLine(item);
        Console.WriteLine();
    }

    // Sort some array of strings
    private static void Sort(string[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            // Compare each two elements in the array
            if (arr[i].Length < arr[i - 1].Length)
            {
                // Keep the value of the first element
                string temp = arr[i - 1];

                // Swap the elements
                arr[i - 1] = arr[i];
                arr[i] = temp;

                // Reset the loop
                i = 0;
            }
        }
    }
}