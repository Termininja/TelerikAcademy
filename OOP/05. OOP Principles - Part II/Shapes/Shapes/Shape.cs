namespace Shapes
{
    public abstract class Shape
    {
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        abstract public double GetSurface();
    }
}
