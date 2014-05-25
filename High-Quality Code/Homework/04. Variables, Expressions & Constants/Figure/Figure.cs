//Task 1: Refactor the following code to use proper variable naming and simplified expressions

using System;

public class Figure
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Figure(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public static Figure Rotate(Figure figure, double angle)
    {
        double sinus = Math.Abs(Math.Sin(angle));
        double cosinus = Math.Abs(Math.Cos(angle));

        return new Figure(
            cosinus * figure.Width + sinus * figure.Height,
            sinus * figure.Width + cosinus * figure.Height);
    }
}