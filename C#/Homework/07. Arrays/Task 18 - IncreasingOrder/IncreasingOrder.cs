//18. * Write a program that reads an array of integers and removes from it a minimal number of elements
//      in such way that the remaining array is sorted in increasing order. Print the remaining sorted array.
//      Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} → {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

class IncreasingOrder
{
    static void Main()
    {
        int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        List<int> Result = new List<int>();             

        for (int i = 0; i < Math.Pow(2, array.Length); i++)
        {
            List<int> temp = new List<int>();
            string str = String.Empty;
            for (int b = 0; b < array.Length; b++)      // for each bit in the number 'i'
            {
                str = Convert.ToString(i, 2).PadLeft(array.Length, '0');
                if (str[b] == '1')                      // if the bit is equqal to 1
                {
                    temp.Add(array[b]);
                }
            }

            if (IsSorted(temp))                         // if the current temp array is sorted
            {
                if (temp.Count >= Result.Count)         // if the length is larger than previous temp array
                {
                    Result = temp;
                }
            }
        }
        foreach (var item in Result)                    // prints the result
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    /* Checks whether some array is sorted */
    static bool IsSorted(List<int> temp)
    {
        bool sorted = false;
        for (int j = 1; j < temp.Count; j++)
        {
            if (temp[j] >= temp[j - 1])
            {
                sorted = true;
            }
            else
            {
                sorted = false;
                break;
            }
        }
        return sorted;
    }
}