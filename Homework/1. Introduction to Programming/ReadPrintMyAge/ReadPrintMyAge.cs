//Task 12*: Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class ReadPrintMyAge
{
    static void Main()
    {
        Console.Write("How old are you? ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("After 10 years you'll be " + (age + 10) + " years old");
    }
}