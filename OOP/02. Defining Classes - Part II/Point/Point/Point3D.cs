using System;

namespace Point
{
    // Creates a structure for 3D-coordinates {X, Y, Z}
    public struct Point3D
    {
        // The start of the coordinate system
        private static readonly Point3D o;

        // Constructors
        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public static Point3D O
        {
            get { return o; }
        }

        // Prints a 3D point
        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.X, this.Y, this.Z);
        }
    }
}