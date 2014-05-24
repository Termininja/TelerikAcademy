//Task2: Write a program that reads a string, reverses it and prints the result at the console.
//       Example: "sample" → "elpmas".

using System;

class ReverseString
{
    static void Main()
    {
        // Reads some text and put it in array
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        char[] text = Console.ReadLine().ToCharArray();
        Console.ResetColor();

        // Reverses the array
        Array.Reverse(text);

        // Prints the result
        Console.Write("\nThe reverses text is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}