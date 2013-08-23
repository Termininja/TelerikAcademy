//Task 6: Create console application that prints your first and last name.

using System;

class PrintFirsLastName
{
    static void Main()
    {
        Console.WriteLine("What is your first name?");
        string first = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string last = Console.ReadLine();
        Console.WriteLine("Your full name is: " + first + " " + last);
    }
}