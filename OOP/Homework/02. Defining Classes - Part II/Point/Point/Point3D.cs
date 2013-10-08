using System;

namespace Point
{
    public struct Point3D                       // creates a structure for 3D-coordinates {X, Y, Z}
    {
        // Fields
        private static readonly Point3D o;      // the start of the coordinate system

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

        // Methods
        public override string ToString()       // to enable printing a 3D point
        {
            return String.Format("{0},{1},{2}", this.X, this.Y, this.Z);
        }
    }
}