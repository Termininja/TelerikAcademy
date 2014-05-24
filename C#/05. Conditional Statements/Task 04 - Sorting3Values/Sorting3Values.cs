//Task 4: Sort 3 real values in descending order using nested if statements.

using System;

class Sorting3Values
{
    static void Main()
    {
        int value1 = 0;
        int value2 = 0;
        int value3 = 0;
        for (int i = 1; i <= 3; i++)
        {
            // Read some number for each 'i'
            Console.Write("Please, enter some real number: ");
            int number = int.Parse(Console.ReadLine());
            if (i == 1) value1 = number;
            else if (i == 2)
            {
                if (number >= value1)       // if the second number is bigger
                {
                    value2 = value1;
                    value1 = number;
                }
                else value2 = number;       // if the second number is smaller
            }
            else
            {
                if (number >= value1)       // if the third number is biggest
                {
                    value3 = value2;
                    value2 = value1;
                    value1 = number;
                }
                else if (number <= value2) value3 = number;     // if the third number is smallest 
                else                                            // if the third number is between the others
                {
                    value3 = value2;
                    value2 = number;
                }
            }
        }

        // Print the numbers sorted in descending order
        Console.WriteLine("\nSorting: {0}, {1}, {2}", value1, value2, value3);
    }
}