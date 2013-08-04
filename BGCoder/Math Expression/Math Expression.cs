using System;
 
class Problem1MathExpression
{
    static void Main()
    {
        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
 
        double Result = ((N * N + 1 / (M * P) + 1337) / (N - 128.523123123 * P)) + Math.Sin(Math.Truncate(M) % 180);
 
        Console.WriteLine("{0:F6}", Result);
    }
}