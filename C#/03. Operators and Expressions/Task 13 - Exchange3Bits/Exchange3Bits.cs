//Task 13: Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class Exchange3Bits
{
    static void Main()
    {
        /* Short variant */
        //uint number = 1241232733;
        //long result = (((number & (7 << 3)) >> 3) << 24) | (((number & (7 << 24)) >> 24) << 3) | (number & (~((7 << 3) | (7 << 24))));

        /* Long variant */
        while (true)
        {
            try
            {
            number:
                Console.Write("Enter some integer number, or type \"end\" to exit: ");
                Console.ForegroundColor = ConsoleColor.Green;
                dynamic str = Console.ReadLine();                           // type the value of the number or "end"
                if (str == "end") break;                                    // exit if the 'str' is "end"
                if (str == "")                                              // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto number;
                }
                Console.ResetColor();
                uint number = uint.Parse(str);                              // take the number from the 'str' string

                // Calculates the number of the bits from which is created the number
                double bits = Math.Log(number + 1, 2);
                if ((int)bits != bits) bits++;
                int length = (int)bits;                                     // the bit length of the number

                uint mask1 = 7 << 3;                                        // use mask1 to backup the 1st group of bits (3, 4 and 5) 
                uint bits_group1 = (number & mask1) >> 3;                   // the 1st 3 bits (3, 4 and 5) from group1

                uint mask2 = 7 << 24;                                       // use mask2 to backup the 2nd group of bits (24, 25 and 26) 
                uint bits_group2 = (number & mask2) >> 24;                  // the 2nd 3 bits (24, 25 and 26) from group2

                uint mask = ~(mask1 | mask2);                               // use 'mask' to zeros all bit's groups from the number
                uint NumAndMask = number & mask;                            // the number without the bit's groups

                uint bits_group = (bits_group1 << 24) | (bits_group2 << 3);
                uint result = bits_group | NumAndMask;

                // Draw a table with results and decimal and binary
                Console.WriteLine();
                Console.CursorLeft = 12;
                Console.WriteLine("│  In decimal        │  In binary");
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Number   │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(number);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));         // convert the number from decimal to binary; adds 0s to left
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Mask1    │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write("7 << 3");
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(mask1, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.Write("Bits_gr1 │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(bits_group1);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(bits_group1, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Mask2    │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write("7 << 24");
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(mask2, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.Write("Bits_gr2 │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(bits_group2);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(bits_group2, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Mask     │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write("~(Mask1 | Mask2)");
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.Write("Number_0 │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(NumAndMask);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Bits_gr  │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(bits_group);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(bits_group, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Result");
                Console.ResetColor();
                Console.Write("   │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(result);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
                Console.ResetColor();
                Console.Write("\nThe result after exchanging the bits of {0} is the integer: ", number);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(result);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)                           // if there is an error the "Error message" is shown 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");
                Console.ResetColor();
            }
        }
    }
}