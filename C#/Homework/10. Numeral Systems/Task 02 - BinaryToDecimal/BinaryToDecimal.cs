//Task2: Write a program to convert binary numbers to their decimal representation.

using System;

public class BinaryToDecimal
{
    public static void Main()
    {
        // Reads some binary number
        Console.Write("Please, enter some binary number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string binary = Console.ReadLine();
        Console.ResetColor();
        long num = 0;

        // Convert bin to decimal representation
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            num += (binary[i] - 48) * (long)Math.Pow(2, binary.Length - i - 1);
        }

        // Prints the result
        Console.Write("Decimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(num);
        Console.ResetColor();
    }
}