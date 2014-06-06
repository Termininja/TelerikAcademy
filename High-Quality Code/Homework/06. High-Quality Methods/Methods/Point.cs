﻿namespace Methods
{
    /// <summary>
    /// Structure of point.
    /// </summary>
    struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }
}
