//Task 3: Write an expression that calculates rectangle’s area by given width and height.

using System;

class RectangleArea
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("This program calulates rectangle’s area by given width and height.");
        Console.WriteLine("You can exit at any time by typing \"end\".");
        Console.ResetColor();
        Console.Write("\nPress some key to continue . . .");
        Console.ReadKey();
        Console.Clear();
        for (int i = 0; ; i++)
        {
            try                                                             // this checks for some errors (for example if we write some string)
            {
                Console.Write("Please, enter the width: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tw = ");
                dynamic width = Console.ReadLine();                         // here we can type the 'width value' or "end"
                if (width == "end")                                         // we will exit if the 'width' is "end"
                {
                    break;
                }
                decimal w = decimal.Parse(width);                           // take the decimal value of the 'width'
                Console.ResetColor();

                Console.Write("Please, enter the height: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\th = ");
                dynamic height = Console.ReadLine();                        // here we can type the 'height value' or "end"
                if (height == "end")                                        // we will exit if the 'height' is "end"
                {
                    break;
                }
                decimal h = decimal.Parse(height);                          // take the decimal value of the 'height'
                Console.ResetColor();

                decimal Area = Math.Round((w * h), 2);                      // it calculates rectangle’s area

                Console.WriteLine("\nThe rectangle's area is:\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   S = w . h = {0}", Area);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)                                               // if there is an error the "Error message" is shown 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");
                Console.ResetColor();
            }
        }
    }
}