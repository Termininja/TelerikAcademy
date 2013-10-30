//13. * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

using System;

class Merge_Sort
{
    static void Main()
    {
        int[] array = { -1, 2, -3, 4, -5, 6, -7, 8, -9 };   // some unsorted array

        foreach (var item in SplitArray(array))             // prints the sorted array
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static int[] SplitArray(int[] arr)
    {
        if (arr.Length == 1)                                // returns the array if the length is 1
        {
            return arr;
        }

        int middle = arr.Length / 2;                        // the middle of array

        /* The left part of array */
        int[] Left = new int[middle];
        for (int i = 0; i < middle; i++)
        {
            Left[i] = arr[i];
        }

        /* The right part of array */
        int[] Right = new int[arr.Length - middle];
        for (int i = middle, j = 0; i < arr.Length; i++, j++)
        {
            Right[j] = arr[i];
        }

        Left = SplitArray(Left);
        Right = SplitArray(Right);

        return Merge(Left, Right);                          // merge the left and right array
    }
    static int[] Merge(int[] left, int[] right)
    {
        int leftIncrease = 0;
        int rightIncrease = 0;
        int[] arr = new int[left.Length + right.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (rightIncrease == right.Length || ((leftIncrease < left.Length) && (left[leftIncrease] <= right[rightIncrease])))
            {
                arr[i] = left[leftIncrease];
                leftIncrease++;
            }
            else if (leftIncrease == left.Length || ((rightIncrease < right.Length) && (left[leftIncrease] >= right[rightIncrease])))
            {
                arr[i] = right[rightIncrease];
                rightIncrease++;
            }
        }
        return arr;
    }
}