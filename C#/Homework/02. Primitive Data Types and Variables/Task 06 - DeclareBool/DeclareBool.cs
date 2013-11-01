//Task 6: Declare a boolean variable called isFemale and assign
//        an appropriate value corresponding to your gender.

using System;

class DeclareBool
{
    static void Main()
    {
        // Declaring a boolean variable
        bool isFemale;

        // Read some input user key
        Console.Write("What is your gender (m/f): ");
        isFemale = (Console.ReadKey().Key == ConsoleKey.M) ? false : true;

        // Print the result
        Console.ForegroundColor = ConsoleColor.White;
        if (isFemale) Console.WriteLine("\nYou are female!");
        else Console.WriteLine("\nYou are male!");
        Console.ResetColor();
    }
}