// Task 17. * Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
//            Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;

class SubsetSum
{
    static void Main()
    {
        Console.Write("Please, enter the N = ");
        int N = int.Parse(Console.ReadLine());          // reads the N
        Console.Write("Please, enter the K = ");
        int K = int.Parse(Console.ReadLine());          // reads the K
        Console.Write("Please, enter the S = ");
        int S = int.Parse(Console.ReadLine());          // reads the S

        int[] array = new int[N];
        for (int i = 0; i < N; i++)                     // reads all elements in array
        {
            Console.Write("Array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < Math.Pow(2, array.Length); i++)
        {
            int currentSum = 0;
            int Kmax = 0;
            string str = String.Empty;
            for (int b = 0; b < array.Length; b++)      // for each bit in the number 'i'
            {
                str = Convert.ToString(i, 2).PadLeft(array.Length, '0');
                if (str[b] == '1')                      // if the bit is equqal to 1
                {
                    currentSum += array[b];
                    Kmax++;
                }
            }
            if (S == currentSum && Kmax == K)           // is the current sum equal to S
            {
                // Prints the result
                int cSum = 0;
                for (int k = 0; k < array.Length; k++)
                {
                    if (str[k] == '1')
                    {
                        cSum += array[k];
                        Console.Write(array[k]);        // all numbers in the sum
                        if (S != cSum) Console.Write("+");
                    }
                }
                Console.WriteLine(" = " + S);
            }
        }
    }
}