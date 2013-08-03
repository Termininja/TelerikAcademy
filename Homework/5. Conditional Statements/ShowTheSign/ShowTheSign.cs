//Task 2: Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

using System;

class ShowTheSign
{
    static void Main()
    {
        /* First solution */
        //decimal num1 = decimal.Parse(Console.ReadLine());
        //decimal num2 = decimal.Parse(Console.ReadLine());
        //decimal num3 = decimal.Parse(Console.ReadLine());
        //if (num1 == 0 || num2 == 0 || num3 == 0)
        //{
        //    Console.WriteLine("\nThe result of the product is 0!");
        //}
        //else if (num1 > 0 ^ num2 > 0 ^ num3 > 0)
        //{
        //    Console.WriteLine("\nThe sign of the product of these three numbers is +");
        //}
        //else
        //{
        //    Console.WriteLine("\nThe sign of the product of these three numbers is -");
        //}

        /* Second solution */
        Console.Write("Please, enter how many numbers you want to compare: ");
        int limit = int.Parse(Console.ReadLine());

        int count = 0;                                                                  // this count the negative numbers
        bool zero = false;                                                              // is the number 0
        for (int i = 1; i <= limit; i++)                                                // we check the sign of all numbers from 1 to 'limit' 
        {
            Console.Write("Enter some real number: number {0} = ", i);
            decimal number = decimal.Parse(Console.ReadLine());
            if (number < 0)                                                             // if the current number is negative
            {
                count++;
            }
            else if (number == 0)                                                       // if the current number is 0
            {
                zero = true;
            }
        }
        if (zero)                                                                       // if we have some zero number
        {
            Console.WriteLine("\nThe result of the product is 0!");
        }

        else
        {
            if (count % 2 == 0)                                                         // if the count of negative numbers is even
            {
                Console.WriteLine("\nThe sign of the product of these {0} numbers is +", limit);
            }
            else
            {
                Console.WriteLine("\nThe sign of the product of these {0} numbers is -", limit);
            }
        }
    }
}