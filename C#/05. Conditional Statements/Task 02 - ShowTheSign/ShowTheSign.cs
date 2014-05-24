//Task 2: Write a program that shows the sign (+ or -) of the product of three
//        real numbers without calculating it. Use a sequence of if statements.

using System;

class ShowTheSign
{
    static void Main()
    {
        /* First solution */
        //decimal n1 = decimal.Parse(Console.ReadLine());
        //decimal n2 = decimal.Parse(Console.ReadLine());
        //decimal n3 = decimal.Parse(Console.ReadLine());

        //Console.WriteLine
        //    ((n1 == 0 || n2 == 0 || n3 == 0) ? "\nThe result of the product is 0!" :
        //    ((n1 > 0 ^ n2 > 0 ^ n3 > 0) ? "\nThe sign is +" : "\nThe sign is -"));

        /* Second solution */
        Console.Write("Please, enter how many numbers you want to compare: ");
        int limit = int.Parse(Console.ReadLine());

        int count = 0;                                                          // count the negative numbers
        bool isZero = false;                                                    // is the number 0
        for (int i = 1; i <= limit; i++)                                        // check the sign of all numbers from 1 to 'limit' 
        {
            Console.Write("Enter some real number: number {0} = ", i);
            decimal number = decimal.Parse(Console.ReadLine());
            if (number < 0) count++;                                            // if the current number is negative
            else if (number == 0) isZero = true;                                // if the current number is 0
        }

        if (isZero) Console.WriteLine("\nThe result of the product is 0!");     // if we have some zero number
        else
        {
            // If the count of negative numbers is even
            if (count % 2 == 0) Console.WriteLine("\nThe sign of the product of these {0} numbers is +", limit);
            else Console.WriteLine("\nThe sign of the product of these {0} numbers is -", limit);
        }
    }
}