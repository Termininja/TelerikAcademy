//Task 7: Write a program that finds the greatest of given 5 variables.

using System;

class GreatestOf5Variables
{
    static void Main()
    {
        double greatest = 0;                                                    // variable for the greatest number
        for (int n = 1; n <= 5; n++)                                            // checks each one number
        {
            Console.Write("Enter some number: ");
            double number = double.Parse(Console.ReadLine());
            if (n == 1)                                                         // if this is the 1st number
            {
                greatest = number;
            }
            else if (number >= greatest)                                        // if this is not the 1st number, checks is it bigger than greatest
            {
                greatest = number;
            }
        }
        Console.WriteLine("The greatest number is: {0}", greatest);
    }
}