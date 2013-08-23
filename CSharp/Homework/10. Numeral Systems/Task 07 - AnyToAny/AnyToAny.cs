//Task7: Write a program to convert from any numeral system of given base 's'
//       to any other numeral system of base 'd' (2 ≤ s, d ≤  16).

using System;
using System.Collections.Generic;

class AnyToAny
{
    static void Main()
    {
        byte from_base = 0;
        while (from_base < 2 || 16 < from_base)                     // is the base from 2 to 16
        {
            Console.Clear();
            Console.Write("Please, choose some numeral system (2-16): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            from_base = byte.Parse(Console.ReadLine());             // reads the base of given numeral system
            Console.ResetColor();
        }
        Console.Write("Please, enter some number from base-{0} numeral system: ", from_base);
        Console.ForegroundColor = ConsoleColor.Yellow;
        string X = Console.ReadLine();                              // the number in the given numeral system
        Console.ResetColor();

        // prints the table with all base-x numeral systems
        Console.WriteLine();
        Console.WriteLine("\t┌────────────────┬" + new string('─', 40) + "┐");
        Console.WriteLine("\t│ Numeral system │\t\tRepresentation\t\t  │");
        Console.WriteLine("\t├────────────────┼" + new string('─', 40) + "┤");

        for (byte to_base = 2; to_base <= 16; to_base++)            // for each one base will be used 'NumSystem' method
        {
            NumSystem(from_base, to_base, X);
        }
        Console.WriteLine("\t└────────────────┴" + new string('─', 40) + "┘");
    }

    static void NumSystem(byte a, byte b, string X)
    {
        int temp, Decimal = 0;
        bool bigNumber = false;
        for (int i = X.Length - 1; i >= 0; i--)                     // converting the 'x' system to decimal numeral system
        {
            temp = X[i] >= 'a' ? temp = X[i] - 87 : (X[i] >= 'A' ? temp = X[i] - 55 : temp = X[i] - 48);
            Decimal += temp * (int)Math.Pow(a, X.Length - i - 1);   // the result from decimal number
            if (Decimal < 0)                                        // if the number is too big
            {
                bigNumber = true;
            }
        }
        List<char> R = new List<char>();
        char sym = ' ';
        while (Decimal > 0)                                         // converting from decimal to desired numeral system
        {
            sym = (Decimal % b) >= 10 ? (char)(Decimal % b + 55) : (char)(Decimal % b + 48);
            R.Add(sym);                                             // adding each one symbol in R list
            Decimal /= b;
        }
        R.Reverse();                                                // reverses the list
        string c = "";
        if (b.ToString().Length == 1)                               // fills the empty symbols to arrange the table
        {
            c = " ";
        }
        Console.SetCursorPosition(8, 4 + b);                        // sets the right position to print the result
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
                foreach (var item in R)                             // prints the result for each one numeral system
                {
                    Console.Write(item);
                }
            }
            Console.ResetColor();
            if (bigNumber)
            {
                Console.Write(new string(' ', 22) + "│");
            }
            else
            {
                Console.Write(new string(' ', 37 - R.Count) + "│");
            }
        }
        Console.WriteLine();
    }
}