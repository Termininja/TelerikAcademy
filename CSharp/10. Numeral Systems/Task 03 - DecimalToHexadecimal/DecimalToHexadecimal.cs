//Task3: Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;

public class DecimalToHexadecimal
{
    public static void Main()
    {
        // Reads some decimal number
        Console.Write("Please, enter some positive integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // If the number is negative
        if (num < 0) throw new Exception();

        // Convert decimal to hex representation
        List<int> Hex = new List<int>();
        Console.Write("Hexadecimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        if (num == 0) Console.WriteLine(0);
        while (num > 0)
        {
            Hex.Add(num % 16);
            num /= 16;
        }
        Hex.Reverse();
        string temp = "";
        foreach (var item in Hex)
        {
            // Converts the big numbers to letter
            switch (item)
            {
                case 10: temp = "A"; break;
                case 11: temp = "B"; break;
                case 12: temp = "C"; break;
                case 13: temp = "D"; break;
                case 14: temp = "E"; break;
                case 15: temp = "F"; break;
                default: temp = item.ToString(); break;
            }

            // Prints the result
            Console.Write(temp);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}