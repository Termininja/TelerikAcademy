// Task13: Write a program that can solve these tasks: Reverses the digits of a number,
//         Calculates the average of a sequence of integers, and Solves a linear equation: a * x + b = 0.
//         Create appropriate methods. Provide a simple text-based menu for the user to choose which task to solve.
//         Validate the input data: The decimal number should be non-negative;
//         The sequence should not be empty; a should not be equal to 0

using System;

class ThreeTasks
{
    static void Main()
    {
        bool end = false;
        while (!end)
        {
            Console.WriteLine(@"Press [0] to exit
Press [1] to reverse the digits of some number
Press [2] to calculate the average of a sequence of integers
Press [3] to solve a linear equation: a*x+b=0");

            // What is the user choice
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0: end = true; continue;
                case ConsoleKey.D1: Choose(1); Task1(); break;
                case ConsoleKey.D2: Choose(2); Task2(); break;
                case ConsoleKey.D3: Choose(3); Task3(); break;
                default: Console.Clear(); continue;
            }

            // When some task finish
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void Choose(byte num)
    {
        Console.Write("\b \b\nYour choice was: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(num);
        Console.ResetColor();
        Console.WriteLine();
    }

    // Task 1: Reverse the digits of some number
    static void Task1()
    {
        while (true)
        {
            Console.Write("Please enter some decimal non-negative number: ");
            try
            {
                string number = Console.ReadLine();

                // if the number is negative
                if (decimal.Parse(number) < 0) throw new Exception();

                // Reverse and print the number
                Console.Write("The reversed number is: ");
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    Console.Write(number[i].ToString());
                }
                Console.WriteLine();
                break;
            }
            catch (Exception)
            {
                // Repeat the task if something wrong
                continue;
            }
        }
    }

    // Task 2: Calculate the average of a sequence of integers
    static void Task2()
    {
        while (true)
        {
            try
            {
                Console.Write("Please, enter the number of elements in the sequence: ");
                int[] sequence = new int[int.Parse(Console.ReadLine())];
                int sum = 0;
                for (int i = 0; i < sequence.Length; i++)
                {
                    // Reads the sequence
                    Console.Write("number[{0}] = ", i);
                    sequence[i] = int.Parse(Console.ReadLine());

                    // If the sequence is empty
                    if (sequence.Length == 1 && sequence[0] == 0) throw new Exception();

                    // Calculates the sum from all elements
                    sum += sequence[i];
                }
                Console.WriteLine("The average value of the sequence is: {0}", sum / sequence.Length);
                break;
            }
            catch (Exception)
            {
                // Repeat the task if something wrong
                continue;
            }
        }
    }

    // Task 3: Solve a linear equation
    static void Task3()
    {
        while (true)
        {
            Console.WriteLine("Please, enter the coefficients:");
            try
            {
                // Reads the 1st coefficient
                Console.Write("a=");
                decimal a = decimal.Parse(Console.ReadLine());

                // Reads the 2nd coefficient
                Console.Write("b=");
                decimal b = decimal.Parse(Console.ReadLine());

                // Prints the result
                string sign = "+";
                if (b < 0) sign = String.Empty;
                Console.WriteLine("ax+b=0 => {0}x{1}{2}=0 => x={3}", a, sign, b, (double)(-b / a));
                break;
            }
            catch (Exception)
            {
                // Repeat the task if something wrong
                continue;
            }
        }
    }
}