//Task 4: Sort 3 real values in descending order using nested if statements.

using System;

class Sorting3Values
{
    static void Main()
    {
        int first = 0;
        int second = 0;
        int third = 0;
        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Please, enter the some real number: ");
            int number = int.Parse(Console.ReadLine());                         // for each 'i' we read one number
            if (i == 1)                                                         // if the number is only one
            {
                first = number;
            }
            else if (i == 2)                                                    // if we have two numbers
            {
                if (number >= first)                                            // if the second number is bigger
                {
                    second = first;
                    first = number;
                }
                else                                                            // if the second number is smaller
                {
                    second = number;
                }
            }
            else                                                                // if the numbers are three
            {
                if (number >= first)                                            // if the third number is biggest
                {
                    third = second;
                    second = first;
                    first = number;
                }
                else if (number <= second)                                      // if the third number is smallest 
                {
                    third = number;
                }
                else                                                            // if the third number is between the others
                {
                    third = second;
                    second = number;
                }
            }
        }
        Console.WriteLine("\nSorting: {0}, {1}, {2}", first, second, third);    // sorting
    }
}