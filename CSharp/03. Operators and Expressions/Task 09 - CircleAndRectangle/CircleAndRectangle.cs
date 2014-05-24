//Task 9: Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
//and out of the rectangle R(top = 1, left = -1, width = 6, height = 2).

using System;

class CircleAndRectangle
{
    static void Main()
    {
        /* Short variant */
        //double x = 2.45;
        //double y = -16;
        //bool result = (Math.Sqrt(Math.Pow(1 - x, 2) + Math.Pow(1 - y, 2)) < 3) && !((x > -1) && (x < 5) && (y > -1) && (y < 1));

        /* Long variant */
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("This program compares the position of some point A(x,y) according the position of arbitrary circle K(Ox,Oy,r) and rectangle R(Rx,Ry,w,h).");
        Console.WriteLine("You can exit at any time by typing \"end\".");
        Console.ResetColor();
        Console.Write("\nPress some key to continue . . .");
        Console.ReadKey();
        Console.Clear();
        while (true)
        {
            dynamic str = null;
            try
            {
                // Read the information about the circle
                Console.WriteLine("Information about the Circle K(Ox,Oy,r):");
                double Ox = ReadValue("  x coordinate: ", "\tOx = ", ref str);
                double Oy = ReadValue("  y coordinate: ", "\tOy = ", ref str);
                double r = ReadValue("  radius: ", "\t\tr = ", ref str);

                // Read the information about the rectangle
                Console.WriteLine("\nInformation about the rectangle R(Rx,Ry,w,h):");
                double Rx = ReadValue("  x coordinate (left): ", "\tRx = ", ref str);
                double Ry = ReadValue("  y coordinate (top): ", "\tRy = ", ref str);
                double w = ReadValue("  width: ", "\t\tw = ", ref str);
                double h = ReadValue("  height: ", "\t\th = ", ref str);

                // Read the information about the Point A
                Console.WriteLine("\nInformation about the Point A(x,y):");
                double x = ReadValue("  x coordinate: ", "\tx = ", ref str);
                double y = ReadValue("  y coordinate: ", "\ty = ", ref str);

                bool result =
                    (Math.Sqrt(Math.Pow(Ox - x, 2) + Math.Pow(Oy - y, 2)) < r) &&
                    !((x > Rx) && (x < Rx + w) && (y > Ry - h) && (y < Ry));

                Console.Write(
                    "\nThe point A({0},{1}) is within the circle K({2},{3},{4}) and out of the rectangle R({5},{6},{7},{8}): ",
                    x, y, Ox, Oy, r, Rx, Ry, w, h);

                if (result == true) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(result + "!");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)                   // if there is an error the "Error message" is shown 
            {
                if (str == "end") break;        // we will exit if the 'side_a' is "end"
                if (str == "")                  // if we press "Enter"
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

    // Method which reads some input value
    private static double ReadValue(string text1, string text2, ref dynamic str)
    {
        Console.Write(text1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(text2);
        str = Console.ReadLine();
        double value = double.Parse(str);       // take decimal value of the 'str' for this value
        Console.ResetColor();
        return value;
    }
}