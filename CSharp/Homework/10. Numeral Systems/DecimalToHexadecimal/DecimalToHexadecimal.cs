//Task3: Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    static void Main()
    {
        List<int> Hex = new List<int>();
        Console.Write("Please, enter some positive integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());            // reads the number
        Console.ResetColor();

        if (num < 0)                                        // if the number is negative
        {
            throw new Exception();
        }

        Console.Write("Hexadecimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        if (num == 0)                                       // if the number is equal to 0
        {
            Console.WriteLine(0);
        }
        while (num > 0)                                     // calculates the result
        {
            Hex.Add(num % 16);                              // adds each one value in array
            num /= 16;
        }
        Hex.Reverse();                                      // reverses the array

        string temp = "";
        foreach (var item in Hex)
        {
            switch (item)                                   // converts the big numbers to letter
            {
                case 10: temp = "A"; break;
                case 11: temp = "B"; break;
                case 12: temp = "C"; break;
                case 13: temp = "D"; break;
                case 14: temp = "E"; break;
                case 15: temp = "F"; break;
                default: temp = item.ToString(); break;
            }
            Console.Write(temp);                            // prints the result
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}