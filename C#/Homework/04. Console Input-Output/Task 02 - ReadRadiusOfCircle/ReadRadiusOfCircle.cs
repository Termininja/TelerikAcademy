//Task 2: Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;

class ReadRadiusOfCircle
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Please, enter the radius of the circle: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("r = ");
            string str = Console.ReadLine();
            Console.ResetColor();
            double radius = 0;
            if (double.TryParse(str, out radius) & radius > 0)
            {
                Console.Write("\nThe perimeter of the circle is:\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Math.Round(2 * Math.PI * radius, 2));
                Console.ResetColor();

                Console.Write("\nThe area of the circle is:\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Math.Round(Math.PI * Math.Pow(radius, 2), 2));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something's wrong!");                        // this message will be shown when there is some error
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\nPress Enter to continue, or X to exit . . .");
        key:
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.X)                                        // you will exit if you press "X"
            {
                break;
            }
            else if (key.Key != ConsoleKey.Enter)                               // you will continue only when you press "Enter"
            {
                Console.Write("\b \b");                                         // clear the wrong keys from the console
                goto key;
            }
            Console.ResetColor();
            Console.Clear();
        }
    }
}