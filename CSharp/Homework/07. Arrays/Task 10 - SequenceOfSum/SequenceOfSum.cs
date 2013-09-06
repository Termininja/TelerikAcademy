//10. Write a program that finds in given array of integers a sequence of given sum S (if present).
//    Example: {4, 3, 1, 4, 2, 5, 8}, S=11 → {4, 2, 5}

using System;

class SequenceOfSum
{
    static void Main()
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };              // the given array
        int S = 11;                                         // the given sum

        for (int i = 0; i < array.Length; i++)
        {
            int S_check = 0;
            for (int j = i; j < array.Length; j++)
            {
                S_check += array[j];
                if (S_check == S)                           // if the current sum is equal to S
                {
                    for (int k = i; k <= j; k++)            // prints the result
                    {
                        Console.WriteLine(array[k]);    
                    }
                }
            }
        }
    }
}