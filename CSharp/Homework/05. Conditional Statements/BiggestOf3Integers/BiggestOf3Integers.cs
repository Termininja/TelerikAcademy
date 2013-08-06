//Task 3: Write a program that finds the biggest of three integers using nested if statements.

using System;

class BiggestOf3Integers
{
    static void Main()
    {
        Console.Write("Please, enter the 1st integer number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd integer number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 3rd integer number: ");
        int num3 = int.Parse(Console.ReadLine());

        if (num1 == num2 && num2 == num3)                               // if the three numbers are equal
        {
            Console.WriteLine("The three numbers are equal!");
        }
        else if (num1 > num2 && num1 > num3)                            // if the 1st number is biggest
        {
            Console.WriteLine("The biggest number is {0}", num1);
        }
        else if (num2 > num1 && num2 > num3)                            // if the 2nd number is biggest
        {
            Console.WriteLine("The biggest number is {0}", num2);
        }
        else if (num3 > num1 && num3 > num2)                            // if the 3rd number is biggest
        {
            Console.WriteLine("The biggest number is {0}", num3);
        }
    }
}