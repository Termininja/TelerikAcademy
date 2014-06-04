namespace Rectangle
{
    using System;

    /// <summary>
    /// Demonstration of class Rectangle
    /// </summary>
    class Demo
    {
        static void Main()
        {
            double width = 200;
            double height = 30;
            Rectangle rectangle = new Rectangle(width, height);
            Console.WriteLine("Rectangle: {0}", rectangle);

            double angleInDegrees = 90;
            double angleInRadians = angleInDegrees * Math.PI / 180;
            Rectangle rotatedRectangle = Rectangle.Rotate(rectangle, angleInRadians);
            Console.WriteLine("Rotated rectangle: {0}", rotatedRectangle);
        }
    }
}
