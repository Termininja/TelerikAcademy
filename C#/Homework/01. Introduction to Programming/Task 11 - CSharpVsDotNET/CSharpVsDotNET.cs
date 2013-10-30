//Task 11: Describe the difference between C# and .NET Framework.

using System;

class  CSharpVsDotNET
{
    static void Main()
    {
        Console.Write("Task: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Describe the difference between C# and .NET Framework");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Decision: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The .Net Framework(initial release 13 February 2002) is a software framework developed by Microsoft that runs primarily on Microsoft Windows. It includes a large library of over 4000 classes organized into namespaces that provide a wide variety of useful functionality for everything from file input and output to string manipulation to XML parsing, to Windows Forms controls. Also it provides language interoperability across several programming languages, like C#, Visual Basic .NET, C++/CLI, Managed, F#, J#, Windows PowerShell and still more than 20 other CTS-compliant languages. The typical C# application uses the .NET Framework class library extensively to handle common \"plumbing\" chores.\n");
        Console.WriteLine("Programs written for the .NET Framework execute in a software environment, known as the Common Language Runtime (CLR), an application virtual machine that provides services such as security, automatic garbage collection, memory management, and exception handling.\n");
        Console.WriteLine("The class library and the CLR together constitute the .NET Framework.");
        Console.ResetColor();
    }
}