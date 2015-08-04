/* 
 * Problem 1. Structure:
 *     Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
 *     Implement the ToString() to enable printing a 3D point.
 * 
 * Problem 2. Static read-only field:
 *     Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
 *     Add a static property to return the point O.
 * 
 * Problem 3. Static class:
 *     Write a static class with a static method to calculate the distance between two points in the 3D space.
 * 
 * Problem 4. Path:
 *     Create a class Path to hold a sequence of points in the 3D space.
 *     Create a static class PathStorage with static methods to save and load paths from a text file.
 *     Use a file format of your choice.
 */

namespace Point
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Prints the center of the coordinate system
            Console.WriteLine("The center of coordinate system is: O({0})", Point3D.O);

            // Creates some point A
            var pointA = new Point3D(3, 7, -2);
            Console.WriteLine("Point A ({0})", pointA);

            // Defines some list of points from a text file "input.txt"
            var points = PathStorage.LoadPath(@"..\..\input.txt");
            points.Add(new Point3D(4, 5, 6));

            // Prints the distance between two points in 3D space
            if (points.Count() >= 2)
            {
                Console.WriteLine("\nDistance between point B and point C: " + Distance.D(points.Points[0], points.Points[1]));
            }

            // Clears all points in the path
            points.Clear();

            // Saves the path with all points to a text file "output.txt"
            PathStorage.SavePath(points);

            points.Add(new Point3D(4, 5, 6));
            points.Add(new Point3D(7, 1, -6));
            points.Add(new Point3D(92, 54, 65));

            // Removes the 2nd point
            points.RemoveAt(1);

            PathStorage.SavePath(points);
        }
    }
}