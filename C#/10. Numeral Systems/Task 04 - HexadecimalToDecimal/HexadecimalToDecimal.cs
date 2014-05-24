//Task4: Write a program to convert hexadecimal numbers to their decimal representation.

using System;

public class HexadecimalToDecimal
{
    public static void Main()
    {
        // Reads some hexadecimal number
        Console.Write("Please, enter some hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string hex = Console.ReadLine().ToLower();
        Console.ResetColor();

        // Convert hex to decimal representation
        int temp, result = 0;
        for (int i = 0; i < hex.Length; i++)
        {
            temp = hex[i] >= 'a' ? temp = hex[i] - 87 : temp = hex[i] - 48;
            result += temp * (int)Math.Pow(16, hex.Length - i - 1);
        }

        // Prints the result
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);
        Console.ResetColor();
    }
}