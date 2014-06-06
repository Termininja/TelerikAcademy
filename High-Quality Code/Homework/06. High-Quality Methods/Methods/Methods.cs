namespace Methods
{
    using System;

    /// <summary>
    /// Some set of methods.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Calculates the area of some triangle.
        /// </summary>
        /// <param name="a">Side of the triangle.</param>
        /// <param name="b">Side of the triangle.</param>
        /// <param name="c">Side of the triangle.</param>
        /// <returns>Returns the triangle area.</returns>
        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("All sides should be positive!");
            }

            if (a > b + c || b > c + a || c > a + b)
            {
                throw new ArgumentException("It's not possible to be form triangle with these sides!");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter *
                (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }

        /// <summary>
        /// Turns some digit to his string name.
        /// </summary>
        /// <param name="digit">The digit.</param>
        /// <returns>Returns the name of the digit.</returns>
        internal static string DigitToString(int digit)
        {
            if (digit < 0 || 9 < digit)
            {
                throw new ArgumentOutOfRangeException("The digit must be from 0 to 9!");
            }

            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("This is not a digit!");
            }
        }

        /// <summary>
        /// Find the maximal element in some array of numbers.
        /// </summary>
        /// <param name="elements">The array of integer elements.</param>
        /// <returns>Returns the maximal element in array.</returns>
        internal static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Elements must not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Needs at least one element!");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// Prints some number as fixed point.
        /// </summary>
        /// <param name="number">The number.</param>
        internal static void PrintAsFixedPoint(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        /// <summary>
        /// Print some number as percent.
        /// </summary>
        /// <param name="number">The number.</param>
        internal static void PrintAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        /// <summary>
        /// Prints some number with right alignment in width eight.
        /// </summary>
        /// <param name="number">The number.</param>
        internal static void PrintRightWithAlignmentEight(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        /// <summary>
        /// Checks if some line is horizontal.
        /// </summary>
        /// <param name="point1">The first point of the line.</param>
        /// <param name="point2">The second point of the line.</param>
        /// <returns>Returns true or false.</returns>
        internal static bool IsSomeLineHorizontal(Point point1, Point point2)
        {
            bool isHorizontal = point1.Y == point2.Y;

            return isHorizontal;
        }

        /// <summary>
        /// Checks if some line is vertical.
        /// </summary>
        /// <param name="point1">The first point of the line.</param>
        /// <param name="point2">The second point of the line.</param>
        /// <returns>Returns true or false.</returns>
        internal static bool IsSomeLineVertical(Point point1, Point point2)
        {
            bool isVertical = point1.X == point2.X;

            return isVertical;
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <returns>Returns the distance between both points.</returns>
        internal static double CalculateDistanceBetweenTwoPoints(Point point1, Point point2)
        {
            double distance = Math.Sqrt(
                Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));

            return distance;
        }
    }
}
