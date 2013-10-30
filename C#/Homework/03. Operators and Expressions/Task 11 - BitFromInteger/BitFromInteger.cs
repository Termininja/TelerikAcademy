//Task 11: Write an expression that extracts from a given integer i the value of a given bit number b. Example: i = 5; b = 2 → value = 1.

using System;

class BitFromInteger
{
    static void Main()
    {
        /*Short variant*/
        //int i = 124552;
        //int b = 8;
        //int value = (i & (1 << b)) >> b;

        /*Long variant*/
        for (int t = 0; ; t++)                                      // this will check continuously for some number
        {
            try                                                     // this checks for some errors (for example if we write some string)
            {
            number:
                Console.Write("Enter some integer number, or type \"end\" to exit: ");
                Console.ForegroundColor = ConsoleColor.Green;
                dynamic str = Console.ReadLine();                   // here we can type the value of the number or "end"
                if (str == "end")                                   // we will exit if the 'str' is "end"
                {
                    break;
                }
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto number;
                }
                Console.ResetColor();
                int i = int.Parse(str);                             // take the number from the 'str' string

                /*This calculates the number of the bits from which is created the number*/
                double bits = Math.Log(i + 1, 2);
                if ((int)bits != bits)
                {
                    bits++;
                }
                int length = (int)bits;                             //this is the bit length of the number

            position:
                Console.Write("Enter the position (0 - {0}), or type \"end\" to exit: ", length - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // here we can type the value of the number or "end"
                Console.ResetColor();
                if (str == "end")                                   // we will exit if the 'str' is "end"
                {
                    break;
                }
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto position;
                }
                int b = int.Parse(str);                             // take the position value from the 'str' string
                if (b > length - 1)                                 // it checks if the position 'b' is too big for the number 'i'
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The position is too big!");
                    Console.ResetColor();
                    goto position;
                }

                int mask = 1 << b;                                  // create a mask = 1; after that its bit is moved to left by 'b' bits
                int NumAndMask = (i & mask);                        // logical "AND" operation between the number and the mask
                int value = NumAndMask >> b;                        // the result is moved back to right by 'b' bits

                /*Draw a table with results and decimal and binary*/
                Console.WriteLine();
                Console.CursorLeft = 12;
                Console.WriteLine("│  In decimal        │  In binary");
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                Console.CursorLeft = 3;
                Console.Write("Number   │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write(i);
                Console.CursorLeft = 36;
                Console.WriteLine(Convert.ToString(i, 2).PadLeft(length, '0'));         // this convert the number from decimal to binary; adds 0s to left
                Console.CursorLeft = 3;
                Console.WriteLine(new string('─', 9) + "┼" + new string('─', 20) + "┼" + new string('─', length + 4));
                Console.CursorLeft = 3;
                Console.Write("Mask     │" + new string(' ', 20) + "│");
                Console.CursorLeft = 15;
                Console.Write("1 << {0}", b);
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
                Console.Write(NumAndMask + " >> {0}", b);
                Console.CursorLeft = 36; 
                Console.WriteLine(Convert.ToString(value, 2).PadLeft(length, '0'));
                Console.ResetColor();
                Console.Write("\nThe bit at position {0} in integer number {1} is: ", b, i);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(value);
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