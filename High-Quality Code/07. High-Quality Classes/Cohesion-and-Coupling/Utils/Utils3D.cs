namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Class for work with 3D figures.
    /// </summary>
    public class Utils3D
    {
        /// <summary>
        /// Calculate the distance between two points X(x1,y1,z1) and Y(x2,y2,z2).
        /// </summary>
        /// <param name="x1">The 'x' coordinate of the first point.</param>
        /// <param name="y1">The 'y' coordinate of the first point.</param>
        /// <param name="z1">The 'z' coordinate of the first point.</param>
        /// <param name="x2">The 'x' coordinate of the second point.</param>
        /// <param name="y2">The 'y' coordinate of the second point.</param>
        /// <param name="z2">The 'z' coordinate of the second point.</param>
        /// <returns>Returns the distance between both points.</returns>
        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));

            return distance;
        }

        /// <summary>
        /// Calculates the diagonal of some cuboid.
        /// </summary>
        /// <param name="width">The width of the cuboid.</param>
        /// <param name="height">The height of the cuboid.</param>
        /// <param name="depth">The depth of the cuboid.</param>
        /// <returns>Returns the diagonal of the cuboid.</returns>
        public static double CalculateDiagonalXYZ(double width, double height, double depth)
        {
            double distance = Math.Sqrt((width * width) + (height * height) + (depth * depth));

            return distance;
        }

        /// <summary>
        /// Calculates the volume of some cuboid.
        /// </summary>
        /// <param name="width">The width of the cuboid.</param>
        /// <param name="height">The height of the cuboid.</param>
        /// <param name="depth">The depth of the cuboid.</param>
        /// <returns>Returns the volume of the cuboid.</returns>
        public static double CalculateVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;

            return volume;
        }
    }
}