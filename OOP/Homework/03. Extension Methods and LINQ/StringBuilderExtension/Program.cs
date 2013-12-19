// Task 01. Implement an extension method Substring(int index, int length) for the class StringBuilder
//          that returns new StringBuilder and has the same functionality as Substring in the class String.

using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        // Formation some text
        StringBuilder str = new StringBuilder();
        str.Append(@"C# is a multi-paradigm programming language encompassing strong typing, ");
        str.Append(@"imperative, declarative, functional, procedural, generic, object-oriented ");
        str.Append(@"(class-based), and component-oriented programming disciplines. ");
        str.Append(@"It was developed by Microsoft within its .NET initiative and later approved as ");
        str.Append(@"a standard by Ecma (ECMA-334) and ISO (ISO/IEC 23270:2006). ");
        str.Append(@"C# is one of the programming languages designed for the Common Language Infrastructure.");
        Console.Write("Input string: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n" + str);
        Console.ResetColor();

        // The result from using of extension method Substring()
        StringBuilder result = new StringBuilder();
        result.Append(str.Substring(0, 5));
        result.Append(str.Substring(22, 21));
        result.Append(str.Substring(207, 31));
        result.Append(str.Substring(207, 1));
        Console.Write("\nResult: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n" + result);
        Console.ResetColor();
    }
}