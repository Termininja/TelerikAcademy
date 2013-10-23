namespace Shapes
{
    class Triangle : Shape
    {
        // Constructor
        public Triangle(double side, double height) : base(side, height) { }

        // Method
        public double CalculateSurface()
        {
            return (Width * Height) / 2;
        }
    }
}