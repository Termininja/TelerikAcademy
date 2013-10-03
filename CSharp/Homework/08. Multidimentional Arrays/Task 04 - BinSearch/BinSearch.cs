//Task 4: Write a program, that reads from the console an array of N integers
//        and an integer K, sorts the array and using the method Array.BinSearch()
//        finds the largest number in the array which is ≤ K. 

using System;

class Array
{
    public static int? BinSearch(int[] arr, int k)                  // creates method called BinSearch
    {
        int? l = int.MinValue;

        // find the largest number in array 'arr' which is ≤ 'k'
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] <= k) l = arr[i];
            else break;                                             // stop searching (only for sorted array)
        }
        return (l == int.MinValue) ? null : l;                      // returns the largest number
    }
}

class BinSearch
{
    static void Main()
    {
        Console.Write("Please, enter the number of elements in array: ");
        int[] array = new int[int.Parse(Console.ReadLine())];       // creates some array of N elements
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" arr[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());               // fill the array with numbers
        }

        Console.Write("Please, enter some integer number: K = ");
        int K = int.Parse(Console.ReadLine());                      // reads some integer number K

        System.Array.Sort(array);                                   // sorts the array

        dynamic largest = Array.BinSearch(array, K);
        Console.Write("\nThe largest number in the array which is <= K is: ");
        Console.WriteLine(largest ?? "There isn't such number!");   // prints the result from Array.BinSearch()
    }
}