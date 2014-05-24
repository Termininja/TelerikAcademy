//Task 10: Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1.
//Example: v=5; p=1 → false.

using System;

class BitPosition
{
    static void Main()
    {
        /* Short variant */
        //int n = 124552;
        //int p = 3;
        //bool result = ((n & (1 << p)) >> p) == 1;

        /* Long variant */
        while (true)
        {
            try
            {
            number:
                Console.Write("Enter some integer number, or type \"end\" to exit: ");
                Console.ForegroundColor = ConsoleColor.Green;
                dynamic str = Console.ReadLine();                   // type the value of the number or "end"
                if (str == "end") break;                            // exit if the 'str' is "end"
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto number;
                }
                Console.ResetColor();
                int v = int.Parse(str);                             // take the number from the 'str' string

                // Calculates the number of the bits from which is created the number
                double bits = Math.Log(v + 1, 2);
                if ((int)bits != bits) bits++;
                int length = (int)bits;                             // the bit length of the number

            position:
                Console.Write("Enter the position (0 - {0}), or type \"end\" to exit: ", length - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // type the value of the number or "end"
                Console.ResetColor();
                if (str == "end") break;                            // exit if the 'str' is "end"
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto position;
                }
                int p = int.Parse(str);                             // take the position value from the 'str' string
                if (p > length - 1)                                 // checks if the position 'p' is too big for the number 'v'
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The position is too big!");
                    Console.ResetColor();
                    goto position;
                }

                int mask = 1 << p;                                  // create a mask = 1; after that its bit is moved to left by 'p' bits
                int NumAndMask = (v & mask);                        // logical "AND" operation between the number and the mask
                int result = NumAndMask >> p;                       // the result is moved back to right by 'p' bits

                bool compare = result == 1;                         // checks if the bit at position 'p' is 1

                // Draw a table with results and decimal and binary
                Console.WriteLine();
                Console.CursorLeft = 12;
                Console.WriteLine("│  In decimal        │  In binary");
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                Console.CursorLeft = 3;
                Console.Write("Number   │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(v);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(v, 2).PadLeft(length, '0'));         // convert the number from decimal to binary; adds 0s to left
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                Console.CursorLeft = 3;
                Console.Write("Mask     │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write("1 << {0}", p);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(mask, 2).PadLeft(length, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                Console.CursorLeft = 3;
                Console.Write("&        │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(NumAndMask);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(length, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                Console.CursorLeft = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Result   ");
                Console.ResetColor();
                Console.Write("│" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(NumAndMask + " >> {0}", p);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(result, 2).PadLeft(length, '0'));
                Console.ResetColor();
                Console.Write("\nThe bit at position {0} is 1: ", p);
                if (compare == true) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(compare);                                                 // the result from the comparison
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (OverflowException)                                                   // if the number is too big
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number is too big!");
                Console.ResetColor();
            }
            catch (Exception)                                                           // if there is an error the "Error message" is shown 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");
                Console.ResetColor();
            }
        }
    }
}