//Task2: Write a program that reads a string, reverses it and prints the result at the console.
//       Example: "sample" → "elpmas".

using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        char[] text = Console.ReadLine().ToCharArray();     // reads some text and put it in array
        Console.ResetColor();

        Array.Reverse(text);                                // reverses the array

        Console.Write("\nThe reversed text is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);                            // prints the result
        Console.ResetColor();
    }
}
