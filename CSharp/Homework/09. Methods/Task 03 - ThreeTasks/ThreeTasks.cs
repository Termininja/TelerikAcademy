//Task13: Write a program that can solve these tasks: Reverses the digits of a number,
//        Calculates the average of a sequence of integers, and Solves a linear equation: a * x + b = 0.
//        Create appropriate methods. Provide a simple text-based menu for the user to choose which task to solve.
//        Validate the input data: The decimal number should be non-negative;
//        The sequence should not be empty; a should not be equal to 0

using System;

class ThreeTasks
{
    static void Main()
    {
        Console.WriteLine(@"Please, choose some  task number:
    1. Reverse the digits of a number.
    2. Calculates the average of a sequence of integers.
    3. Solves a linear equation: a*x+b=0.");

    tasks:
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)                                            // to select some task
        {
            case ConsoleKey.D1: Choose(1); Task1(); break;
            case ConsoleKey.D2: Choose(2); Task2(); break;
            case ConsoleKey.D3: Choose(3); Task3(); break;
            default: Console.Write("\b \b"); goto tasks;
        }
    }

    static void Choose(byte num)
    {
        Console.Write("\b \b\nYour choice was: ");
        Console.ForegroundColor = ConsoleColor.Yellow;              // yellow color for our choice
        Console.Write(num);
        Console.ResetColor();
        Console.WriteLine();
    }

    static void Task1()
    {
    task1:
        Console.Write("Please enter some decimal non-negative number: ");
        try                                                         // looks for errors
        {
            string number = Console.ReadLine();
            if (decimal.Parse(number) < 0)                          // if the number is negative
            {
                throw new Exception();
            }
            Console.Write("The reversed number is: ");
            for (int i = number.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i].ToString());                // reverse and prints the number
            }
            Console.WriteLine();
        }
        catch (Exception)
        {
            goto task1;                                             // repeats the task1 when there is some error
        }
    }

    static void Task2()
    {
    task2:
        try                                                         // looks for errors
        {
            Console.Write("Please, enter the number of elements in the sequence: ");
            int[] sequence = new int[int.Parse(Console.ReadLine())];

            int sum = 0;
            for (int i = 0; i < sequence.Length; i++)               // reads the sequence
            {
                Console.Write("Sequence[{0}] = ", i);
                sequence[i] = int.Parse(Console.ReadLine());
                if (sequence.Length == 1 && sequence[0] == 0)       // is the sequence empty
                {
                    throw new Exception();
                }
                sum += sequence[i];                                 // calculates the sum from all elements
            }
            Console.WriteLine("The average value of the sequence is: {0}", sum / sequence.Length);
        }
        catch (Exception)
        {
            goto task2;                                             // repeats the task2 when there is some error
        }
    }

    static void Task3()
    {
    task3:
        Console.WriteLine("Please, enter the coefficients:");
        try                                                         // looks for errors
        {
            Console.Write("a=");
            decimal a = decimal.Parse(Console.ReadLine());          // reads the 1st coefficient
            Console.Write("b=");
            decimal b = decimal.Parse(Console.ReadLine());          // reads the 2nd coefficient
            Console.WriteLine("a*x+b=0 => x={0}", (double)(-b / a));// prints the result from a*x+b=0
        }
        catch (Exception)
        {
            goto task3;                                             // repeats the task3 when there is some error
        }
    }
}