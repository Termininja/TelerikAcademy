// Task 2: Write a method GetMax() with two parameters that returns the bigger
//         of two integers. Write a program that reads 3 integers from the
//         console and prints the biggest of them using the method GetMax().

using System;

class Get_Max
{
    static void Main()
    {
        // Reads 3 integer numbers
        Console.WriteLine("Please, enter 3 integer numbers: ");
        int number1 = EnterNumber(1);
        int number2 = EnterNumber(2);
        int number3 = EnterNumber(3);

        // Print the biggest number
        Console.Write("The biggest numbers is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(GetMax(GetMax(number1, number2), number3));
        Console.ResetColor();
    }

    // Reads some number 
    static int EnterNumber(int n)
    {
        Console.Write("number{0} = ", n);
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());
        Console.ResetColor();
        return number;
    }

    // Compares two numbers
    static int GetMax(int n1, int n2)
    {
        return (n1 > n2) ? n1 : n2;
    }
}