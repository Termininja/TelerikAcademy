//Task 3: Modify the application to print your name.

using System;

class WriteMyName
{
    static void Main()
    {
        // Read some string
        Console.Write("Please, enter your name and press Enter: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string name = Console.ReadLine();
        Console.ResetColor();

        // Print the result
        Console.Write("\nYour name is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(name);
        Console.ResetColor();
    }
}