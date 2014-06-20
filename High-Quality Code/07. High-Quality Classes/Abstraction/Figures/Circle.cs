namespace Abstraction
{
    using System;

    /// <summary>
    /// Class circle of type figure.
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// The radius of the circle.
        /// </summary>
        private double radius;

        /// <summary>
        /// Initializes a new instance of class Circle.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid input data. Radius must be positive!");
                }
            }
        }

        /// <summary>
        /// Calculates the perimeter of the circle.
        /// </summary>
        /// <returns>Returns the perimeter.</returns>
        public double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of the circle.
        /// </summary>
        /// <returns>Returns the surface.</returns>
        public double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}