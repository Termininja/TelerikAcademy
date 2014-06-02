using System;

namespace Methods
{
    static class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
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
                (semiPerimeter - a) *
                (semiPerimeter - b) *
                (semiPerimeter - c));

            return area;
        }

        static string DigitToString(int digit)
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

        static int FindMax(params int[] elements)
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

        static void PrintAsFixedPoint(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        static void PrintAsPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        static void PrintRightWithAlignmentEight(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        struct Point
        {
            public double X { get; private set; }
            public double Y { get; private set; }

            public Point(double x, double y)
                : this()
            {
                this.X = x;
                this.Y = y;
            }
        }

        static bool IsSomeLineHorizontal(Point point1, Point point2)
        {
            bool isHorizontal = point1.Y == point2.Y;

            return isHorizontal;
        }

        static bool IsSomeLineVertical(Point point1, Point point2)
        {
            bool isVertical = point1.X == point2.X;

            return isVertical;
        }

        static double CalculateDistanceBetweenTwoPoints(Point point1, Point point2)
        {
            double distance = Math.Sqrt(
                Math.Pow(point2.X - point1.X, 2) +
                Math.Pow(point2.Y - point1.Y, 2));

            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(DigitToString(5));
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFixedPoint(1.3);
            PrintAsPercent(0.75);
            PrintRightWithAlignmentEight(2.30);

            Point p1 = new Point(3, -1);
            Point p2 = new Point(3, 2.5);

            Console.WriteLine("Distance: " + CalculateDistanceBetweenTwoPoints(p1, p2));
            Console.WriteLine("Horizontal? " + IsSomeLineHorizontal(p1, p2));
            Console.WriteLine("Vertical? " + IsSomeLineVertical(p1, p2));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", };
            peter.BirthDate = new DateTime(1992, 03, 17);
            peter.OtherInfo = "From Sofia";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.BirthDate = new DateTime(1993, 11, 03);
            stella.OtherInfo = "From Vidin, gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
