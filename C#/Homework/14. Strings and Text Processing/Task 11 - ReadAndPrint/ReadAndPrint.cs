//Task11: Write a program that reads a number and prints it as a decimal number, hexadecimal number,
//        percentage and in scientific notation. Format the output aligned right in 15 symbols.

using System;

class ReadAndPrint
{
    static void Main()
    {
        Console.Write("Please, enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string number = Console.ReadLine();                 // reads some number
        Console.ResetColor();

        // prints the result aligned right in 15 symbols
        Console.WriteLine();
        Print("In decimal format: ", "{0,15:F}", number);
        Print("In hexadecimal format: ", "{0,15:X}", number);
        Print("In percentage format: ", "{0,15:P}", number);
        Print("In scientific notation format: ", "{0,15:E}", number);
    }

    static void Print(string text, string format, string num)
    {
        Console.Write("{0,-33}", text);                     // align the text to left
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(format, int.Parse(num));
        Console.ResetColor();
    }
}