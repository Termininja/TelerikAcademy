namespace Shapes
{
    public class Square : Rectangle
    {
        public Square(double side)
            : base(side, side) { }

        public override string ToString()
        {
            var result = string.Format("  side: {0:F}", base.Width);

            return result;
        }
    }
}