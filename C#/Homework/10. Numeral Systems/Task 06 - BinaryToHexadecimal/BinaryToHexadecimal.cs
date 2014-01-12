//Task6: Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Collections.Generic;

public class BinaryToHexadecimal
{
    public static void Main()
    {
        // Reads some binary number
        Console.Write("Please, enter some binary number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string binary = Console.ReadLine();
        Console.ResetColor();

        // Calculates the max lenght of the number
        int max = 0;
        for (int i = 4; i <= 32; i += 4)
        {
            if (binary.Length <= i)
            {
                max = i;
                break;
            }
        }

        // Puts 0s before the number to max length
        string Bin = new string('0', max - binary.Length) + binary;

        // Imports the binary number in array B
        char[] B = Bin.ToCharArray();

        // Reverses the array
        Array.Reverse(B);

        // Calculates the current hex number
        List<char> R = new List<char>();
        for (int i = 0; i < B.Length; i += 4)
        {
            int sum = 0;
            for (int k = 0; k < 4; k++)
            {
                sum += int.Parse(B[i + k].ToString()) * (int)Math.Pow(2, k);
            }
            char hex = ' ';
            hex = sum >= 10 ? (char)(sum + 55) : (char)(sum + 48);
            R.Add(hex);
        }

        // Reverses the list
        R.Reverse();

        // Prints the result
        Console.Write("Hexadecimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var item in R)
        {
            Console.Write(item);
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}