﻿//Task 03. Take the VS solution "Cohesion-and-Coupling" and refactor its code to follow
//the principles of good abstraction, loose coupling and strong cohesion. Split the class
//Utils to other classes that have strong cohesion and are loosely coupled internally.

namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Demonstration of class Utils, Utils2D and Utils3D.
    /// </summary>
    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(Utils.GetFileExtension("example"));
            Console.WriteLine(Utils.GetFileExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(Utils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Utils2D.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Utils3D.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume = {0:f2}", Utils3D.CalculateVolume(9, 7, 4));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils3D.CalculateDiagonalXYZ(3, 4, 5));
            Console.WriteLine("Diagonal XY = {0:f2}", Utils2D.CalculateDiagonal(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils2D.CalculateDiagonal(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils2D.CalculateDiagonal(4, 5));
        }
    }
}