//4. Write a program that finds the maximal sequence of equal elements in an array.
//	 Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} → {2, 2, 2}.

using System;

class MaxArraySequence
{
    static void Main()
    {
        Console.Write("Enter the number of elements in array: ");
        int[] array = new int[int.Parse(Console.ReadLine())];       // reads the number of elements in array

        int count = 1;
        int max = 1;
        int num = 0;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());               // reads each one element in array

            if (i > 0 && array[i] == array[i - 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count >= max)
            {
                max = count;
                num = array[i];
            }
        }

        /* Prints the result */
        Console.Write("{");
        for (int i = 1; i <= max; i++)
        {
            Console.Write(num);
            if (i < max)
            {
                Console.Write(", ");
            }
        }
        Console.Write("}");
        Console.WriteLine();
    }
}