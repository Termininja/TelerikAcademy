//Task 9: We are given 5 integer numbers. Write a program that checks if the
//        sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 → 1+1-2=0.

using System;
using System.Collections.Generic;

class CheckSumOfNumbers
{
    static void Main()
    {
        // List for the numbers
        List<int> NumbersList = new List<int>();

        // Temporary list for each one subset of 'NumbersList'
        List<int> TempList = new List<int>();

        // The limit of the numbers in 'NumbersList'
        Console.Write("Please, enter how many numbers you want to use: ");
        int limit = int.Parse(Console.ReadLine());

        // Each one number is added in the list
        for (int i = 1; i <= limit; i++)
        {
            Console.Write("Enter some integer number: n{0} = ", i);
            NumbersList.Add(int.Parse(Console.ReadLine()));
        }

        // Checks each one combination of the numbers
        for (int j = 0; j < Math.Pow(2, limit); j++)
        {
            int Sum = 0;
            bool CheckTheSum = false;
            for (int i = 0; i < limit; i++)
            {
                if ((j & (1 << i)) >> i == 1)
                {
                    // Each one number is added in 'TempList'
                    TempList.Add(NumbersList[i]);

                    // The sum of the numbers in 'TempList'
                    Sum += NumbersList[i];

                    // This sum has to be checked
                    CheckTheSum = true;
                }
            }
            if (Sum == 0 & CheckTheSum)
            {
                // Prints all numbers from 'TempList'
                Console.Write("\nThe sum of {");
                foreach (int temp in TempList)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(temp);
                    Console.ResetColor();
                    Console.Write(",");
                }
                Console.Write("\b} is: 0");
            }

            // Clears all numbers in 'TempList'
            TempList.Clear();
        }
        Console.WriteLine();
    }
}