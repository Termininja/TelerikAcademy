namespace Shapes
{
    abstract class Shape
    {
        // Properties
        public double Width { get; set; }
        public double Height { get; set; }

        // Constructor
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        // Method
        public double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
