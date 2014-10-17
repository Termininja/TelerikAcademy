//Task 1: Refactor the following code to use proper variable naming and simplified expressions

namespace Rectangle
{
    using System;

    public class Rectangle
    {
        /// <summary>
        /// Initializes a new instance of class rectangle.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Rotate some rectangle figure
        /// </summary>
        /// <param name="rectangle">An instance of rectangle.</param>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>Returns an rotated rectangle</returns>
        public static Rectangle Rotate(Rectangle rectangle, double angle)
        {
            double sinus = Math.Abs(Math.Sin(angle));
            double cosinus = Math.Abs(Math.Cos(angle));

            return new Rectangle(
                cosinus * rectangle.Width + sinus * rectangle.Height,
                sinus * rectangle.Width + cosinus * rectangle.Height);
        }

        /// <summary>
        /// Prints the width and height values of the rectangle like string.
        /// </summary>
        /// <returns>Returns the width and height values like string.</returns>
        public override string ToString()
        {
            string result = String.Format("Width: {0}; Height: {1}", this.Width, this.Height);

            return result;
        }
    }
}