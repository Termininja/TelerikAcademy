// Task 11-12: Write a method that adds two polynomials. Represent them as arrays of their
//             coefficients as in the example: x^2 + 5 = 1x^2 + 0x + 5 → 5 0 1
//             Extend the program to support also subtraction and multiplication of polynomials.

using System;

class Polynomials
{
    static void Main()
    {
        // Reads two polynomials
        int[] X = ReadPoly("1");
        PrintPoly("p1(x) = ", X);
        Console.WriteLine();
        int[] Y = ReadPoly("2");
        PrintPoly("p2(x) = ", Y);
        Console.WriteLine();

        // Prints the result from the sum
        PrintPoly("The sum is: ", SumPoly(X, Y));

        // Prints the result from the subtraction
        PrintPoly("The subtraction is: ", SubtractPoly(X, Y));

        // Prints the result from the multiplication
        PrintPoly("The multiplication is: ", MultiPoly(X, Y));
    }

    // Reads some polynomial
    static int[] ReadPoly(string str)
    {
        Console.Write("Please, enter the degree of polynomial p{0}(x): ", str);
        int degree = int.Parse(Console.ReadLine());

        int[] arr = new int[degree + 1];
        Console.WriteLine("Please, enter the coefficients of this polynomial:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} = ", (char)(97 + i));
            Console.ForegroundColor = ConsoleColor.Yellow;
            arr[i] = int.Parse(Console.ReadLine());
            Console.ResetColor();
        }
        return arr;
    }

    // Adds two polynomials
    static int[] SumPoly(int[] x, int[] y)
    {
        int maxLenght = Math.Max(x.Length, y.Length);
        int[] result = new int[maxLenght];
        for (int i = 0; i < maxLenght; i++)
        {
            result[i] = ((i < x.Length) ? x[i] : 0) + ((i < y.Length) ? y[i] : 0);
        }
        return result;
    }

    // Subtract two polynomials
    static int[] SubtractPoly(int[] x, int[] y)
    {
        int maxLenght = Math.Max(x.Length, y.Length);
        int[] result = new int[maxLenght];
        for (int i = 0; i < maxLenght; i++)
        {
            result[i] = ((i < x.Length) ? x[i] : 0) - ((i < y.Length) ? y[i] : 0);
        }
        return result;
    }

    // Multiply two polynomials
    static int[] MultiPoly(int[] x, int[] y)
    {
        int[] result = new int[x.Length + y.Length - 1];
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = 0; j < y.Length; j++)
            {
                result[i + j] += x[i] * y[j];
            }
        }
        return result;
    }

    // Prints some polynomial
    static void PrintPoly(string str, int[] p)
    {
        Console.Write(str);
        for (int i = p.Length - 1; i >= 0; i--)
        {
            if (p[i] != 0)
            {
                if (i < p.Length - 1) Console.Write(" + ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(p[i]);
                Console.ResetColor();
                Console.Write(".x^{0}", i);
            }
        }
        Console.WriteLine();
    }
}