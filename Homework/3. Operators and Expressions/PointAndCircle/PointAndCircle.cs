//Task 6: Write an expression that checks if given point (x, y) is within a circle K(O, 5).

using System;

class PointAndCircle
{
    static void Main()
    {
        /*Short variant*/
        //decimal x = 3.5m;
        //decimal y = -12.8m;
        //bool result = (x * x + y * y) <= 5 * 5;

        /*Long variant*/
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("This program compares the position of some point A(x,y) with the position of arbitrary circle K(Ox,Oy,r).");
        Console.WriteLine("You can exit at any time by typing \"end\".");
        Console.ResetColor();
        Console.Write("\nPress some key to continue . . .");
        Console.ReadKey();
        Console.Clear();
        for (int i = 0; ; i++)
        {
            try                                                                 // this checks for some errors (for example if we write some string)
            {
                Console.WriteLine("Information about the Circle K(Ox,Oy,r):");

                Console.Write("\tx coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 25;
                Console.Write("Ox = ");
                dynamic string_Ox = Console.ReadLine();                          // here we can type the 'Ox' value or "end"
                if (string_Ox == "end")                                          // we will exit if the 'string_Ox' is "end"
                {
                    break;
                }
                double Ox = double.Parse(string_Ox);                              // take the value of the 'string_Ox'
                Console.ResetColor();

                Console.Write("\ty coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 25;
                Console.Write("Oy = ");
                dynamic string_Oy = Console.ReadLine();                          // here we can type the 'Oy' value or "end"
                if (string_Oy == "end")                                          // we will exit if the 'string_Oy' is "end"
                {
                    break;
                }
                double Oy = double.Parse(string_Oy);                              // take the value of the 'string_Oy'
                Console.ResetColor();

                Console.Write("\tradius: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 25;
                Console.Write("r = ");
                dynamic string_r = Console.ReadLine();                          // here we can type the 'r' value or "end"
                if (string_r == "end")                                          // we will exit if the 'string_r' is "end"
                {
                    break;
                }
                double r = double.Parse(string_r);                              // take the value of the 'string_r'
                Console.ResetColor();

                Console.WriteLine("\nInformation about the Point A(x,y):");

                Console.Write("\tx coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 25;
                Console.Write("x = ");
                dynamic string_x = Console.ReadLine();                          // here we can type the 'x' value or "end"
                if (string_x == "end")                                          // we will exit if the 'string_x' is "end"
                {
                    break;
                }
                double x = double.Parse(string_x);                              // take the value of the 'string_x'
                Console.ResetColor();

                Console.Write("\ty coordinate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 25;
                Console.Write("y = ");
                dynamic string_y = Console.ReadLine();                          // here we can type the 'y' value or "end"
                if (string_y == "end")                                          // we will exit if the 'string_y' is "end"
                {
                    break;
                }
                double y = double.Parse(string_y);                              // take the value of the 'string_y'
                Console.ResetColor();

                double D = Math.Sqrt(Math.Pow(Ox - x, 2) + Math.Pow(Oy - y, 2));  // the distance from point A to the center of the circle

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nThe point A({0},{1}) is ", x, y);
                if (D < r)                                                      // if the point is within the circle
                {
                    Console.Write("within");
                }
                else
                {
                    if (D > r)                                                  // if the point is without the circle
                    {
                        Console.Write("out of");
                    }
                    else                                                        // if the point is on the circle
                    {
                        Console.Write("on");
                    }
                }
                Console.Write(" the circle K({0},{1},{2})!", Ox, Oy, r);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)                                                   // if there is an error the "Error message" is shown 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");
                Console.ResetColor();
            }
        }
    }
}