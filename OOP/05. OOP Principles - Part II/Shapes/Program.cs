/* 
 * Problem 1. Shapes:
 *      Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
 *      
 *      Define two new classes Triangle and Rectangle that implement the virtual method and return
 *      the surface of the figure (heightwidth for rectangle and heightwidth/2 for triangle).
 *      
 *      Define class Square and suitable constructor so that at initialization height must be kept
 *      equal to width and implement the CalculateSurface() method.
 *      
 *      Write a program that tests the behaviour of the CalculateSurface() method
 *      for different shapes (Square, Rectangle, Triangle) stored in an array.
 */

namespace Shapes
{
    using System;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                var random = new Random();

                // Fill the array with different shapes by random generator
                var shapes = new Shape[]{
                    new Rectangle(random.NextDouble() * 10, random.NextDouble() * 10),
                    new Triangle(random.NextDouble() * 10, random.NextDouble() * 10),
                    new Circle(random.NextDouble() * 10)
                };

                // Prints the result
                foreach (var shape in shapes)
                {
                    // Prints the input data for every shape
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", shape.GetType().Name);
                    Console.ResetColor();
                    Console.WriteLine(shape);

                    // Prints the calculated surface
                    Console.Write("  surface: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0:F}\n", shape.GetSurface());
                    Console.ResetColor();
                }

                // Prints the menu
                Console.Write("\nPress "); Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("<"); Console.ResetColor();
                Console.Write("Esc"); Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(">"); Console.ResetColor();
                Console.Write(" to exit or any other key to continue the test . . .");

                // Reads some input key
                if (Console.ReadKey().Key != ConsoleKey.Escape) Console.Clear();
                else break;
            }
        }
    }
}