//Task 7: Write a program that finds the greatest of given 5 variables.

using System;

class GreatestOf5Variables
{
    static void Main()
    {
        double greatest = double.MinValue;
        for (int n = 1; n <= 5; n++)
        {
            // Read some number
            Console.Write("Enter some number: ");
            double number = double.Parse(Console.ReadLine());

            // Is the number the greatest
            if (number >= greatest) greatest = number;
        }

        // Print the result
        Console.WriteLine("The greatest number is: {0}", greatest);
    }
}