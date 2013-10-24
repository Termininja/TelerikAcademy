//Task 5: You are given an array of strings. Write a method that sorts the array
//        by the length of its elements (the number of characters composing them).

using System;
using System.Linq;

class SortByLength
{
    static void Main()
    {
        // Given array of strings
        string[] strings = new string[] { "shark", "elephant", "ball", "tower", "run", "point" };

        // First variant: sorting by loop
        Console.WriteLine("Sorting by loop:");
        Sort(strings);
        foreach (var item in strings) Console.WriteLine(item);

        // Second variant: sorting by LINQ
        Console.WriteLine("\nSorting by LINQ:");
        var sorted = from n in strings orderby n.Length ascending select n;
        foreach (var item in sorted) Console.WriteLine(item);

        // Third variant: sorting by Lambda
        Console.WriteLine("\nSorting by Lambda:");
        foreach (var item in strings.OrderBy(m => m.Length)) Console.WriteLine(item);
    }

    private static void Sort(string[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].Length < arr[i - 1].Length)
            {
                string temp = arr[i - 1];
                arr[i - 1] = arr[i];
                arr[i] = temp;
                i = 0;
            }
        }
    }
}