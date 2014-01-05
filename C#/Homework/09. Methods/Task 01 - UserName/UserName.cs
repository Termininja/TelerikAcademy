// Task 1: Write a method that asks the user for his name and prints “Hello, <name>”.
//         Example: “Hello, Peter!”. Write a program to test this method.

using System;

class UserName
{
    static void Main()
    {
        // Call the method
        WhatIsYourName();
    }

    // Reads and prints some user name
    static void WhatIsYourName()
    {
        Console.Write("What is your name: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Hello, {0}!", name);
        Console.ResetColor();
    }
}