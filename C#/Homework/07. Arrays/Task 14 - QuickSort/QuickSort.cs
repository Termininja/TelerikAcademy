// Task 14. Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class Quick_Sort
{
    static void Main()
    {
        int[] array = { 1, -7, 8, -5, 4, -3, 9 };       // some given array

        foreach (var item in QuickSort(array))          // prints the result from quick sorting
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static int[] QuickSort(int[] arr)
    {
        if (arr.Length <= 1)                            // if the array is from only 1 element
        {
            return arr;
        }
        int pivot = arr[0];                             // we choose the 1st element from array for pivot
        List<int> Left = new List<int>();
        List<int> Right = new List<int>();

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > pivot) Right.Add(arr[i]);      // all elements which are larger than pivot
            else Left.Add(arr[i]);                      // all elements which are smaller than pivot
        }

        int[] L = QuickSort(Left.ToArray());            // repeats the quick sorting for left array
        int[] R = QuickSort(Right.ToArray());           // repeats the quick sorting for right array

        for (int l = 0; l < L.Length; l++)              // adds the left array in result
        {
            arr[l] = L[l];
        }
        arr[L.Length] = pivot;                          // adds the pivot in result
        for (int r = L.Length + 1; r < arr.Length; r++) // adds the right array in result
        {
            arr[r] = R[r - (L.Length + 1)];
        }
        return arr;
    }
}