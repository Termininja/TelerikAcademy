//Task 1: Familiarize yourself with:
// 			* Microsoft Visual Studio
// 			* Microsoft Developer Network (MSDN) Library Documentation
// 			* Find information about Console.WriteLine() method.

using System;

class FamiliarizeWithVS
{
    static void Main()
    {
        Console.Write("Task: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Familiarize yourself with Microsoft Visual Studio and MSDN Library Documentation");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Solution: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Done!\n");
        Console.ResetColor();
    }
}