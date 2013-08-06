//Task6: Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Collections.Generic;

class BinaryToHexadecimal
{
    static void Main()
    {
        List<char> R = new List<char>();                            // List for result in hex representation
        Console.Write("Please, enter some binary number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string binary = Console.ReadLine();                         // reads the binary number
        Console.ResetColor();
        int max = 0;
        for (int i = 4; i <= 32; i += 4)                            // calculates the max lenght of the number
        {
            if (binary.Length <= i)
            {
                max = i;
                break;
            }
        }
        string Bin = new string('0', max - binary.Length) + binary; // puts 0s before the number to max length

        char[] B = Bin.ToCharArray();                               // imports the binary number in array B
        Array.Reverse(B);                                           // reverses the array

        for (int i = 0; i < B.Length; i += 4)                       // calculates the current hex number
        {
            int sum = 0;
            for (int k = 0; k < 4; k++)
            {
                sum += int.Parse(B[i + k].ToString()) * (int)Math.Pow(2, k);
            }
            char hex = ' ';
            hex = sum >= 10 ? (char)(sum + 55) : (char)(sum + 48);
            R.Add(hex);                                             // adds the current hex number in list R
        }
        R.Reverse();                                                // reverses the list
        Console.Write("Hexadecimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var item in R)                                     // prints the result
        {
            Console.Write(item);
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}