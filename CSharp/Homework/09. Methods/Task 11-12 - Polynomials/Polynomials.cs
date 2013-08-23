//Task11-12: Write a method that adds two polynomials. Represent them as arrays of their
//           coefficients as in the example: x^2 + 5 = 1x^2 + 0x + 5 → 5 0 1
//           Extend the program to support also subtraction and multiplication of polynomials.

using System;

class Polynomials
{
    static void Main()
    {
        Console.Write("Please, enter the degree of the both polynoms: ");
        int[] X = new int[int.Parse(Console.ReadLine()) + 1];
        int[] Y = new int[X.Length];

        ReadArray(X, Y);                            // reads the both arrays

        int[] Sum = SumPoly(X, Y);                  // sum the both polynomials
        int[] Subtract = SubtractPoly(X, Y);        // subtract the both polynomials
        int[] Multi = MultiPoly(X, Y);              // multiplicate the both polynomials

        Print("The sum is: ", Sum);                 // prints the result of the sum
        Print("The subtraction is: ", Subtract);    // prints the result of the subtraction
        Print("The multiplication is: ", Multi);    // prints the result of the multiplication
    }

    static void Print(string str, int[] p)          // method which prints the result
    {
        Console.Write(str);
        for (int i = p.Length - 1; i >= 0; i--)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(p[i]);
            Console.ResetColor();
            Console.Write(".x^{0}", i);
            if (i > 0)                              // if this is not the last element
            {
                Console.Write(" + ");
            }
        }
        Console.WriteLine();
    }

    static int[] MultiPoly(int[] x, int[] y)
    {
        int[] mul = new int[x.Length];              // needed for the multiplication of arrays
        for (int i = 0; i < x.Length; i++)
        {
            mul[i] = x[i] * y[i];                   // gets the multiplication of the elements
        }
        return mul;                                 // returns the result
    }

    static int[] SubtractPoly(int[] x, int[] y)
    {
        int[] sub = new int[x.Length];              // needed for the subtraction of arrays
        for (int i = 0; i < x.Length; i++)
        {
            sub[i] = x[i] - y[i];                   // gets the subtraction of the elements
        }
        return sub;                                 // returns the result   
    }

    static int[] SumPoly(int[] x, int[] y)
    {
        int[] sum = new int[x.Length];              // needed for the sum of arrays
        for (int i = 0; i < x.Length; i++)
        {
            sum[i] = x[i] + y[i];                   // gets the sum of each elements in arrays
        }
        return sum;                                 // returns the result
    }

    static void ReadArray(int[] x, int[] y)
    {
        Console.WriteLine("Please, enter the coefficients of the 1st polynomial:");
        for (int i = 0; i < x.Length; i++)          // reads the 1st polynomial
        {
            Console.Write("x{0} = ", i);
            Console.ForegroundColor = ConsoleColor.Yellow;
            x[i] = int.Parse(Console.ReadLine());
            Console.ResetColor();
        }
        Console.WriteLine("Please, enter the coefficients of the 2nd polynomial:");
        for (int i = 0; i < x.Length; i++)          // reads the 2nd polynomial
        {
            Console.Write("y{0} = ", i);
            Console.ForegroundColor = ConsoleColor.Yellow;
            y[i] = int.Parse(Console.ReadLine());
            Console.ResetColor();
        }
    }
}