//Task 9: Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
//and out of the rectangle R(top = 1, left = -1, width = 6, height = 2).

using System;

class CircleAndRectangle
{
    static void Main()
    {
        /*Short variant*/
        //double x = 2.45;
        //double y = -16;
        //bool result = (Math.Sqrt(Math.Pow(1 - x, 2) + Math.Pow(1 - y, 2)) < 3) && !((x > -1) && (x < 5) && (y > -1) && (y < 1));

        /*Long variant*/
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("This program compares the position of some point A(x,y) according the position of arbitrary circle K(Ox,Oy,r) and rectangle R(Rx,Ry,w,h).");
        Console.WriteLine("You can exit at any time by typing \"end\".");
        Console.ResetColor();
        Console.Write("\nPress some key to continue . . .");
        Console.ReadKey();
        Console.Clear();
        for (int i = 0; ; i++)
        {
            dynamic str = null;
            try                                                                 // this checks for some errors (for example if we write some string)
            {
                Console.WriteLine("Information about the Circle K(Ox,Oy,r):");

                Console.Write("\tx coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\tOx = ");
                str = Console.ReadLine();
                double Ox = double.Parse(str);                                  // take the decimal value of the 'str' for 'Ox'
                Console.ResetColor();

                Console.Write("\ty coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\tOy = ");
                str = Console.ReadLine();
                double Oy = double.Parse(str);                                  // take the decimal value of the 'str' for 'Oy'
                Console.ResetColor();

                Console.Write("\tradius: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\tr = ");
                str = Console.ReadLine();
                double r = double.Parse(str);                                   // take the decimal value of the 'str' for 'r'
                Console.ResetColor();

                Console.WriteLine("\nInformation about the rectangle R(Rx,Ry,w,h):");

                Console.Write("\tx coordinate (left): ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tRx = ");
                str = Console.ReadLine();
                double Rx = double.Parse(str);                                  // take the decimal value of the 'str' for 'Rx'
                Console.ResetColor();

                Console.Write("\ty coordinate (top): ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tRy = ");
                str = Console.ReadLine();
                double Ry = double.Parse(str);                                  // take the decimal value of the 'str' for 'Ry'
                Console.ResetColor();

                Console.Write("\twidth: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\t\tw = ");
                str = Console.ReadLine();
                double w = double.Parse(str);                                   // take the decimal value of the 'str' for 'w'
                Console.ResetColor();

                Console.Write("\theight: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\th = ");
                str = Console.ReadLine();
                double h = double.Parse(str);                                   // take the decimal value of the 'str' for 'h'
                Console.ResetColor();

                Console.WriteLine("\nInformation about the Point A(x,y):");

                Console.Write("\tx coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\tx = ");
                str = Console.ReadLine();
                double x = double.Parse(str);                                   // take the decimal value of the 'str' for 'x'
                Console.ResetColor();

                Console.Write("\ty coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\ty = ");
                str = Console.ReadLine();
                double y = double.Parse(str);                                   // take the decimal value of the 'str' for 'y'
                Console.ResetColor();

                bool result = (Math.Sqrt(Math.Pow(Ox - x, 2) + Math.Pow(Oy - y, 2)) < r) && !((x > Rx) && (x < Rx + w) && (y > Ry - h) && (y < Ry));

                Console.Write("\nThe point A({0},{1}) is within the circle K({2},{3},{4}) and out of the rectangle R({5},{6},{7},{8}): ", x, y, Ox, Oy, r, Rx, Ry, w, h);
                if (result == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(result + "!");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)                                                   // if there is an error the "Error message" is shown 
            {
                if (str == "end")                                               // we will exit if the 'side_a' is "end"
                {
                    break;
                }
                if (str == "")                                                  // if we press "Enter"
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