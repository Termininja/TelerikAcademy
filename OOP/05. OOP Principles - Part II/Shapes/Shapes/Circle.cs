using System;

namespace Shapes
{
    class Circle : Shape
    {
        // Constructor
        public Circle(double radius) : base(radius, radius) { }

        // Return the surface of the circle
        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow(Width, 2);
        }

        // Override to string method
        public override string ToString()
        {
            return String.Format("  radius: {0:F}", Width);
        }
    }
}