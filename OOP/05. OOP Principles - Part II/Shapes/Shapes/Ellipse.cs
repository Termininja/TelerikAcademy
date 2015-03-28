namespace Shapes
{
    using System;

    public class Ellipse : Rectangle
    {
        public Ellipse(double semimajorAxis, double semiminorAxis)
            : base(semimajorAxis, semiminorAxis) { }

        public override double CalculateSurface()
        {
            return Math.PI * base.Width * base.Height;
        }

        public override string ToString()
        {
            var result = string.Format("  semimajorAxis: {0:F}\n  semiminorAxis: {1:F}", base.Width, base.Height);

            return result;
        }
    }
}