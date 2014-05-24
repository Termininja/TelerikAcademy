// Task 8. Write a program that finds the sequence of maximal sum in given array.
//         Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} → {2, -1, 6, 4}
//	       Can you do it with only one loop (with single scan through the elements of the array)?

using System;

class SequenceOfMaxSum
{
    static void Main()
    {
        // The given array
        int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int maxSum = array[0];
        int maxLength = 1;
        int maxIndex = 0;
        for (int i = 1, curSum = array[0], curIndex = 0; i < array.Length; i++)
        {
            curSum += array[i];

            if (curSum > maxSum)
            {
                maxSum = curSum;
                maxIndex = curIndex;
                maxLength = i - curIndex + 1;
            }
            if (curSum < array[i])
            {
                curSum = array[i];
                curIndex = i;
            }
        }

        // Print the result
        for (int i = 0; i < maxLength; i++) Console.WriteLine(array[maxIndex + i]);
    }
}