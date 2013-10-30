//11. Write a program that finds the index of given element in a sorted array
//    of integers by using the binary search algorithm (find it in Wikipedia).

using System;

class Binary_Search
{
    static void Main()
    {
        int[] array = { 0, 1, 2, 3, 3, 5, 9, 12, 27, 28, 45, 93, 98 };  // the given sorted array
        int N = 12;                                                     // the given element

        int min = 0;
        int max = array.Length - 1;
        while (max > min)
        {
            int mid = (min + max) / 2;
            if (N <= array[mid])
            {
                max = mid;
            }
            else
            {
                min = mid + 1;                                          // the index of the given element N
            }
            if (min == max && array[min] == N)                          // prints the result
            {
                Console.WriteLine("The number {0} is on position {1}", N, min);
            }
            else if (min == max)
            {
                Console.WriteLine("The number {0} is missing in this array", N);
            }
        }
    }
}