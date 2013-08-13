//Task7*: Write a program that calculates the value of given arithmetical expression.
//        The expression can contain the following elements only:
//        Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//        Arithmetic operators: +, -, *, / (standard priorities)
//        Mathematical functions: ln(x), sqrt(x), pow(x,y)
//        Brackets (for changing the default priorities)
//        Examples:
//              (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) → ~ 10.6
//              pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) → ~ 21.22
//        Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation"

using System;
using System.Collections.Generic;
using System.Threading;

class ArithmeticalExpression
{
    static bool LnSqrt = false;

    static void Main()
    {
        Console.WriteLine("Please, enter some arithmetical expression: ");
        Console.Write("Example: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("3/(1.2*5) - pow(3/8.9E-3 +ln(7/sqrt(12-2.3/4)), sqrt(25/4))*2 - 12");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n x = ");
        string E = Console.ReadLine();                      // reads the arithmetical expression
        Console.ResetColor();
        char[] Operators = { '*', '/', '+', '-' };

        E = E.Replace(',', '_');                            // replaces the ',' symbol with '_'
        E = E.Replace(" ", "");                             // removes the all empty intervals

        string check = "";
        while (E != check)                                  // it will finish when the result is a number
        {
            check = E;
            foreach (var item in Operators)                 // checks for each one operator
            {
                E = Calculate(E, item);                     // calculates *, /, + or -
                for (int i = 0; i < E.Length; i++)          // removes the brackets ( )
                {
                    E = Pow(E);                             // calculates the Pow function
                    LnSqrt = false;
                    if (E[i] == '(')                        // if the bracket is open
                    {
                        if (i > 0)
                        {
                            E = LnAndSqrt(E, i, 'n');       // calculates the Ln function
                            E = LnAndSqrt(E, i, 't');       // calculates the Sqrt function
                        }
                        if (!LnSqrt)                        // if Ln or Sqrt are used
                        {
                            double num = 0;
                            string temp = "";
                            for (int j = i + 1; j < E.Length; j++)
                            {
                                temp += E[j];

                                /* calculates the expression in the brackets */
                                if (double.TryParse(temp, out num) && E[j + 1] == ')')
                                {
                                    E = (E.Remove(i, 1)).Remove(j, 1);
                                    E = E.Replace("-+", "-");
                                    Thread.Sleep(1000);     // sleep for 1 second
                                    Console.WriteLine(" x = {0}", E.Replace('_', ','));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.Write("\n x = ");
        double R = 0;
        if (double.TryParse(E, out R))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(R.ToString("E2"));            // prints the result
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong expression!");         // if there is some error in expression
        }
        Console.ResetColor();
    }

    static string Pow(string E)
    {
        E = E.Replace("_+", "_");                           // replaces the "_+" with "_"
        for (int p = 0; p < E.Length; p++)
        {
            if (E[p] == '_')                                // looking for position of "_" (",")
            {
                bool available1, available2;                // are there two numbers in Pow function
                int before, after;                          // the positions before and after the "_" symbol
                double num1 = SearchNumber(E, p, out available1, out before, 0, p);
                double num2 = SearchNumber(E, p, out available2, out after, p + 1, E.Length);
                if (available1 && available2 && E[before - 1] == '(' && E[E.Length + p - after + 1] == ')')
                {
                    double result = Math.Pow(num1, num2);
                    E = (E.Remove(before - 4, E.Length + p - after - before + 6)).Insert(before - 4, result.ToString());
                    p = 0;
                    E = E.Replace("-+", "-");
                    Thread.Sleep(1000);
                    Console.WriteLine(" x = {0}", E.Replace('_', ','));
                }
            }
        }
        return E;                                           // returns the calculated Pow function
    }

    static string LnAndSqrt(string E, int i, char w)
    {
        if (E[i - 1] == w)                                  // is Ln or Sqrt function
        {
            byte word_len = 0;                              // the length of the function word
            double num = 0;
            string temp = "";
            for (int j = i + 1; j < E.Length; j++)
            {
                temp += E[j];
                if (double.TryParse(temp, out num) && E[j + 1] == ')')
                {
                    /* calculates the expression in the brackets */
                    double result = 0;
                    switch (w)
                    {
                        case 'n': result = Math.Log(num); word_len = 2; break;
                        case 't': result = Math.Sqrt(num); word_len = 4; break;
                        default: break;
                    }
                    E = (E.Remove(i - word_len, j - i + word_len + 2)).Insert(i - word_len, result.ToString());
                    E = E.Replace("-+", "-");
                    Thread.Sleep(1000);
                    Console.WriteLine(" x = {0}", E.Replace('_', ','));
                    LnSqrt = true;                          // Ln or Sqrt are used
                    break;
                }
            }
        }
        return E;                                           // returns the calculated Ln or Sqrt function
    }

    static string Calculate(string E, char symbol)
    {
        for (int i = 0; i < E.Length; i++)
        {
            if (E[i] == symbol)                             // looking for position of *, /, + or -
            {
                bool available1, available2;
                int before, after;
                double num1 = SearchNumber(E, i, out available1, out before, 0, i);
                double num2 = SearchNumber(E, i, out available2, out after, i + 1, E.Length);

                double result = 0;
                switch (symbol)
                {
                    case '*': result = num1 * num2; break;
                    case '/': result = num1 / num2; break;
                    case '+': result = num1 + num2; break;
                    case '-': result = num1 - num2; break;
                    default: break;
                }

                /* calculates the expression from *, /, + or - operators */
                if (available1 && available2)
                {
                    string sign = "";
                    sign = result > 0 ? "+" + result.ToString() : result.ToString();
                    E = (E.Remove(before, E.Length + i - after - before + 1)).Insert(before, sign);
                    i = 0;
                    E = E.Replace("-+", "-");
                    Thread.Sleep(1000);
                    Console.WriteLine(" x = {0}", E.Replace('_', ','));
                }
            }
        }
        return E;                                           // returns the result from calculations
    }

    static double SearchNumber(string E, int i, out bool available, out int limit, int start, int end)
    {
        available = false;                                  // is there some number
        double num = 0;                                     // the value of the number
        limit = 0;                                          // the length of the number
        for (limit = start; limit < end; limit++)
        {
            int k = start == 0 ? limit : start;

            if (double.TryParse(E.Substring(k, end - limit), out num))
            {
                available = true;                           // if the number is found
                if (E[i] == '+' || E[i] == '-')             // checks the priority of '*' and '/'
                {
                    if (i - (end - limit + 1) >= 0)
                    {
                        if (E[i - (end - limit + 1)] == '*' || E[i - (end - limit + 1)] == '/')
                        {
                            available = false;              // this number will not be used
                        }
                    }
                    if (i + (end - limit) + 1 < E.Length)
                    {
                        if (E[i + (end - limit) + 1] == '*' || E[i + (end - limit) + 1] == '/')
                        {
                            available = false;              // this number will not be used
                        }
                    }
                }
                break;
            }
        }
        return num;                                         // returns the value of the number
    }
}