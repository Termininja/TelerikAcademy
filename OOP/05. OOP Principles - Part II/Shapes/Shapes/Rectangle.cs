namespace Shapes
{
    using System;

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height) { }

        public override double GetSurface()
        {
            return base.Width * base.Height;
        }

        public override string ToString()
        {
            var result = String.Format("  width: {0:F}\n  height: {1:F}", base.Width, base.Height);

            return result;
        }
    }
}