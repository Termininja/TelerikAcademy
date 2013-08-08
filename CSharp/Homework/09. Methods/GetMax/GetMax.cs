//Task 2: Write a method GetMax() with two parameters that returns the bigger of two integers.
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class Get_Max
{
    static void Main()
    {
        Console.WriteLine("Please, enter 3 integer numbers: ");
        int number1 = EnterNumber(1);                   // calls the "EnterNumber" method
        int number2 = EnterNumber(2);
        int number3 = EnterNumber(3);

        Console.Write("The biggest numbers is: ");      // prints the biggest number
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(GetMax(GetMax(number1, number2), number3));
        Console.ResetColor();
    }

    static int EnterNumber(int n)                       // method which reads a number 
    {
        Console.Write(" number{0} = ", n);
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());
        Console.ResetColor();
        return number;
    }

    static int GetMax(int n1, int n2)                   // method which compares two numbers
    {
        return n1 > n2 ? n1 : n2;
    }
}