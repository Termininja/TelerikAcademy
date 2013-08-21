using System;

class InstallVS
{
    static void Main()
    {
        Console.Write("Task: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Install at home Microsoft Visual Studio");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDecision: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Done!\n");
        Console.ResetColor();
    }
}