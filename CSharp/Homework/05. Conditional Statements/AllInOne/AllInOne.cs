using System;
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
            Content();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("   To start some program, please enter a task number from 1 to 11 or type \"exit\" to exit: ");
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
                case "exit": Exit(); break;
            }
        }
    }

    static void Content()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n   Homework 5. Conditional Statements");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Write an if statement that examines two integer variables and exchanges their
              values if the first one is greater than the second one.
      Task 2: Write a program that shows the sign (+ or -) of the product of three real
              numbers without calculating it. Use a sequence of if statements.
      Task 3: Write a program that finds the biggest of 3 integers using nested if statements.
      Task 4: Sort 3 real values in descending order using nested if statements.
      Task 5: Write program that asks for a digit and depending on the input shows the name
              of that digit (in English) using a switch statement.
      Task 6: Write a program that enters the coefficients a, b and c of a quadratic equation
              a*x2 + b*x + c = 0 and calculates and prints its real roots.
              Note that quadratic equations may have 0, 1 or 2 real roots.
      Task 7: Write a program that finds the greatest of given 5 variables.
      Task 8: Write a program that, depending on the user's choice inputs int, double or string
              variable. If the variable is integer or double, increases it with 1. If the
              variable is string, appends ""*"" at its end. The program must show the value of
              that variable as a console output. Use switch statement.
      Task 9: We are given 5 integer numbers. Write a program that checks if the sum of some
              subset of them is 0. Example: 3, -2, 1, 1, 8 → 1+1-2=0.
     Task 10: Write a program that applies bonus scores to given scores in the range [1..9].
              The program reads a digit as an input. If the digit is between 1 and 3, the
              program multiplies it by 10; if it is between 4 and 6, multiplies it by 100;
              if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value
              is not a digit, the program must report an error. Use a switch statement and at
              the end print the calculated new value in the console.
     Task 11: Write a program that converts a number in the range 0-999 to a text corresponding
              to its English pronunciation. Examples: 0 - ""Zero""; 400 - ""Four hundred"";
              273 - ""Two hundred seventy three""; 501 - ""Five hundred and one"".
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
        Console.Write("Please, enter the 1st integer number: ");
        Console.Write("num1 = ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd integer number: ");
        Console.Write("num2 = ");
        int num2 = int.Parse(Console.ReadLine());

        if (num1 > num2)                                            // the two numbers will be exchanged only if num1 > num2
        {
            int temp = num1;                                        // we use a temporary variable to keep the value of the 1st number
            num1 = num2;
            num2 = temp;

            Console.WriteLine("\nThe first number is greater than the second one.");
            Console.WriteLine("Their values are exchanged: num1 = {0}, num2 = {1}", num1, num2);
        }
        else if (num1 < num2)
        {
            Console.WriteLine("\nThe second number is greater than the first one!");
        }
        else                                                        // if the two numbers are equal
        {
            Console.WriteLine("\nThe two numbers are equal!");
        }
    }
    static void Task2()
    {
        Console.Write("Please, enter how many numbers you want to compare: ");
        int limit = int.Parse(Console.ReadLine());

        int count = 0;                                                                  // this count the negative numbers
        bool zero = false;                                                              // is the number 0
        for (int i = 1; i <= limit; i++)                                                // we check the sign of all numbers from 1 to 'limit' 
        {
            Console.Write("Enter some real number: number {0} = ", i);
            decimal number = decimal.Parse(Console.ReadLine());
            if (number < 0)                                                             // if the current number is negative
            {
                count++;
            }
            else if (number == 0)                                                       // if the current number is 0
            {
                zero = true;
            }
        }
        if (zero)                                                                       // if we have some zero number
        {
            Console.WriteLine("\nThe result of the product is 0!");
        }

        else
        {
            if (count % 2 == 0)                                                         // if the count of negative numbers is even
            {
                Console.WriteLine("\nThe sign of the product of these {0} numbers is +", limit);
            }
            else
            {
                Console.WriteLine("\nThe sign of the product of these {0} numbers is -", limit);
            }
        }
    }
    static void Task3()
    {
        Console.Write("Please, enter the 1st integer number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 2nd integer number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the 3rd integer number: ");
        int num3 = int.Parse(Console.ReadLine());

        if (num1 == num2 && num2 == num3)                               // if the three numbers are equal
        {
            Console.WriteLine("The three numbers are equal!");
        }
        else if (num1 > num2 && num1 > num3)                            // if the 1st number is biggest
        {
            Console.WriteLine("The biggest number is {0}", num1);
        }
        else if (num2 > num1 && num2 > num3)                            // if the 2nd number is biggest
        {
            Console.WriteLine("The biggest number is {0}", num2);
        }
        else if (num3 > num1 && num3 > num2)                            // if the 3rd number is biggest
        {
            Console.WriteLine("The biggest number is {0}", num3);
        }
    }
    static void Task4()
    {
        int first = 0;
        int second = 0;
        int third = 0;
        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Please, enter the some real number: ");
            int number = int.Parse(Console.ReadLine());                         // for each 'i' we read one number
            if (i == 1)                                                         // if the number is only one
            {
                first = number;
            }
            else if (i == 2)                                                    // if we have two numbers
            {
                if (number >= first)                                            // if the second number is bigger
                {
                    second = first;
                    first = number;
                }
                else                                                            // if the second number is smaller
                {
                    second = number;
                }
            }
            else                                                                // if the numbers are three
            {
                if (number >= first)                                            // if the third number is biggest
                {
                    third = second;
                    second = first;
                    first = number;
                }
                else if (number <= second)                                      // if the third number is smallest 
                {
                    third = number;
                }
                else                                                            // if the third number is between the others
                {
                    third = second;
                    second = number;
                }
            }
        }
        Console.WriteLine("\nSorting: {0}, {1}, {2}", first, second, third);    // sorting
    }
    static void Task5()
    {
        Console.Write("Enter some digit from 0 to 9: ");
        byte digit = byte.Parse(Console.ReadLine());

        Console.SetCursorPosition(31, 0);
        switch (digit)
        {
            case 0: Console.WriteLine(" → Zero"); break;
            case 1: Console.WriteLine(" → One"); break;
            case 2: Console.WriteLine(" → Two"); break;
            case 3: Console.WriteLine(" → Three"); break;
            case 4: Console.WriteLine(" → Four"); break;
            case 5: Console.WriteLine(" → Five"); break;
            case 6: Console.WriteLine(" → Six"); break;
            case 7: Console.WriteLine(" → Seven"); break;
            case 8: Console.WriteLine(" → Eight"); break;
            case 9: Console.WriteLine(" → Nine"); break;
        }
    }
    static void Task6()
    {
        Console.Write("Please, enter the coefficient: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());                        // read the 1st coefficient 'a'
        Console.ResetColor();

        Console.Write("Please, enter the coefficient: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());                        // read the 2nd coefficient 'b'
        Console.ResetColor();

        Console.Write("Please, enter the coefficient: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());                        // read the 3rd coefficient 'c'
        Console.ResetColor();

        double D = Math.Pow(b, 2) - 4 * a * c;                              // the discriminant of quadratic equation

        if (D < 0)                                                          // if we don't have real roots
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe quadratic equation doesn't have real roots!");
            Console.ResetColor();
        }
        else if (D == 0)                                                    // if we have only one real root 'x'
        {
            double x = -b / 2 * a;
            Console.WriteLine("\nThe quadratic equation has only one real root:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t     -b");
            Console.WriteLine("\tx = ───── = {0}", Math.Round(x, 2));
            Console.WriteLine("\t     2.a");
            Console.ResetColor();
        }
        else                                                                // if we have two real roots 'x1' and 'x2'
        {
            double x1 = (-b + Math.Sqrt(D)) / 2 * a;
            double x2 = (-b - Math.Sqrt(D)) / 2 * a;
            Console.WriteLine("\nThe quadratic equation has two real roots:\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\t      -b + √D");
            Console.WriteLine("\tx1 = ───────── = {0}", Math.Round(x1, 2));
            Console.WriteLine("\t        2.a\n");

            Console.WriteLine("\t      -b - √D");
            Console.WriteLine("\tx2 = ───────── = {0}", Math.Round(x2, 2));
            Console.WriteLine("\t        2.a");

            Console.ResetColor();
        }
    }
    static void Task7()
    {
        double greatest = 0;                                                    // variable for the greatest number
        for (int n = 1; n <= 5; n++)                                            // checks each one number
        {
            Console.Write("Enter some number: ");
            double number = double.Parse(Console.ReadLine());
            if (n == 1)                                                         // if this is the 1st number
            {
                greatest = number;
            }
            else if (number >= greatest)                                        // if this is not the 1st number, checks is it bigger than greatest
            {
                greatest = number;
            }
        }
        Console.WriteLine("The greatest number is: {0}", greatest);
    }
    static void Task8()
    {
    start:
        Console.WriteLine("Please, choose:\n\n   I for int\n   D for double\n   S for string");
        ConsoleKeyInfo key = Console.ReadKey();                                     // reads the user's choice
        switch (key.Key)
        {
            case ConsoleKey.I:                                                      // if the choice is "Integer"
                Console.Clear();
                Console.Write("Please, enter some integer number: ");
                int Integer = int.Parse(Console.ReadLine());
                Console.WriteLine("The result is {0}", Integer + 1);
                break;
            case ConsoleKey.D:                                                      // if the choice is "Double"
                Console.Clear();
                Console.Write("Please, enter some number: ");
                double Double = double.Parse(Console.ReadLine());
                Console.WriteLine("The result is {0}", Double + 1);
                break;
            case ConsoleKey.S:                                                      // if the choice is "String"
                Console.Clear();
                Console.Write("Please, enter some string: ");
                string String = Console.ReadLine();
                Console.WriteLine("The result is {0}", String + "*");
                break;
            default:                                                                // if the choice is wrong
                Console.Clear();                                                    // clear the screen
                goto start;                                                         // go to top and ask the user again for some input
        }
    }
    static void Task9()
    {
        List<int> NumbersList = new List<int>();                            // List for the numbers
        List<int> TempList = new List<int>();                               // Temporary list for each one subset of 'NumbersList'

        Console.Write("Please, enter how many numbers you want to use: ");
        int limit = int.Parse(Console.ReadLine());                          // the limit of the numbers in 'NumbersList'
        for (int i = 1; i <= limit; i++)
        {
            Console.Write("Enter some integer number: n{0} = ", i);
            NumbersList.Add(int.Parse(Console.ReadLine()));                 // each one number is added in the list
        }
        for (int j = 0; j < Math.Pow(2, limit); j++)                        // checks each one combination of the numbers
        {
            int Sum = 0;                                                    // the sum of the numbers in the list
            bool CheckTheSum = false;                                       // variable which help us to check or not the sum
            for (int i = 0; i < limit; i++)
            {
                if ((j & (1 << i)) >> i == 1)                               // we use binary mode to find the numbers in the list
                {
                    TempList.Add(NumbersList[i]);                           // each one number is added in 'TempList'
                    Sum += NumbersList[i];                                  // the sum of the numbers in 'TempList'
                    CheckTheSum = true;                                     // this sum has to be checked
                }
            }
            if (Sum == 0 & CheckTheSum)                                     // checks whether the sum in 'TempList' is 0
            {
                Console.Write("\nThe sum of {");
                foreach (int temp in TempList)                              // prints all numbers from 'TempList'
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(temp);
                    Console.ResetColor();
                    Console.Write(",");
                }
                Console.Write("\b} is 0.");
            }
            TempList.Clear();                                               // clears all numbers in 'TempList'
        }
        Console.WriteLine();
    }
    static void Task10()
    {
        Console.Write("Please, enter some digit from 1 to 9: ");
        string score = Console.ReadLine();                                  // we use type string to catch all possible characters
        switch (score)
        {
            case "1":
            case "2":
            case "3":
                Console.WriteLine(int.Parse(score) * 10);                   // if the string is 1, 2 or 3, it is converted to number
                break;
            case "4":
            case "5":
            case "6":
                Console.WriteLine(int.Parse(score) * 100);                  // if the string is 4, 5 or 6, it is converted to number
                break;
            case "7":
            case "8":
            case "9":
                Console.WriteLine(int.Parse(score) * 1000);                 // if the string is 7, 8 or 9, it is converted to number
                break;
            default:                                                        // if the string is 0 or anything else
                Console.WriteLine("Error!");
                break;
        }
    }
    static void Task11()
    {
        int number;
        string[] N = new string[1000];
        N[1] = "one"; N[2] = "two"; N[3] = "three"; N[4] = "four"; N[5] = "five"; N[6] = "six";
        N[7] = "seven"; N[8] = "eight"; N[9] = "nine"; N[10] = "ten"; N[11] = "eleven"; N[12] = "twelve";
        N[13] = "thirteen"; N[14] = "fourteen"; N[15] = "fifteen"; N[16] = "sixteen"; N[17] = "seventeen";
        N[18] = "eighteen"; N[19] = "nineteen"; N[20] = "twenty"; N[30] = "thirty"; N[40] = "forty";
        N[50] = "fifty"; N[60] = "sixty"; N[70] = "seventy"; N[80] = "eighty"; N[90] = "ninety";

        Console.Write("Please, enter some integer number from 0 to 999: ");
        number = int.Parse(Console.ReadLine());

        Console.Write("The number is: ");
        if (number == 0)                                                            // if the number is 0
        {
            Console.Write("zero");
        }
        else if (number > 0 && number < 1000)                                       // if the number is between 0 and 1000
        {
            if (number > 99)                                                        // for three-digit numbers
            {
                Console.Write(N[number / 100] + " hundred");                        // prints the hundreds
                if (number % 100 > 0)                                               // if there are tens or ones
                {
                    Console.Write(" and ");
                    if (N[number % 100] != null)                                    // if the number is in the list N[] 
                    {
                        Console.Write(N[number % 100]);                             // prints the name of the number
                    }
                    else                                                            // if the number is not in the list N[] 
                    {
                        Console.Write(N[((number % 100) / 10) * 10]);               // prints the name of the tens
                        if (((number % 100) / 10) * 10 > 0 && number % 10 > 0)      // if tens and ones are > 0 
                        {
                            Console.Write("-");
                        }
                        Console.Write(N[number % 10]);                              // prints the name of the ones
                    }
                }
            }
            else                                                                    // for two-digit numbers
            {
                if (N[number % 100] != null)
                {
                    Console.Write(N[number % 100]);
                }
                else
                {
                    Console.Write(N[((number % 100) / 10) * 10]);
                    if (((number % 100) / 10) * 10 > 0 && number % 10 > 0)
                    {
                        Console.Write("-");
                    }
                    Console.Write(N[number % 10]);
                }
            }
        }
        else
        {
            Console.Write("\r                  ");
            throw new Exception();                                                  // creates Exception
        }
        Console.WriteLine();
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
