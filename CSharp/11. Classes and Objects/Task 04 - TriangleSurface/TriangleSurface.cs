//Task4: Write methods that calculate the surface of a triangle by given:
//       Side and an altitude to it; Three sides; Two sides and an angle between them.
//       Use System.Math.

using System;

public class TriangleSurface
{
    public static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            // Create user input menu
            Console.Clear();
            Console.Write(@"Please, select some method or press <ESC> to exit:
  [1]: Side and an altitude to it
  [2]: Three sides
  [3]: Two sides and an angle between them");

            Console.CursorVisible = false;
            ConsoleKeyInfo key = Console.ReadKey();
            Console.CursorVisible = true;
            switch (key.Key)
            {
                // The user choice
                case ConsoleKey.D1: Selected(1); SideAndAltitude(); break;
                case ConsoleKey.D2: Selected(2); ThreeSides(); break;
                case ConsoleKey.D3: Selected(3); TwoSidesAndAngle(); break;
                case ConsoleKey.Escape: exit = true; continue;
                default: Console.Write("\b \b"); continue;
            }
            Console.Write("\nPress any key to continue. . .");
            Console.ReadKey();
        }
    }

    // What was selected by user
    static void Selected(byte num)
    {
        Console.Write("\b \b\n\nYour choice was: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(num);
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    // First variant
    static void SideAndAltitude()
    {
        while (true)
        {
            try
            {
                // Read side and hight
                Console.Write("a = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                decimal a = decimal.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.Write("h = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                decimal h = decimal.Parse(Console.ReadLine());
                Console.ResetColor();

                // Calculate and print the triangle area
                Console.Write("\nThe area is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("S = a.h /2 = {0}", a * h / 2);
                Console.ResetColor();
            }
            catch (Exception)
            {
                // In error repeate the task
                Console.ResetColor();
                continue;
            }
            break;
        }
    }

    // Second variant
    static void ThreeSides()
    {
        while (true)
        {
            try
            {
                // Read three sides
                Console.Write("a = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double a = double.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.Write("b = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double b = double.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.Write("c = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double c = double.Parse(Console.ReadLine());
                Console.ResetColor();

                // Calculate and print the triangle area
                Console.WriteLine("\nThe area is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nS = Sqrt[p.(p-a).(p-b).(p-c)], where p = (a+b+c)/2");
                double p = (a + b + c) / 2;
                Console.WriteLine("\nS = {0}", Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
                Console.ResetColor();
            }
            catch (Exception)
            {
                // In error repeate the task
                Console.ResetColor();
                continue;
            }
            break;
        }
    }

    // Third variant
    static void TwoSidesAndAngle()
    {
        while (true)
        {
            try
            {
                // Read tho sides and angle
                Console.Write("a = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double a = double.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.Write("b = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double b = double.Parse(Console.ReadLine());
                Console.ResetColor();
                Console.Write("alpha = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double alpha = double.Parse(Console.ReadLine());
                Console.ResetColor();

                // Calculate and print the triangle area
                Console.Write("\nThe area is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("S = a.b.sin(alpha)/2 = {0}", a * b * Math.Sin(Math.PI * alpha / 180) / 2);
                Console.ResetColor();
            }
            catch (Exception)
            {
                // In error repeate the task
                Console.ResetColor();
                continue;
            }
            break;
        }
    }
}
