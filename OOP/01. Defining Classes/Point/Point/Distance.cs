namespace Point
{
    using System;

    public static class Distance
    {
        /// <summary>
        /// Calculates the distance between two points in the 3D space.
        /// </summary>
        /// <param name="a">The first point A.</param>
        /// <param name="b">The second point B.</param>
        /// <returns>Returns the distance between the points.</returns>
        public static double D(Point3D a, Point3D b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
        }
    }
}
