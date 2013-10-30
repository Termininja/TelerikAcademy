//Task4: Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Please, enter some hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string hex = Console.ReadLine().ToLower();                  // reads the hexadecimal number
        Console.ResetColor();

        int temp, result = 0;
        for (int i = 0; i < hex.Length; i++)                        // checks the symbol is it capital or not
        {
            temp = hex[i] >= 'a' ? temp = hex[i] - 87 :  temp = hex[i] - 48;
            result += temp * (int)Math.Pow(16, hex.Length - i - 1); // calculates the result
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);                                  // prints the result
        Console.ResetColor();
    }
}