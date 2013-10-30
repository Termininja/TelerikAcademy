//16. * We are given an array of integers and a number S.
//      Write a program to find if there exists a subset of the elements of the array that has a sum S.
//      Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 → yes (1+2+5+6)

using System;

class FindElementsBySum
{
    static void Main()
    {
        int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };       // the given array
        int S = 14;                                     // the given number

        for (int i = 0; i < Math.Pow(2, array.Length); i++)
        {
            int currentSum = 0;
            string str = String.Empty;
            for (int b = 0; b < array.Length; b++)      // for each bit in the number 'i'
            {
                str = Convert.ToString(i, 2).PadLeft(array.Length, '0');
                if (str[b] == '1')                      // if the bit is equqal to 1
                {
                    currentSum += array[b];
                }
            }
            if (S == currentSum)                        // is the current sum equal to S
            {
                int cSum = 0;
                Console.Write("yes (");                 // prints the result
                for (int k = 0; k < array.Length; k++)
                {
                    if (str[k] == '1')
                    {
                        cSum += array[k];
                        Console.Write(array[k]);        // all numbers in the sum
                        if (S != cSum)
                        {
                            Console.Write("+");
                        }
                    }
                }
                Console.WriteLine(")");
            }
        }
    }
}