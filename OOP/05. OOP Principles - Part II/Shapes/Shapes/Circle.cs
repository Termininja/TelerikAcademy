namespace Shapes
{
    public class Circle : Ellipse
    {
        public Circle(double radius)
            : base(radius, radius) { }

        public override string ToString()
        {
            var result = string.Format("  radius: {0:F}", base.Width);

            return result;
        }
    }
}