/* 
 * Task 01: Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
 *          Implement the ToString() to enable printing a 3D point.
 * 
 * Task 02: Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
 *          Add a static property to return the point O.
 * 
 * Task 03: Write a static class with a static method to calculate the distance between two points in the 3D space.
 * 
 * Task 04: Create a class Path to hold a sequence of points in the 3D space.
 *          Create a static class PathStorage with static methods to save and load paths from a text file.
 *          Use a file format of your choice.
 */

using System;

namespace Point
{
    class TestProgram
    {
        static void Main()
        {
            // Prints the center of coordinate system
            Console.WriteLine("The center of coordinate system is: O({0})", Point3D.O);

            // Creates some point A
            Point3D pointA = new Point3D(3, 7, -2);
            Console.WriteLine("Point A ({0})", pointA);

            // Define some list of points from a file
            Path points = PathStorage.LoadPath(@"..\..\input.txt");
            points.Add(new Point3D(4, 5, 6));           // adding a new point

            // Prints the distance between two points in 3D space
            if (points.Count() >= 2)
            {
                Console.WriteLine("\nDistance between point B and point C: " + Distance.D(points.Points[0], points.Points[1]));
            }

            points.Clear();                             // clear the all points in the path

            // Save the path with all points to a text file "output.txt"
            PathStorage.SavePath(points);

            points.Add(new Point3D(4, 5, 6));
            points.Add(new Point3D(7, 1, -6));
            points.Add(new Point3D(92, 54, 65));

            points.RemoveAt(1);                 // removes the 2nd point

            PathStorage.SavePath(points);
        }
    }
}