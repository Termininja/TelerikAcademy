// Task 4: Write a program, that reads from the console an array of N integers
//         and an integer K, sorts the array and using the method Array.BinSearch()
//         finds the largest number in the array which is ≤ K. 

using System;

class BinSearch
{
    static void Main()
    {
        // Creates some array
        Console.Write("Please, enter the number of elements in array: ");
        int[] array = new int[int.Parse(Console.ReadLine())];

        // Fill the array with numbers
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" arr[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Reads some integer number K
        Console.Write("\nPlease, enter some integer number: K = ");
        int K = int.Parse(Console.ReadLine());

        // Sorts the array
        System.Array.Sort(array);

        // Prints the result from Array.BinSearch()
        dynamic largest = Array.BinSearch(array, K);
        Console.Write("\nThe largest number in the array which is <= K is: ");
        Console.WriteLine(largest ?? "There isn't such number!");
    }
}

class Array
{
    public static int? BinSearch(int[] arr, int k)
    {
        int? l = int.MinValue;

        // Find the largest number in array which is ≤ k
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] <= k) l = arr[i];
            else break;
        }

        // Returns the largest number
        return (l == int.MinValue) ? null : l;
    }
}