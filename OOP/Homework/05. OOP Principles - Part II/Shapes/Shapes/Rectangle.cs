namespace Shapes
{
    class Rectangle : Shape
    {
        // Constructor
        public Rectangle(double width, double height) : base(width, height) { }

        // Method
        public double CalculateSurface()
        {
            return Width * Height;
        }
    }
}