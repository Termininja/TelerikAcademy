//Task4: Write methods that calculate the surface of a triangle by given:
//       Side and an altitude to it; Three sides; Two sides and an angle between them.
//       Use System.Math.

using System;

class TriangleSurface
{
    static void Main()
    {
        Console.Write(@"Please, select some method:
  1 - Side and an altitude to it
  2 - Three sides
  3 - Two sides and an angle between them");

    Tasks:
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)                                        // to select some method
        {
            case ConsoleKey.D1: Choose(1); SideAndAltitude(); break;
            case ConsoleKey.D2: Choose(2); ThreeSides(); break;
            case ConsoleKey.D3: Choose(3); TwoSidesAndAngle(); break;
            default: Console.Write("\b \b"); goto Tasks;
        }
    }

    static void Choose(byte num)
    {
        Console.Write("\b \b\n\nYour choice was: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(num);
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    static void SideAndAltitude()
    {
    task1:
        try                                                     // looks for errors
        {
            Console.Write("a = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            decimal a = decimal.Parse(Console.ReadLine());      // reads a one side
            Console.ResetColor();
            Console.Write("h = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            decimal h = decimal.Parse(Console.ReadLine());      // reads the altitude to side 'a'
            Console.ResetColor();
            Console.Write("\nThe area is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("S = a.h /2 = {0}", a * h / 2);   // calculates the triangle area
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ResetColor();
            goto task1;                                         // repeats the task1 when there is some error
        }
    }

    static void ThreeSides()
    {
    task2:
        try                                                     // looks for errors
        {
            Console.Write("a = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double a = double.Parse(Console.ReadLine());        // reads the first side
            Console.ResetColor();
            Console.Write("b = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double b = double.Parse(Console.ReadLine());        // reads the second side
            Console.ResetColor();
            Console.Write("c = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double c = double.Parse(Console.ReadLine());        // reads the third side
            Console.ResetColor();
            Console.WriteLine("\nThe area is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nS = Sqrt[p.(p-a).(p-b).(p-c)], where p = (a+b+c)/2");

            double p = (a + b + c) / 2;
            Console.WriteLine("\nS = {0}", Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ResetColor();
            goto task2;                                         // repeats the task2 when there is some error
        }
    }

    static void TwoSidesAndAngle()
    {
    task3:
        try                                                     // looks for errors
        {
            Console.Write("a = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double a = double.Parse(Console.ReadLine());        // reads the first side
            Console.ResetColor();
            Console.Write("b = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double b = double.Parse(Console.ReadLine());        // reads the second side
            Console.ResetColor();
            Console.Write("alpha = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double alpha = double.Parse(Console.ReadLine());    //reads the angle between side 'a' and 'b'
            Console.ResetColor();
            Console.Write("\nThe area is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("S = a.b.sin(alpha)/2 = {0}", a * b * Math.Sin(Math.PI * alpha / 180) / 2);
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ResetColor();
            goto task3;                                         // repeats the task3 when there is some error
        }
    }
}
