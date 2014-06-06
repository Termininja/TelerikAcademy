namespace Abstraction
{
    using System;

    public interface IFigure
    {
        /// <summary>
        /// Calculates the perimeter of the figure.
        /// </summary>
        /// <returns>Returns the calculated perimeter.</returns>
        double CalculatePerimeter();

        /// <summary>
        /// Calculates the surface of the figure.
        /// </summary>
        /// <returns>Returns the calculated surface.</returns>
        double CalculateSurface();
    }
}