//Task 14*: Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

//The range (in reading) for 'k', 'p' and 'q' has to be corrected!!!

using System;

class ExchangeBitSeries
{
    static void Main()
    {
        /*Short variant*/
        //uint rank = 1;
        //for (int s = 1; s <= k; s++)
        //{
        //    rank = 2 * rank;
        //}
        //long result = ((number & ((rank - 1) << q)) >> (q - p)) | ((number & ((rank - 1) << p)) << (q - p)) | (number & (~(((rank - 1) << p) | ((rank - 1) << q))));

        /*Long variant*/
        for (int t = 0; ; t++)                                              // this will check continuously for some number
        {
            try                                                             // this checks for some errors (for example if we write some string)
            {
            number:
                Console.Write("Enter some integer number, or type \"end\" to exit: ");
                Console.ForegroundColor = ConsoleColor.Green;
                dynamic str = Console.ReadLine();                           // here we can type the value of the number or "end"
                if (str == "end")                                           // we will exit if the 'str' is "end"
                {
                    break;
                }
                if (str == "")                                              // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto number;
                }
                Console.ResetColor();
                uint number = uint.Parse(str);                              // take the number from the 'str' string

                /*This calculates the number of the bits from which is created the number*/
                double bits = Math.Log(number + 1, 2);
                if ((int)bits != bits)
                {
                    bits++;
                }
                int length = (int)bits;                                     //this is the bit length of the number

            k:
                Console.Write("Enter how many bits k (0 - {0}) you want to exchange: ", length / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // here we can type the value of the number or "end"
                Console.ResetColor();
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto k;
                }
                int k = int.Parse(str);                             // take the "k" value from the 'str' string
                if (k > length / 2)                           // it checks if the 'k' is too big for the number 'number'
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The k is too big!");
                    Console.ResetColor();
                    goto k;
                }

            from_position:
                Console.Write("Enter the old position p (0 - {0}): ", (length / 2) - k);
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // here we can type the value of the number or "end"
                Console.ResetColor();
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto from_position;
                }
                int p = int.Parse(str);                             // take the position value from the 'str' string
                if (p > (length / 2) - k)                                 // it checks if the position 'p' is too big for the 'number'
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The p is too big!");
                    Console.ResetColor();
                    goto from_position;
                }

            to_position:
                Console.Write("Enter the new position q ({0} - {1}): ", p + k - 1, length - k);
                Console.ForegroundColor = ConsoleColor.Green;
                str = Console.ReadLine();                           // here we can type the value of the number or "end"
                Console.ResetColor();
                if (str == "")                                      // if you press only "Enter"
                {
                    Console.ResetColor();
                    goto to_position;
                }
                int q = int.Parse(str);                             // take the "q" value from the 'str' string
                if (q > length - k | q < p + k - 1)                                 // it checks if the 'q' is too big for the number 'number'
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The q is too big!");
                    Console.ResetColor();
                    goto to_position;
                }

                uint rank = 1;
                for (int s = 1; s <= k; s++)
                {
                    rank = 2 * rank;
                }

                uint mask1 = (rank - 1) << p;                                        // we use mask1 to backup the 1st group of bits (3, 4 and 5) 
                uint bits_group1 = (number & mask1) >> p;                   // these are the 1st 3 bits (3, 4 and 5) from group1

                uint mask2 = (rank - 1) << q;                                       // we use mask2 to backup the 2nd group of bits (24, 25 and 26) 
                uint bits_group2 = (number & mask2) >> q;                  // these are the 2nd 3 bits (24, 25 and 26) from group2

                uint mask = ~(mask1 | mask2);                               // we use 'mask' to zeros all bit's groups from the number
                uint NumAndMask = number & mask;                            // this is the number without the bit's groups

                uint bits_group = (bits_group1 << q) | (bits_group2 << p);
                uint result = bits_group | NumAndMask;

                /*Draw a table with results and decimal and binary*/
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
                Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));         // this convert the number from decimal to binary; adds 0s to left
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
            catch (Exception)                                                           // if there is an error the "Error message" is shown 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");
                Console.ResetColor();
            }
        }
    }
}