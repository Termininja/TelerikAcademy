using System;

namespace Point
{
    static class Distance
    {
        // Calculate the distance between two points in the 3D space
        public static double D(Point3D a, Point3D b)
        {
            return
                Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2) +
                Math.Pow(a.Z - b.Z, 2)
                );
        }
    }
}
