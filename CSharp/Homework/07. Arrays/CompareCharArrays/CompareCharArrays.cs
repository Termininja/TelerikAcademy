//3. Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Collections.Generic;

class CompareCharArrays
{
    static void Main()
    {
        Console.Write("Enter the number of elements in arrays: ");

        char[] arr1 = new char[int.Parse(Console.ReadLine())];
        char[] arr2 = new char[arr1.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = char.Parse(Console.ReadLine());
            arr2[i] = char.Parse(Console.ReadLine());
            Console.WriteLine(arr1[i].CompareTo(arr2[i]));
        }
    }
}