// Task 8: Write a method that adds two positive integer numbers represented as arrays of digits
//         (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//         Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Numerics;

class ArrayOfDigits
{
    static void Main()
    {
        // Reads some array and reverse it
        Console.Write("Please, enter the 1st number: ");
        char[] array1 = Console.ReadLine().ToCharArray();
        Array.Reverse(array1);

        // Reads a second array and reverse it
        Console.Write("Please, enter the 2nd number: ");
        char[] array2 = Console.ReadLine().ToCharArray();
        Array.Reverse(array2);

        // Print the result from the sum of both arrays
        string FinalResult = Sum(array1, array2);
        Console.Write("The sum from reversed numbers is: ");
        Console.WriteLine(FinalResult);
    }

    // Adds two arrays
    static string Sum(char[] arr1, char[] arr2)
    {
        // Makes the 1st array to be longer
        if (arr2.Length > arr1.Length)
        {
            char[] temp = (char[])arr1.Clone();
            arr1 = (char[])arr2.Clone();
            arr2 = (char[])temp.Clone();
        }

        // the difference between the length of both arrays
        int d = arr1.Length - arr2.Length;

        int?[] result = new int?[arr1.Length + 1];

        int byMind = 0;
        int sum = 0;
        for (int i = arr1.Length - 1; i >= 0; i--)
        {
            if (i - d >= 0) sum = int.Parse(arr1[i].ToString()) + int.Parse(arr2[i - d].ToString()) + byMind;
            else sum = int.Parse(arr1[i].ToString()) + byMind;

            if (sum > 9)
            {
                byMind = 1;
                sum = sum % 10;
            }
            else byMind = 0;

            result[i + 1] = sum;
        }
        if (byMind == 1) result[0] = 1;

        string FinalResult = String.Empty;
        for (int j = 0; j < result.Length; j++)
        {
            FinalResult += result[j];
        }

        return FinalResult;
    }
}