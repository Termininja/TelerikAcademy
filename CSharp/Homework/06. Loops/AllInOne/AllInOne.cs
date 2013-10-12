using System;
using System.Numerics;
using System.Threading;
using System.Collections.Generic;

class AllTasks
{
    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 34;
        string task = null;
        Console.SetCursorPosition(47, 10);
        Console.Write("Welcome!");
        Thread.Sleep(2000);
        Console.Clear();
        while (true)
        {
            Contents();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("   Please, enter a task number from 1 to 14 or type \"exit\" to exit: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            task = Console.ReadLine();
            Console.Clear();
            switch (task)
            {
                case "1": Tasks(1); break;
                case "2": Tasks(2); break;
                case "3": Tasks(3); break;
                case "4": Tasks(4); break;
                case "5": Tasks(5); break;
                case "6": Tasks(6); break;
                case "7": Tasks(7); break;
                case "8": Tasks(8); break;
                case "9": Tasks(9); break;
                case "10": Tasks(10); break;
                case "11": Tasks(11); break;
                case "12": Tasks(12); break;
                case "13": Tasks(13); break;
                case "14": Tasks(14); break;
                case "exit": Exit(); break;
            }
        }
    }

    static void Contents()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n   Homework 6. Loops");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Write a program that prints all the numbers from 1 to N.
      Task 2: Write a program that prints all the numbers from 1 to N, that are not divisible
              by 3 and 7 at the same time.
      Task 3: Write a program that reads from the console a sequence of N integer numbers and
              returns the minimal and maximal of them.
      Task 4: Write a program that calculates N!/K! for given N and K (1 < K < N).
      Task 5: Write a program that calculates N!*K! / (K-N)! for given N and K (1 < N < K).
      Task 6: Write a program that, for a given 2 integer numbers N and X, calculates the sum
              S = 1 + 1!/X + 2!/X^2 + … + N!/X^N
      Task 7: Write a program that reads a number N and calculates the sum of first N members
              of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...
      Task 8: Write a program that calculates the greatest common divisor of given 2 numbers.
              Use the Euclidean algorithm (find it in Internet).
      Task 9: The same like task 10: The Catalan numbers are calculated by the next formula:
              Cn = (2n)! / (n+1)! n!, for n >= 0. Write a program that calculate N-th Catalan
              number by given N.
     Task 11: Write a program that prints all possible cards from a standard deck of 52 cards
              with their English names. Use nested for loops and switch-case.
     Task 12: Write a program that reads from the console a positive integer number N < 20
              and outputs a matrix like:              N = 3 →  1 2 3             
                                                               2 3 4             
                                                               3 4 5             
     Task 13: Write a program that calculates for number N how many trailing 0 present at the
              end of the N! Example: N=10→N!=3628800→2; Does your program work for N = 50000?
              Hint: The trailing 0 in N! are equal to the number of its prime divisors of 5.
     Task 14: Write a program that reads a positive integer number N (N < 20) from console
              and outputs in the console the numbers 1,N numbers arranged as a spiral.
                         ");
    }

    static void Tasks(int choose)
    {
    start: try
        {
            Console.ResetColor();
            Console.Clear();
            switch (choose)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
                case 8: Task8(); break;
                case 9: Task9(); break;
                case 10: Task10(); break;
                case 11: Task11(); break;
                case 12: Task12(); break;
                case 13: Task13(); break;
                case 14: Task14(); break;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\nThis was the end of the program.\nPress ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Enter");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" to try again or ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Esc");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" to go to Main Menu . . .");
        keys:
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                goto start;
            }
            if (key.Key != ConsoleKey.Escape)
            {
                Console.Write("\b \b");
                goto keys;
            }
            Console.Clear();
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\nYou made something wrong!\nPress any key to try again . . .");
            Console.ReadKey();
            Console.Clear();
            goto start;
        }
    }

    static void Task1()
    {
        Console.Write("Please, enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());                      // reads the limit number
        Console.ResetColor();
        if (N > 0)                                                  // if the number is positive
        {
            Console.Write("\nAll numbers from 1 to N are: ");
            for (int n = 1; n <= N; n++)                            // all numbers from 1 to N
            {
                Thread.Sleep(50);                                   // the program will sleep for 50ms
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(n);                                   // prints the number
                Console.ResetColor();
                if (n < N)                                          // without comma after the last number 
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
        else                                                        // if the number is not positive
        {
            throw new Exception();                                  // generates a new exception
        }
    }
    static void Task2()
    {
        Console.Write("Please, enter some number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());                          // reads the limit number
        Console.ResetColor();
        if (N > 0)                                                      // if the number is positive
        {
            Console.Write("\nThe numbers not divisible by 3 and 7 at the same time are: ");
            for (int n = 1; n <= N; n++)                                // all numbers from 1 to N
            {
                Thread.Sleep(50);                                       // the program will sleep for 50ms
                if (!(n % 3 == 0 && n % 7 == 0))                        // the numbers not devisible by 3 and 7
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(n);                                   // prints the number
                    Console.ResetColor();
                    if (n < N)                                          // without comma after the last number 
                    {
                        Console.Write(", ");
                    }
                }
            }
            Console.WriteLine();
        }
        else                                                            // if the number is not positive
        {
            throw new Exception();                                      // generates an exception
        }
    }
    static void Task3()
    {
        Console.Write("How many numbers you want to compare?");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\n   N = ");
        int N = int.Parse(Console.ReadLine());                              // the limit of compared numbers
        Console.ResetColor();
        byte len = (byte)(N.ToString().Length);                             // the maximal length of each number
        if (N > 0)
        {
            Console.WriteLine("\nPlease, enter {0} integer numbers:", N);
            int min = 0;
            int max = 0;
            byte w = 0;                                                     // the width where will be placed the number
            byte h = 0;                                                     // the height where will be placed the number
            for (int i = 1; i <= N; i++)                                    // reads N numbers
            {
                w++;
                switch (w)
                {
                    case 1:                                                 // here is the 1st column
                        Console.SetCursorPosition(3, 6 + h);
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0')); break;
                    case 2:                                                 // here is the 2nd column
                        Console.SetCursorPosition(30, 6 + h);
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0')); break;
                    case 3:                                                 // here is the 3rd column
                        Console.SetCursorPosition(57, 6 + h);
                        Console.Write("number {0} = ", Convert.ToString(i).PadLeft(len, '0'));
                        w = 0;
                        h++;
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int number = int.Parse(Console.ReadLine());                 // reads the current number
                Console.ResetColor();
                if (i == 1)
                {
                    min = number;
                    max = number;
                }
                if (number > max)                                           // if the number is maximal
                {
                    max = number;
                }
                if (number < min)                                           // if the number is minimal
                {
                    min = number;
                }
            }
            Console.Write("\nThe maximal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(max);                                         // this is the sum at the end
            Console.ResetColor();
            Console.Write("The minumal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(min);                                         // this is the sum at the end
            Console.ResetColor();
        }
        else                                                                // if the number is not positive
        {
            throw new Exception();                                          // generates an exception
        }
    }
    static void Task4()
    {
        Console.WriteLine("Please, enter two positive integer numbers N and K < N:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        Console.Write("   K = ");
        ulong K = ulong.Parse(Console.ReadLine());
        if (K < N && K > 1)
        {
            double result = 1;                                      // we can use BigInteger also
            for (ulong i = N; i >= K + 1; i--)                      // production from N to K+1
            {
                result *= i;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   N!       N.(N-1)...2.1");
            Console.WriteLine(" ────── = ───────────────── = N.(N-1)...(K+1) = {0}", result);
            Console.WriteLine("   K!       K.(K-1)...2.1");
            Console.ResetColor();
        }
        else throw new Exception();                                	// generates an exception
    }
    static void Task5()
    {
        Console.WriteLine("Please, enter two positive integer numbers N and K > N:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        Console.Write("   K = ");
        ulong K = ulong.Parse(Console.ReadLine());
        if (N < K && N > 1)
        {
            BigInteger result = 1;
            for (ulong k = K; k >= K - N + 1; k--)                  // production of K to K-N+1
            {
                result *= k;
            }
            result *= TaskMethods.Factorial(N);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   K!N!");
            Console.WriteLine(" ──────── = N!.K.(K-1)...(K-N+1) = {0}", (double)result);
            Console.WriteLine("  (K-N)!");
            Console.ResetColor();
        }
        else
        {
            throw new Exception();                                  // generates an exception
        }
    }
    static void Task6()
    {
        Console.WriteLine("Please, enter two integer numbers N and X:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        ulong N = ulong.Parse(Console.ReadLine());
        if (N > 0)
        {
            Console.Write("   X = ");
            long X = long.Parse(Console.ReadLine());
            decimal sum = 1;                                        // our sum start from 1
            for (uint i = 1; i <= N; i++)                           // each one addend N!/X^N
            {
                ulong factorial = 1;
                for (ulong f = i; f > 1; f--)                       // calculates the numerator N!
                {
                    factorial *= f;
                }
                sum += factorial / (decimal)Math.Pow(X, i);         // the sum result
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n          1!    2!          N!");
            Console.WriteLine(" S = 1 + ─── + ─── + ... + ─── = {0:0.00}", sum);
            Console.WriteLine("         X^1   X^2         X^N");
            Console.ResetColor();
        }
        else
        {
            throw new Exception();                                  // generates an exception
        }
    }
    static void Task7()
    {
        Console.Write("Please, enter some positive integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        ulong N = ulong.Parse(Console.ReadLine());
        Console.ResetColor();
        BigInteger value = 0;                                   // value of the current member
        BigInteger prev = 0;                                    // the prvious member of the sequence
        BigInteger next = 1;                                    // the next member of the sequence
        BigInteger Sum = 0;                                     // the sum
        for (uint member = 1; member <= N; member++)
        {
            Thread.Sleep(40);                                   // the program will sleep for 40ms
            value = prev;
            prev = next;
            next = value + prev;
            Sum += value;                                       // the current sum of the sequence

            if (Sum.ToString().Length > 20)                     // for too long numbers
            {
                TaskMethods.Stat(member, (double)value, (double)Sum);
            }
            else
            {
                TaskMethods.Stat(member, value, Sum);
            }
            if ((double)Sum == 1 / (double)0)                   // if the current sum is Infinity
            {
                break;                                          // break the loop
            }
        }
        Console.Write("\nThe final sum is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine((double)Sum);                         // the final sum result
        Console.ResetColor();
    }
    static void Task8()
    {
        /* First variant */
        int x = 84;
        int y = 18;
        int res = 1;
        for (int i = 2; i <= Math.Max(x, y); i++)
        {
            if (x % i == 0 && y % i == 0)
            {
                if (i > res)
                {
                    res = i;
                }
            }
        }

        /* Second variant (Euclidean algorithm) */
        Console.WriteLine("Please, enter two numbers X and Y:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   X = ");
        int X = int.Parse(Console.ReadLine());
        Console.Write("   Y = ");
        int Y = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int remainder = 1;                                      // start with some remainder different from 0
        int numerator = Math.Max(X, Y);                         // the numerator is max of the two numbers
        int denominator = Math.Min(X, Y);                       // the denominator is min of the two numbers
        while (remainder != 0)                                  // the loop will stop when remainder = 0
        {
            remainder = numerator % denominator;
            numerator = denominator;
            denominator = remainder;
        }
        Console.Write("\nThe greatest common divisor of {0} and {1} is: ", X, Y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(numerator);                           // the result is numerator (the last denominator)
        Console.ResetColor();
    }
    static void Task9()
    {
        List<decimal> Numerator = new List<decimal>();      // list of numerator numbers
        List<decimal> Denominator = new List<decimal>();    // list of denominator numbers
        Console.WriteLine("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        uint N = uint.Parse(Console.ReadLine());
        Console.ResetColor();
        double Cn = 1;                                      // the Catalan number is 1 for N = 0
        for (uint i = N + 2; i <= 2 * N; i++)
        {
            Numerator.Add(i);                               // adds all numbers from N + 2 to 2N in Numerator list
        }
        for (uint j = 2; j <= N; j++)
        {
            Denominator.Add(j);                             // adds all numbers from 2 to N in Denominator list
        }
        for (int k = 0; k < N - 1; k++)                     // calculates each one multiplier
        {
            if (N == 0)
            {
                break;
            }
            Cn *= (double)(Numerator[k] / Denominator[k]);  // the Catalan number
        }
        Console.WriteLine("\nThe {0} Catalan number is:", N);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n          (2n)!    2n(2n-1)...(n+2)");
        Console.WriteLine("   Cn = ──────── = ──────────────── = {0}", Cn);
        Console.WriteLine("        (n+1)!n!          n!");
        Console.ResetColor();
    }
    static void Task10()
    {
        List<decimal> Numerator = new List<decimal>();      // list of numerator numbers
        List<decimal> Denominator = new List<decimal>();    // list of denominator numbers
        Console.WriteLine("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n   N = ");
        uint N = uint.Parse(Console.ReadLine());
        Console.ResetColor();
        double Cn = 1;                                      // the Catalan number is 1 for N = 0
        for (uint i = N + 2; i <= 2 * N; i++)
        {
            Numerator.Add(i);                               // adds all numbers from N + 2 to 2N in Numerator list
        }
        for (uint j = 2; j <= N; j++)
        {
            Denominator.Add(j);                             // adds all numbers from 2 to N in Denominator list
        }
        for (int k = 0; k < N - 1; k++)                     // calculates each one multiplier
        {
            if (N == 0)
            {
                break;
            }
            Cn *= (double)(Numerator[k] / Denominator[k]);  // the Catalan number
        }
        Console.WriteLine("\nThe {0} Catalan number is:", N);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n          (2n)!    2n(2n-1)...(n+2)");
        Console.WriteLine("   Cn = ──────── = ──────────────── = {0}", Cn);
        Console.WriteLine("        (n+1)!n!          n!");
        Console.ResetColor();
    }
    static void Task11()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        for (byte s = 0; s < 4; s++)                                        // loop for each one suit
        {
            for (byte i = 2; i <= 14; i++)                                  // loop for each one card
            {
                switch (s)                                                  // position of the name
                {
                    case 0: Console.SetCursorPosition(3, i - 1); break;     // for spades
                    case 1: Console.SetCursorPosition(27, i - 1); break;    // for hearts
                    case 2: Console.SetCursorPosition(51, i - 1); break;    // for diamonds
                    case 3: Console.SetCursorPosition(75, i - 1); break;    // for clubs
                }
                switch (i)                                                  // the names
                {
                    case 2: TaskMethods.Suits(" Two", s, "  2"); break;
                    case 3: TaskMethods.Suits(" Three", s, "3"); break;
                    case 4: TaskMethods.Suits(" Four", s, " 4"); break;
                    case 5: TaskMethods.Suits(" Five", s, " 5"); break;
                    case 6: TaskMethods.Suits(" Six", s, "  6"); break;
                    case 7: TaskMethods.Suits(" Seven", s, "7"); break;
                    case 8: TaskMethods.Suits(" Eight", s, "8"); break;
                    case 9: TaskMethods.Suits(" Nine", s, " 9"); break;
                    case 10: TaskMethods.Suits(" Ten", s, " 10"); break;
                    case 11: TaskMethods.Suits(" Jack", s, " J"); break;
                    case 12: TaskMethods.Suits(" Queen", s, "Q"); break;
                    case 13: TaskMethods.Suits(" King", s, " K"); break;
                    case 14: TaskMethods.Suits(" Ace", s, "  A"); break;
                }
            }
        }
        Console.ResetColor();
    }
    static void Task12()
    {
        int n = 0;
        while (n < 1 || n > 19)                                 // the number has to be from 1 to 19
        {
            Console.Clear();
            Console.Write("Enter some positive integer number (1-19): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            n = int.Parse(Console.ReadLine());                  // numbers for one row
            Console.ResetColor();
            if (n > 15 && n <= 19)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nThe height of the Console is too small\nPress any key to try again . . .");
                Console.ResetColor();
                n = 0;
                Console.ReadKey();
            }
        }

        /*Table */
        TaskMethods.T(2, n, '┌', '┐', '┬', '─');                // the 1st row
        TaskMethods.T(3, n, '│', '│', '│', ' ');                // the 2nd row
        for (int z = 3; z < 2 * n; z += 2)                      // if the rows are more than 1
        {
            TaskMethods.T(z + 1, n, '├', '┤', '┼', '─');
            TaskMethods.T(z + 2, n, '│', '│', '│', ' ');
        }
        TaskMethods.T(4 + 2 * (n - 1), n, '└', '┘', '┴', '─');  // the last row

        Thread.Sleep(500);                                      // the program will sleep for 500ms
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                TaskMethods.Number(j, i, TaskMethods.number);
                TaskMethods.number++;
            }
            TaskMethods.number = i + 1;
            Console.WriteLine();
        }
        Console.SetCursorPosition(0, 2 * n + 1);                // puts the cursor down of table 
        Console.WriteLine();
        TaskMethods.number = 1;
    }
    static void Task13()
    {
        Console.Write("Please, enter some positive integer number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\n   N = ");
        BigInteger N = BigInteger.Parse(Console.ReadLine());            // reads the number
        Console.ResetColor();
        if (N >= 0)                                                     // if the number is positive
        {
            BigInteger zeros = 0;                                       // start from 0 zeros
            BigInteger divider = 5;
            while (divider <= N)                                        // counts the zeros at the end of N!
            {
                zeros += N / divider;
                divider *= 5;
            }
            Console.Write("\nAt the end of N! there are ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(zeros);                                       // prints the result
            Console.ResetColor();
            Console.WriteLine(" trailing zeroes.");
        }
        else                                                            // if the number is not positive
        {
            throw new Exception();                                      // generates an exception
        }
    }
    static void Task14()
    {
        int n = 0;
        while (n < 1 || n > 19)                                     // the number has to be from 1 to 19
        {
            Console.Clear();
            Console.Write("Enter some positive integer number (1-19): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            n = int.Parse(Console.ReadLine());                      // numbers for one row
            Console.ResetColor();
            if (n > 15 && n <= 19)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nThe height of the Console is too small\nPress any key to try again . . .");
                Console.ResetColor();
                n = 0;
                Console.ReadKey();
            }
        }
        /*Table */
        TaskMethods.T(2, n, '┌', '┐', '┬', '─');                    // the 1st row
        TaskMethods.T(3, n, '│', '│', '│', ' ');                    // the 2nd row
        for (int z = 3; z < 2 * n; z += 2)                          // if the rows are more than 1
        {
            TaskMethods.T(z + 1, n, '├', '┤', '┼', '─');
            TaskMethods.T(z + 2, n, '│', '│', '│', ' ');
        }
        TaskMethods.T(4 + 2 * (n - 1), n, '└', '┘', '┴', '─');      // the last row

        Thread.Sleep(500);
        while (TaskMethods.number <= n * n)                         // one ring of numbers is one loop
        {
            TaskMethods.N(0, 4 * TaskMethods.i, 4 * (n - TaskMethods.i), 4);            // 1st part of the ring (left-to-right)
            TaskMethods.N(1, 2 * (TaskMethods.i + 1), 2 * (n - TaskMethods.i), 2);      // 2nd part of the ring (up-to-down)
            TaskMethods.N(0, 4 * (TaskMethods.i + 2 - n), 1 - 4 * TaskMethods.i, 4);    // 3rd part of the ring (right-to-left)
            TaskMethods.N(1, 2 * (TaskMethods.i + 2 - n), -2 * TaskMethods.i, 2);       // 4th part of the ring (down-to-top)
            TaskMethods.i++;                                                            // go to the next ring
        }
        Console.SetCursorPosition(0, 2 * n + 1);                    // remove the cursor from the center of the ring
        Console.WriteLine();
        TaskMethods.i = 0;
        TaskMethods.number = 1;
        TaskMethods.x = 0;
        TaskMethods.y = 0;
    }

    static void Exit()
    {
        Console.SetCursorPosition(47, 10);
        Console.ResetColor();
        Console.Write("Goodbye!");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
}

class TaskMethods
{
    public static void Stat(uint m, dynamic v, dynamic s)
    {
        Console.SetCursorPosition(3, 2);
        Console.Write("Member: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(m);
        Console.ResetColor();
        Console.SetCursorPosition(4, 3);
        Console.Write("Value: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(v);
        Console.WriteLine(new string(' ', 12));
        Console.ResetColor();
        Console.SetCursorPosition(6, 4);
        Console.Write("Sum: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(s);
        Console.WriteLine(new string(' ', 12));
        Console.ResetColor();
    }
    public static void Suits(string name, byte s, string i)
    {
        string[] Suit = { "spades   ", "hearts   ", "diamonds ", "clubs    ", "♠ ", "♥ ", "♦ ", "♣ " };
        Console.Write("{0} of {1}", name, Suit[s]);                         // the names of the cards
        switch (s)                                                          // the colors of suits
        {
            case 1: Console.ForegroundColor = ConsoleColor.Red; break;
            case 2: Console.ForegroundColor = ConsoleColor.Red; break;
            default: Console.ForegroundColor = ConsoleColor.Black; break;
        }
        Console.WriteLine("{0}{1}", i, Suit[s + 4]);                        // card figures       
        Console.ForegroundColor = ConsoleColor.Black;
    }
    public static int i = 0;                                           // this count each one ring of numbers 
    public static int x = 0;                                           // 'x' position
    public static int y = 0;                                           // 'y' position
    public static int number = 1;                                      // we start from number 1
    public static int z;                                               // value of x or y coordinate
    public static BigInteger Factorial(ulong n)                        // calculates the factorial
    {
        BigInteger r = 1;
        for (uint i = 1; i <= n; i++)
        {
            r *= i;
        }
        return r;
    }
    public static void Number(int num_j, int num_i, int num)           // position of the number
    {
        Thread.Sleep(150);
        Console.SetCursorPosition(4 * num_j + 1, 2 * num_i + 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(num);
        Console.ResetColor();
    }
    public static void N(int m, int start, int stop, int f)            // position of the number
    {
        for (z = start; z < stop; z += f)
        {
            Thread.Sleep(150);
            switch (m)                                          // x or y coordinate
            {
                case 0: Console.SetCursorPosition(Math.Abs(z) + 4, Math.Abs(y) + 3); break;
                case 1: Console.SetCursorPosition(Math.Abs(x) + 4, Math.Abs(z) + 3); break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(number);
            Console.ResetColor();
            number++;                                           // go to next number
        }
        switch (m)
        {
            case 0: x = z -= f; break;                          // distance between numbers;
            case 1: y = z -= f; break;                          // remove the previous "z += f"
        }
    }
    public static void T(int y, int n, char ch1, char ch2, char ch3, char space)   // one row of the table
    {
        Console.SetCursorPosition(3, y);
        Console.Write(ch1);                                     // the left character of the row
        Console.Write(new string(space, 4 * n - 1));            // the space between 'ch1' and 'ch2'
        Console.Write(ch2);                                     // the right character of the row
        for (int z = 7; z <= n * 4; z += 4)                     // marks the columns from the table
        {
            Console.SetCursorPosition(z, y);
            Console.Write(ch3);
        }
    }
}