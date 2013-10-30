//2. Write a program that reads two arrays from the console and compares them element by element.

using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter the number of elements in arrays: ");

        int[] arr1 = new int[int.Parse(Console.ReadLine())];       
        int[] arr2 = new int[arr1.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = int.Parse(Console.ReadLine());        // reads element from the 1st array
            arr2[i] = int.Parse(Console.ReadLine());        // reads element from the 2nd array

            switch (arr1[i].CompareTo(arr2[i]))             // compares the both arrays
            {
                case 1: Console.WriteLine(">"); break;
                case -1: Console.WriteLine("<"); break;
                case 0: Console.WriteLine("="); break;
            }
        }
    }
}