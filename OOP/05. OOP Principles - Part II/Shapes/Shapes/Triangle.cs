using System;

namespace Shapes
{
    class Triangle : Shape
    {
        // Constructor
        public Triangle(double side, double height) : base(side, height) { }

        // Return the surface of the triangle
        public override double CalculateSurface()
        {
            return (Width * Height) / 2;
        }

        // Override to string method
        public override string ToString()
        {
            return String.Format("  side: {0:F}\n  height: {1:F}", Width, Height);
        }
    }
}