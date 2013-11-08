//Task 8: Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        /* Short variant */
        //decimal a = 10.3m;
        //decimal b = 14m;
        //decimal h = 2.8m;
        //decimal Area = (a + b) * h / 2;

        /* Long variant */
        Console.WriteLine("This calulates trapezoid’s area by given sides a and b and height h.");
        Console.WriteLine("You can exit at any time by typing \"end\".");
        Console.Write("\nPress some key to continue . . .");
        Console.ReadKey();
        Console.Clear();
        while (true)
        {
            dynamic str = null;
            try                                                             // checks for some errors (for example if we write some string)
            {
                Console.Write("Please, enter the 1st side: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\ta = ");
                str = Console.ReadLine();
                decimal a = decimal.Parse(str);                             // take the decimal value of the 'str' for 'a'
                Console.ResetColor();

                Console.Write("Please, enter the 2nd side: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tb = ");
                str = Console.ReadLine();
                decimal b = decimal.Parse(str);                             // take the decimal value of the 'str' for 'b'
                Console.ResetColor();

                Console.Write("Please, enter the height: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\th = ");
                str = Console.ReadLine();
                decimal h = decimal.Parse(str);                             // take the decimal value of the 'str' for 'h'
                Console.ResetColor();

                decimal Area = Math.Round((a + b) * h / 2, 2);              // calculates trapezoid’s area

                Console.WriteLine("\nThe trapezoid's area is:\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("        (a + b) . h");
                Console.WriteLine("   S = ───────────── = {0}", Area);
                Console.WriteLine("             2");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)                                               // if there is an error the "Error message" is shown 
            {
                if (str == "end") break;                                    // exit if the 'side_a' is "end"
                if (str == "")                                              // if we press "Enter"
                {
                    Console.ResetColor();
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something's wrong!");
                    Console.ResetColor();
                }
            }
        }
    }
}