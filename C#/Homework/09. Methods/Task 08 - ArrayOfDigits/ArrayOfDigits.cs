//Task 8: Write a method that adds two positive integer numbers represented as arrays of digits
//        (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//        Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Numerics;

class ArrayOfDigits
{
    static char[] array1 = new char[] { };
    static char[] array2 = new char[] { };
    static void Main()
    {
        Console.Write("Please, enter the 1st number: ");
        array1 = Console.ReadLine().ToCharArray();      // reads the 1st array
        Array.Reverse(array1);                          // reverses the array1
        Console.Write("Please, enter the 2nd number: ");
        array2 = Console.ReadLine().ToCharArray();      // reads the 2nd array
        Array.Reverse(array2);                          // reverses the array2

        string FinalResult = Sum();
        Console.Write("The sum from reversed numbers is: ");
        Console.WriteLine(FinalResult);
    }

    static string Sum()
    {
        if (array2.Length > array1.Length)              // makes the 1st array to be longer
        {
            char[] temp = (char[])array1.Clone();
            array1 = (char[])array2.Clone();
            array2 = (char[])temp.Clone();
        }
        int dif = array1.Length - array2.Length;        // difference between length of array1 and 2

        int?[] result = new int?[array1.Length + 1];

        int mind = 0;                                   // one by mind
        int sum = 0;                                    // the current sum
        for (int i = array1.Length - 1; i >= 0; i--)
        {
            if (i - dif >= 0)
            {
                sum = int.Parse(array1[i].ToString()) + int.Parse(array2[i - dif].ToString()) + mind;
            }
            else
            {
                sum = int.Parse(array1[i].ToString()) + mind;
            }
            if (sum > 9)
            {
                mind = 1;
                sum = sum % 10;
            }
            else
            {
                mind = 0;
            }
            result[i + 1] = sum;
        }
        if (mind == 1)
        {
            result[0] = 1;
        }
        string FinalResult = "";
        for (int j = 0; j < result.Length; j++)
        {
            FinalResult += result[j];
        }
        return FinalResult;
    }
}