// Task 11. Write a program that finds the index of given element in a sorted array
//          of integers by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearch
{
    static void Main()
    {
        int[] array = { 0, 1, 2, 3, 3, 5, 9, 12, 27, 28, 45, 93, 98 };  // the given sorted array
        int N = 12;                                                     // the given element

        int min = 0;
        int max = array.Length - 1;

        Console.Write("The number {0} is ", N);
        while (max > min)
        {
            int mid = (min + max) / 2;
            if (N <= array[mid]) max = mid;
            else min = mid + 1;                                          // the index of the given element N

            // Print the result
            if (min == max && array[min] == N) Console.WriteLine("on position {0}", min);
            else if (min == max) Console.WriteLine("missing in this array");
        }
    }
}