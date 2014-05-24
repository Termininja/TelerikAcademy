//Task 12: We are given integer number n, value v (v = 0 or 1) and a position p.
//Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
//Example:  n = 5 (00000101), p = 3, v = 1 → 13 (00001101)
//          n = 5 (00000101), p = 2, v = 0 → 1  (00000001)

using System;

class ValueOfPosition
{
    static void Main()
    {
        /* Short variant */
        //int n = 1234567;
        //int v = 1;
        //int p = 13;
        //int? result = null;
        //if (v == 0) result = ~(1 << p) & n;
        //else if (v == 1) result = (1 << p) | n;


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
                int n = int.Parse(str);                             // take the number from the 'str' string

                // Calculates the number of the bits from which is created the number
                double bits = Math.Log(n + 1, 2);
                if ((int)bits != bits) bits++;
                int length = (int)bits;                             // the bit length of the number

            value:
                Console.Write("Enter the value (0 or 1): ");
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // type the value of the number or "end"
                Console.ResetColor();
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto value;
                }
                int v = int.Parse(str);                             // take the value from the 'str' string
                if (v == 0 | v == 1) goto position;                 // checks if the value 'v' is 0 or 1
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The value has to be 0 or 1!");
                    Console.ResetColor();
                    goto value;
                }

            position:
                Console.Write("Enter the position (0 - {0}): ", length - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // type the value of the number or "end"
                Console.ResetColor();
                if (str == "")                                      // if is pressed only "Enter"
                {
                    Console.ResetColor();
                    goto position;
                }
                int p = int.Parse(str);                             // take the position value from the 'str' string
                if (p > length - 1)                                 // checks if the position 'p' is too big for the number 'n'
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The position is too big!");
                    Console.ResetColor();
                    goto position;
                }

                int mask = 1;
                int NumAndMask = 0;
                if (v == 0)
                {
                    mask = ~(1 << p);                               // the mask which will be applied to the number
                    NumAndMask = mask & n;                          // logical "AND" operation between the number and the mask
                }
                else if (v == 1)
                {
                    mask = (1 << p);
                    NumAndMask = mask | n;                          // logical "OR" operation between the number and the mask
                }

                // Draw a table with results and decimal and binary
                Console.WriteLine();
                Console.CursorLeft = 12;
                Console.WriteLine("│  In decimal        │  In binary");
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Number   │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(n);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));         // convert the number from decimal to binary; adds 0s to left
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.Write("Mask     │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                if (v == 0) Console.Write("~(1 << {0})", p);
                else if (v == 1) Console.Write("1 << {0}", p);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(mask, 2).PadLeft(32, '0'));
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', 36));
                Console.CursorLeft = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Result");
                Console.ResetColor();
                Console.Write("   │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(NumAndMask);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(NumAndMask, 2).PadLeft(32, '0'));
                Console.ResetColor();
                Console.Write("\nThe result after modifying of {0} is the integer: ", n);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(NumAndMask);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (OverflowException)                               // if the number is too big
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number is too big!");
                Console.ResetColor();
            }
            catch (Exception)                                       // if there is an error the "Error message" is shown 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");
                Console.ResetColor();
            }
        }
    }
}