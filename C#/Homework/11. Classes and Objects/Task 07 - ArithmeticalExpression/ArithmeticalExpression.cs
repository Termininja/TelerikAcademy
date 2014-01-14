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

public class ArithmeticalExpression
{
    static bool isFunction = false;
    static char[] Operators = { '*', '/', '+', '-' };

    public static void Main()
    {
        try
        {
            // Reads some arithmetical expression
            Console.WriteLine("Please, write some arithmetical expression: ");
            Examples(1, "3/(1.2*5) - pow(3/8.9E-3 +ln(7/sqrt(12-2.3/4)), sqrt(25/4))*2 - 12");
            Examples(2, "1/cos(45*4) -tan(7-(3.1*7/sin(12-2.3/4)))/ sqrt(3/4.5-1.2)");
            Examples(3, "2*(3+(2-(7+(3/sqrt(9*(2+(7/(3*(sin(9*(3-(4/(3-4)))))))))))))-cot(-45)");
            Examples(4, "cot(sin(tan(ln(cos(sqrt(pow(sin(tan(ln(1))),1)))))))");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n x = ");
            string E = Console.ReadLine();
            Console.ResetColor();

            //  Removes all empty intervals and replace ',' with '_'
            E = E.Replace(" ", "").Replace(',', '_');
            E = E.Replace("sin", "v").Replace("cos", "x").Replace("tan", "y").Replace("cot", "z");

            string check = String.Empty;
            while (E != check)                                  // it will finish when the result is a number
            {
                check = E;
                foreach (var item in Operators)                 // checks for each one operator
                {
                    E = BasicArithmeticOperations(E, item);     // calculates *, /, + or -
                    for (int i = 0; i < E.Length; i++)          // removes the brackets ( )
                    {
                        E = PowFunction(E);                     // calculates the Square function
                        isFunction = false;
                        if (E[i] == '(')                        // if the bracket is open
                        {
                            if (i > 0)
                            {
                                E = Functions(E, i, 'n');       // calculates the Natural logarithm function
                                E = Functions(E, i, 't');       // calculates the Square root function
                                E = Functions(E, i, 'v');       // calculates the Sinus function
                                E = Functions(E, i, 'x');       // calculates the Cosinus function
                                E = Functions(E, i, 'y');       // calculates the Tangens function
                                E = Functions(E, i, 'z');       // calculates the Cotangens function
                            }

                            // if Ln or Sqrt are used
                            if (!isFunction) E = BracketsPriority(E, i);
                        }
                    }
                }
            }

            // Checks for NaN
            Console.Write("\n x = ");
            E = E.Contains("NaN") ? "NaN" : E;

            // Prints the result
            double R = 0;
            if (double.TryParse(E, out R))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(R.ToString("E2"));
            }
            else
            {
                // If there is some error in the expression
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong expression!");
            }
            Console.ResetColor();
        }
        catch (Exception)
        {
            // If there is some exception in the program
            Console.Write("\n x = ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong expression!");
            Console.ResetColor();
        }
    }

    static void Examples(int n, string s)
    {
        Console.Write("Example{0}: ", n);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(s);
        Console.ResetColor();
    }

    static string BracketsPriority(string E, int i)
    {
        double num = 0;
        string temp = "";
        for (int j = i + 1; j < E.Length; j++)
        {
            temp += E[j];

            // Calculates the expression in the brackets
            if (double.TryParse(temp, out num) && E[j + 1] == ')')
            {
                E = (E.Remove(i, 1)).Remove(j, 1);
                E = TempResult(E);
                break;
            }
        }
        return E;
    }

    static string PowFunction(string E)
    {
        E = E.Replace("_+", "_");                               // replaces the "_+" with "_"
        for (int p = 0; p < E.Length; p++)
        {
            if (E[p] == '_')                                    // looking for position of "_" (",")
            {
                bool available1, available2;                    // are there two numbers in Pow function
                int before, after;                              // the positions before and after the "_" symbol
                double num1 = SearchNumber(E, p, out available1, out before, 0, p);
                double num2 = SearchNumber(E, p, out available2, out after, p + 1, E.Length);
                if (available1 && available2 && E[before - 1] == '(' && E[E.Length + p - after + 1] == ')')
                {
                    double result = Math.Pow(num1, num2);
                    E = (E.Remove(before - 4, E.Length + p - after - before + 6)).Insert(before - 4, result.ToString());
                    p = 0;
                    E = TempResult(E);
                }
            }
        }
        return E;                                               // returns the calculated Pow function
    }

    static string Functions(string E, int i, char f)
    {
        if (!isFunction)
        {
            if (E[i - 1] == f)                                  // what is this function
            {
                byte word_len = 0;                              // the length of the function word
                double num = 0;
                string temp = "";
                for (int j = i + 1; j < E.Length; j++)
                {
                    temp += E[j];
                    if (double.TryParse(temp, out num) && E[j + 1] == ')')
                    {
                        // Calculates the expression in the brackets for the respective function
                        double result = 0;
                        switch (f)
                        {
                            case 'n': result = Math.Log(num); word_len = 2; break;
                            case 't': result = Math.Sqrt(num); word_len = 4; break;
                            case 'v': result = Math.Sin(num * Math.PI / 180); word_len = 1; break;
                            case 'x': result = Math.Cos(num * Math.PI / 180); word_len = 1; break;
                            case 'y': result = Math.Tan(num * Math.PI / 180); word_len = 1; break;
                            case 'z': result = 1 / Math.Tan(num * Math.PI / 180); word_len = 1; break;
                            default: break;
                        }
                        E = (E.Remove(i - word_len, j - i + word_len + 2)).Insert(i - word_len, result.ToString());
                        E = TempResult(E);
                        isFunction = true;                      // if some function is used
                        break;
                    }
                }
            }
        }
        return E;
    }

    static string BasicArithmeticOperations(string E, char symbol)
    {
        for (int i = 0; i < E.Length; i++)
        {
            if (E[i] == symbol)                                 // looking for position of *, /, + or -
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

                // Calculates the expression from *, /, + or - operators
                if (available1 && available2)
                {
                    string sign = "";
                    sign = result > 0 || result.ToString().Contains("NaN") ? "+" + result.ToString() : result.ToString();
                    E = (E.Remove(before, E.Length + i - after - before + 1)).Insert(before, sign);
                    i = 0;
                    E = TempResult(E);
                }
            }
        }
        return E;
    }

    static double SearchNumber(string E, int i, out bool available, out int limit, int start, int end)
    {
        available = false;                                      // is there some number
        double num = 0;                                         // the value of the number
        limit = 0;                                              // the length of the number
        for (limit = start; limit < end; limit++)
        {
            int k = start == 0 ? limit : start;

            if (double.TryParse(E.Substring(k, end - limit), out num))
            {
                available = true;                               // if the number is found
                if (E[i] == '+' || E[i] == '-')                 // checks the priority of '*' and '/'
                {
                    // This number will not be used
                    int temp = end - limit + 1;
                    if (((i - temp >= 0 && start < i) && (E[i - temp] == '*' || E[i - temp] == '/')) ||
                        ((i + temp < E.Length && start > i) && (E[i + temp] == '*' || E[i + temp] == '/')))
                    {
                        available = false;
                    }
                }
                break;
            }
        }
        return num;
    }

    static string TempResult(string E)
    {
        E = E.Replace("-+", "-");
        Thread.Sleep(500);
        Console.WriteLine(" x = {0}", E.Replace('_', ',').Replace("v", "sin").Replace("x", "cos").Replace("y", "tan").Replace("z", "cot"));
        return E;
    }
}