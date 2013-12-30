// Task 7. Sorting an array means to arrange its elements in increasing order.
//         Write a program to sort an array. Use the "selection sort" algorithm:
//         Find the smallest element, move it at the first position,
//         find the smallest from the rest, move it at the second position, etc.

using System;

class SortingArray
{
    static void Main()
    {
        Console.Write("Enter the number of elements in arrays: ");
        int[] array = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int I = 0; I < array.Length; I++)
        {
            int min = int.MaxValue;
            int num = 0;
            for (int i = I; i < array.Length; i++)  // looks for min value in array
            {
                if (array[i] <= min)
                {
                    min = array[i];                 // this is the min element
                    num = i;                        // we keep the number of min element
                }
            }
            int temp = array[I];                    // moves the value of current element in temp
            array[I] = array[num];                  // moves the value of min in current element
            array[num] = temp;                      // moves the current element on the free place from min element
        }

        // Prints the sorted array
        foreach (var item in array) Console.Write(item + " ");
    }
}