// Task 10. Write a program that finds in given array of integers a sequence of given sum S (if present).
//          Example: {4, 3, 1, 4, 2, 5, 8}, S=11 → {4, 2, 5}

using System;

class SequenceOfSum
{
    static void Main()
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };          // the given array
        int S = 11;                                     // the given sum

        for (int i = 0; i < array.Length; i++)
        {
            int SumChecked = 0;
            for (int j = i; j < array.Length; j++)
            {
                SumChecked += array[j];
                if (SumChecked == S)                    // if the current sum is equal to S
                {
                    // Prints the result
                    Console.Write("{");
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(array[k]);
                        if (k < j) Console.Write(", ");
                    }
                    Console.WriteLine("}");
                }
            }
        }
    }
}