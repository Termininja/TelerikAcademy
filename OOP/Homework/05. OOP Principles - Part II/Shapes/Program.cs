/* Task 01.
 * Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
 * Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure:
 *      height * width → for rectangle
 *      height * width / 2 → for triangle
 * Define class Circle and suitable constructor so that at initialization height must be kept equal to width
 * and implement the CalculateSurface() method. Write a program that tests the behaviour of the CalculateSurface()
 * method for different shapes (Circle, Rectangle, Triangle) stored in an array.
 */

using System;
using System.Threading;

namespace Shapes
{
    public class Program
    {
        public static void Main()
        {
            // Testing
            while (true)
            {
                // Create an array from shapes
                Shape[] shapes = new Shape[3];

                // Fill the array with different shapes by random generator
                Random generator = new Random();
                shapes[0] = new Rectangle(generator.NextDouble() * 10, generator.NextDouble() * 10);
                shapes[1] = new Triangle(generator.NextDouble() * 10, generator.NextDouble() * 10);
                shapes[2] = new Circle(generator.NextDouble() * 10);

                // Print the result
                foreach (Shape shape in shapes)
                {
                    // Print the input data for every shape
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", shape.GetType().Name);
                    Console.ResetColor();
                    Console.WriteLine(shape);

                    // Print the calculated surface
                    Console.Write("  surface: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0:F}\n", shape.CalculateSurface());
                    Console.ResetColor();
                }

                // Print the menu
                Console.Write("\nPress "); Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("<"); Console.ResetColor();
                Console.Write("ESC"); Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(">"); Console.ResetColor();
                Console.Write(" to exit or any other key to continue the test . . .");

                // Read some input key
                if (Console.ReadKey().Key != ConsoleKey.Escape) Console.Clear();
                else break;
            }
        }
    }
}