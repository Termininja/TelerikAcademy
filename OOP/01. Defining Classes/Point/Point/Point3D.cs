namespace Point
{
    using System;

    /// <summary>
    /// Creates a structure for 3D-coordinates {X, Y, Z}.
    /// </summary>
    public struct Point3D
    {
        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public static Point3D O { get; private set; }

        // Prints a 3D point
        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.X, this.Y, this.Z);
        }
    }
}