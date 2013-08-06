//Task2: Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Please, enter some binary number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string binary = Console.ReadLine();                 // reads the binary number
        Console.ResetColor();
        long num = 0;
        for (int i = binary.Length - 1; i >= 0; i--)        // calculates the number by checking every bit
        {
            num += (binary[i] - 48) * (long)Math.Pow(2, binary.Length - i - 1);
        }
        Console.Write("Decimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(num);                             // prints the result
        Console.ResetColor();
    }
}