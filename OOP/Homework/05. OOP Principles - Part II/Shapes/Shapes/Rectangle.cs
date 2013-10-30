using System;

namespace Shapes
{
    class Rectangle : Shape
    {
        // Constructor
        public Rectangle(double width, double height) : base(width, height) { }

        // Return the surface of the rectangle
        public override double CalculateSurface()
        {
            return Width * Height;
        }

        // Override to string method
        public override string ToString()
        {
            return String.Format("  width: {0:F}\n  height: {1:F}", Width, Height);
        }
    }
}