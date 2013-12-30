// Task 2. Write a program that reads two arrays from the
//         console and compares them element by element.

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
            // Reads element from the 1st array
            Console.Write("arr1[{0}] = ", i);
            arr1[i] = int.Parse(Console.ReadLine());

            // Reads element from the 2nd array
            Console.Write("arr2[{0}] = ", i);
            arr2[i] = int.Parse(Console.ReadLine());

            // Compares the both arrays
            char sign = ' ';
            switch (arr1[i].CompareTo(arr2[i]))
            {
                case 1: sign = '>'; break;
                case -1: sign = '<'; break;
                case 0: sign = '='; break;
            }

            // Print the result
            Console.WriteLine("arr1[{0}] {1} arr2[{0}]\n", i, sign);
        }
    }
}