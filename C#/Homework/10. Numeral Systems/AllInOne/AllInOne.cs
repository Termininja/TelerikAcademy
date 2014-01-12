using System;
using System.Threading;

class AllTasks
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        InOut("Welcome!");
        while (true)
        {
            Console.Clear();
            Contents();
            ConsoleKeyInfo key = Console.ReadKey();
            while (true)
            {
                Console.Clear();
                try
                {
                    if (key.Key == ConsoleKey.D1) DecimalToBinary.Main();
                    else if (key.Key == ConsoleKey.D2) BinaryToDecimal.Main();
                    else if (key.Key == ConsoleKey.D3) DecimalToHexadecimal.Main();
                    else if (key.Key == ConsoleKey.D4) HexadecimalToDecimal.Main();
                    else if (key.Key == ConsoleKey.D5) HexadecimalToBinary.Main();
                    else if (key.Key == ConsoleKey.D6) BinaryToHexadecimal.Main();
                    else if (key.Key == ConsoleKey.D7) AnyToAny.Main();
                    else if (key.Key == ConsoleKey.D8) ShortToBinary.Main();
                    else if (key.Key == ConsoleKey.D9) FloatToBinary.Main();
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        InOut("Goodbye!");
                        Environment.Exit(0);
                    }
                    else break;

                    TextButton("\n\nThis was the end of the program.\nPress ", "Enter");
                    TextButton(" to try again or ", "Esc");
                    TextButton(" to go to Main Menu . . .", null);

                    ConsoleKeyInfo k = Console.ReadKey();
                    while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape)
                    {
                        Console.Write("\b \b");
                        k = Console.ReadKey();
                    }
                    if (k.Key == ConsoleKey.Escape) break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n\nYou made something wrong!\nPress any key to try again . . .");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }

    static void Contents()
    {
        TextButton("\n\n   Homework 4. Numeral Systems\n", null);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Write a program to convert decimal numbers to their binary representation.

      Task 2: Write a program to convert binary numbers to their decimal representation.

      Task 3: Write a program to convert decimal numbers to their hexadecimal representation.

      Task 4: Write a program to convert hexadecimal numbers to their decimal representation.

      Task 5: Write a program to convert hexadecimal numbers to binary numbers (directly).

      Task 6: Write a program to convert binary numbers to hexadecimal numbers (directly).

      Task 7: Write a program to convert from any numeral system of given base 's' to any
              other numeral system of base 'd' (2 <= s, d <= 16).

      Task 8: Write a program that shows the binary representation of given 16-bit signed
              integer number (the C# type short).

      Task 9: Write a program that shows the internal binary representation of given 32-bit
              signed floating-point number in IEEE 754 format (the C# type float).
              Example: -27,25 → sign = 1, exp = 10000011, mantissa = 10110100000000000000000.
                         ");
        Console.ResetColor();
        TextButton("   Please, select a task number from ", "1");
        TextButton(" to ", "9");
        TextButton(" or press ", "ESC");
        TextButton(" to exit... ", null);
    }

    private static void TextButton(string text, string key)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(text);
        if (key != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
        }
        Console.ResetColor();
    }

    static void InOut(string text)
    {
        Console.SetCursorPosition(47, 10);
        Console.Write(text);
        Console.SetCursorPosition(99, 33);
        Thread.Sleep(2000);
    }
}