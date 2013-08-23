//Task 9: We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 → 1+1-2=0.

using System;
using System.Collections.Generic;

class CheckSumOfNumbers
{
    static List<int> NumbersList = new List<int>();                         // List for the numbers
    static List<int> TempList = new List<int>();                            // Temporary list for each one subset of 'NumbersList'

    static void Main()
    {
        Console.Write("Please, enter how many numbers you want to use: ");
        int limit = int.Parse(Console.ReadLine());                          // the limit of the numbers in 'NumbersList'
        for (int i = 1; i <= limit; i++)
        {
            Console.Write("Enter some integer number: n{0} = ", i);
            NumbersList.Add(int.Parse(Console.ReadLine()));                 // each one number is added in the list
        }
        for (int j = 0; j < Math.Pow(2, limit); j++)                        // checks each one combination of the numbers
        {
            int Sum = 0;                                                    // the sum of the numbers in the list
            bool CheckTheSum = false;                                       // variable which help us to check or not the sum
            for (int i = 0; i < limit; i++)                                  
            {
                if ((j & (1 << i)) >> i == 1)                               // we use binary mode to find the numbers in the list
                {
                    TempList.Add(NumbersList[i]);                           // each one number is added in 'TempList'
                    Sum += NumbersList[i];                                  // the sum of the numbers in 'TempList'
                    CheckTheSum = true;                                     // this sum has to be checked
                }
            }
            if (Sum == 0 & CheckTheSum)                                     // checks whether the sum in 'TempList' is 0
            {
                Console.Write("\nThe sum of {");
                foreach (int temp in TempList)                              // prints all numbers from 'TempList'
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(temp);
                    Console.ResetColor();
                    Console.Write(",");
                }
                Console.Write("\b} is 0.");
            }
            TempList.Clear();                                               // clears all numbers in 'TempList'
        }
        Console.WriteLine();
    }
}