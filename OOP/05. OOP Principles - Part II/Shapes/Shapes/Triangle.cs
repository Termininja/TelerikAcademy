namespace Shapes
{
    using System;

    public class Triangle : Shape
    {
        public Triangle(double side, double height)
            : base(side, height) { }

        public override double GetSurface()
        {
            return (base.Width * base.Height) / 2;
        }

        public override string ToString()
        {
            var result = String.Format("  side: {0:F}\n  height: {1:F}", base.Width, base.Height);

            return result;
        }
    }
}