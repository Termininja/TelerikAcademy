namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, radius) { }

        public override double GetSurface()
        {
            return Math.PI * Math.Pow(base.Width, 2);
        }

        public override string ToString()
        {
            var result = String.Format("  radius: {0:F}", base.Width);

            return result;
        }
    }
}