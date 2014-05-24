//Task7: Write a program to convert from any numeral system of given base 's'
//       to any other numeral system of base 'd' (2 ≤ s, d ≤  16).

using System;
using System.Collections.Generic;

public class AnyToAny
{
    public static void Main()
    {
        // Reads the base of given numeral system
        byte from_base = 0;
        while (from_base < 2 || 16 < from_base)
        {
            Console.Clear();
            Console.Write("Please, choose some numeral system (2-16): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            from_base = byte.Parse(Console.ReadLine());
            Console.ResetColor();
        }

        // Read some number in the given numeral system
        Console.Write("Please, enter some number from base-{0} numeral system: ", from_base);
        Console.ForegroundColor = ConsoleColor.Yellow;
        string X = Console.ReadLine();
        Console.ResetColor();

        // Prints the table with all base-x numeral systems
        Console.WriteLine();
        Console.WriteLine("\t┌────────────────┬" + new string('─', 40) + "┐");
        Console.WriteLine("\t│ Numeral system │\t\tRepresentation\t\t  │");
        Console.WriteLine("\t├────────────────┼" + new string('─', 40) + "┤");

        for (byte to_base = 2; to_base <= 16; to_base++)
        {
            NumSystem(from_base, to_base, X);
        }
        Console.WriteLine("\t└────────────────┴" + new string('─', 40) + "┘");
    }

    // Convert some system to decimal and print the result
    static void NumSystem(byte a, byte b, string X)
    {
        int temp, Decimal = 0;
        bool bigNumber = false;
        for (int i = X.Length - 1; i >= 0; i--)
        {
            temp = X[i] >= 'a' ? temp = X[i] - 87 : (X[i] >= 'A' ? temp = X[i] - 55 : temp = X[i] - 48);
            Decimal += temp * (int)Math.Pow(a, X.Length - i - 1);
            if (Decimal < 0) bigNumber = true;
        }

        // Convert from decimal to desired numeral system
        List<char> R = new List<char>();
        char sym = ' ';
        while (Decimal > 0)
        {
            sym = (Decimal % b) >= 10 ? (char)(Decimal % b + 55) : (char)(Decimal % b + 48);
            R.Add(sym);
            Decimal /= b;
        }
        R.Reverse();
        string c = "";
        if (b.ToString().Length == 1) c = " ";
        Console.SetCursorPosition(8, 4 + b);
        Console.Write("│");
        Console.ForegroundColor = a == b ? ConsoleColor.Yellow : ConsoleColor.Green;
        Console.Write("    Base-{0}{1}     ", b, c);
        Console.ResetColor();
        Console.Write("│   ");
        Console.ForegroundColor = a == b ? ConsoleColor.Yellow : ConsoleColor.Green;
        if (X == "0")
        {
            Console.Write(0);
            Console.ResetColor();
            Console.Write(new string(' ', 36) + "│");
        }
        else
        {
            if (bigNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Too big number!");
                Console.ResetColor();
            }
            else
            {
                // Prints the result for each one numeral system
                foreach (var item in R)
                {
                    Console.Write(item);
                }
            }
            Console.ResetColor();
            if (bigNumber) Console.Write(new string(' ', 22) + "│");
            else Console.Write(new string(' ', 37 - R.Count) + "│");
        }
        Console.WriteLine();
    }
}