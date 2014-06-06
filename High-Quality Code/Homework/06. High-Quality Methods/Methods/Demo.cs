namespace Methods
{
    using System;

    /// <summary>
    /// Demonstration of the class Methods.
    /// </summary>
    class Demo
    {
        static void Main()
        {
            Console.WriteLine(Methods.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(Methods.DigitToString(5));
            Console.WriteLine(Methods.FindMax(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintAsFixedPoint(1.3);
            Methods.PrintAsPercent(0.75);
            Methods.PrintRightWithAlignmentEight(2.30);

            Point p1 = new Point(3, -1);
            Point p2 = new Point(3, 2.5);

            Console.WriteLine("Distance: " + Methods.CalculateDistanceBetweenTwoPoints(p1, p2));
            Console.WriteLine("Horizontal? " + Methods.IsSomeLineHorizontal(p1, p2));
            Console.WriteLine("Vertical? " + Methods.IsSomeLineVertical(p1, p2));

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
