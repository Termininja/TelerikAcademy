using System;

namespace Shapes
{
    class Circle : Shape
    {
        // Constructor
        public Circle(double radius) : base(radius, radius) { }

        // Method
        public double CalculateSurface()
        {
            return Math.PI * Math.Pow(Width, 2);
        }
    }
}