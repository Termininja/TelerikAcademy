//Task 12*: Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class ReadPrintMyAge
{
    static void Main()
    {
        // Read some age from the console
        Console.Write("How old are you? ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int age = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // Print the age after 10 years
        Console.Write("After 10 years you'll be ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(age + 10);
        Console.ResetColor();
        Console.WriteLine(" years old\n");
    }
}