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
        Console.SetCursorPosition(47, 10);
        Console.Write("Welcome!");
        Thread.Sleep(2000);
    again:
        Console.Clear();
        while (true)
        {
            Content();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("   Please, select a task number from ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(9);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" or press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Esc");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" to exit: ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1: Tasks(1); break;
                case ConsoleKey.D2: Tasks(2); break;
                case ConsoleKey.D3: Tasks(3); break;
                case ConsoleKey.D4: Tasks(4); break;
                case ConsoleKey.D5: Tasks(5); break;
                case ConsoleKey.D6: Tasks(6); break;
                case ConsoleKey.D7: Tasks(7); break;
                case ConsoleKey.D8: Tasks(8); break;
                case ConsoleKey.D9: Tasks(9); break;
                case ConsoleKey.Escape: Exit(); break;
                default: goto again;
            }
        }
    }

    static void Content()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n\n\t\t\t\t\t     C# - Part 2\n");
        Console.WriteLine("\n   Homework 4. Numeral Systems");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
      Task 1: Write a program to convert decimal numbers to their binary representation.

      Task 2: Write a program to convert binary numbers to their decimal representation.

      Task 3: Write a program to convert decimal numbers to their hexadecimal representation.

      Task 4: Write a program to convert hexadecimal numbers to their decimal representation.

      Task 5: Write a program to convert hexadecimal numbers to binary numbers (directly).

      Task 6: Write a program to convert binary numbers to hexadecimal numbers (directly).

      Task 7: Write a program to convert from any numeral system of given base 's' to any
              other numeral system of base 'd' (2 <= s, d <= 16).

      Task 8: Write a program that shows the binary representation of given 16-bit signed
              integer number (the C# type short).

      Task 9: Write a program that shows the internal binary representation of given 32-bit
              signed floating-point number in IEEE 754 format (the C# type float).
              Example: -27,25 → sign = 1, exp = 10000011, mantissa = 10110100000000000000000.
                         ");
    }

    static void Exit()
    {
        Console.Clear();
        Console.SetCursorPosition(47, 10);
        Console.ResetColor();
        Console.Write("Goodbye!");
        Thread.Sleep(2000);
        Environment.Exit(0);
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
        byte?[] N = new byte?[32];                  // the number is type int, so the length is 32bits
        for (byte i = 0; i < N.Length; i++)         // fills the array with 0s
        {
            N[i] = 0;
        }
        Console.Write("Please, enter some integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int temp = num;
        if (num < 0)                                // if the number is negative
        {
            num = int.MaxValue + num + 1;
            N[N.Length - 1] = 1;                    // sets 1 on the leftmost bit
        }
        while (num > 0)                             // checks where are the 1s
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (Math.Pow(2, i + 1) > num)       // this finds where has to be 1
                {
                    N[i] = 1;                       // sets 1 for this bit
                    num -= (int)Math.Pow(2, i);     // decrease the number by this bit
                    break;
                }
            }
        }
        Array.Reverse(N);                           // reverses the array
        for (int i = 0; i < N.Length; i++)          // removes the first 0s from positive numbers
        {
            if (N[i] == 0)
            {
                N[i] = null;
            }
            else
            {
                break;
            }
        }
        Console.Write("Binary representation of this number is: ");
        if (temp != 0)                              // checks is the number equal to 0
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)                 // prints the result
            {
                Console.Write(item);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(0);
        }
        Console.ResetColor();
        Console.WriteLine();
    }
    static void Task2()
    {
        Console.Write("Please, enter some binary number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string binary = Console.ReadLine();                 // reads the binary number
        Console.ResetColor();
        long num = 0;
        for (int i = binary.Length - 1; i >= 0; i--)        // calculates the number by checking every bit
        {
            num += (binary[i] - 48) * (long)Math.Pow(2, binary.Length - i - 1);
        }
        Console.Write("Decimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(num);                             // prints the result
        Console.ResetColor();
    }
    static void Task3()
    {
        List<int> Hex = new List<int>();
        Console.Write("Please, enter some positive integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());            // reads the number
        Console.ResetColor();

        if (num < 0)                                        // if the number is negative
        {
            throw new Exception();
        }

        Console.Write("Hexadecimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        if (num == 0)                                       // if the number is equal to 0
        {
            Console.WriteLine(0);
        }
        while (num > 0)                                     // calculates the result
        {
            Hex.Add(num % 16);                              // adds each one value in array
            num /= 16;
        }
        Hex.Reverse();                                      // reverses the array

        string temp = "";
        foreach (var item in Hex)
        {
            switch (item)                                   // converts the big numbers to letter
            {
                case 10: temp = "A"; break;
                case 11: temp = "B"; break;
                case 12: temp = "C"; break;
                case 13: temp = "D"; break;
                case 14: temp = "E"; break;
                case 15: temp = "F"; break;
                default: temp = item.ToString(); break;
            }
            Console.Write(temp);                            // prints the result
        }
        Console.WriteLine();
        Console.ResetColor();
    }
    static void Task4()
    {
        Console.Write("Please, enter some hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string hex = Console.ReadLine();                            // reads the hexadecimal number
        Console.ResetColor();

        int temp, result = 0;
        for (int i = 0; i < hex.Length; i++)                        // checks the symbol is it capital or not
        {
            temp = hex[i] >= 'a' ? temp = hex[i] - 87 : (hex[i] >= 'A' ? temp = hex[i] - 55 : temp = hex[i] - 48);
            result += temp * (int)Math.Pow(16, hex.Length - i - 1); // calculates the result
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);                                  // prints the result
        Console.ResetColor();
    }
    static void Task5()
    {
        Console.Write("Please, enter some hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string hex = Console.ReadLine();                // reads the hexadecimal number
        Console.ResetColor();

        Console.Write("Binary representation of this number is: ");
        int temp;

        for (int i = 0; i < hex.Length; i++)            // checks the symbol is it capital or not
        {
            temp = hex[i] >= 'a' ? temp = hex[i] - 87 : (hex[i] >= 'A' ? temp = hex[i] - 55 : temp = hex[i] - 48);

            int?[] N = new int?[4];
            for (int j = 0; j < 4; j++)                 // fills the array with 0s
            {
                N[j] = 0;
            }
            while (temp > 0)                            // checks where are the 1s
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Math.Pow(2, j + 1) > temp)      // this finds where has to be 1
                    {
                        N[j] = 1;                       // sets 1 for this bit
                        temp -= (int)Math.Pow(2, j);    // decrease the number by this bit
                        break;
                    }
                }
            }
            Array.Reverse(N);
            if (i == 0)
            {
                for (int j = 0; j < 4; j++)             // removes the first 0s from the number
                {
                    if (N[j] == 0)
                    {
                        N[j] = null;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)
            {
                Console.Write(item);                    // prints the result
            }
            Console.ResetColor();
        }

        if (hex == "0")                                 // checks is the number equal to 0
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(0);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    static void Task6()
    {
        List<char> R = new List<char>();                            // List for result in hex representation
        Console.Write("Please, enter some binary number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string binary = Console.ReadLine();                         // reads the binary number
        Console.ResetColor();
        int max = 0;
        for (int i = 4; i <= 32; i += 4)                            // calculates the max lenght of the number
        {
            if (binary.Length <= i)
            {
                max = i;
                break;
            }
        }
        string Bin = new string('0', max - binary.Length) + binary; // puts 0s before the number to max length

        char[] B = Bin.ToCharArray();                               // imports the binary number in array B
        Array.Reverse(B);                                           // reverses the array

        for (int i = 0; i < B.Length; i += 4)                       // calculates the current hex number
        {
            int sum = 0;
            for (int k = 0; k < 4; k++)
            {
                sum += int.Parse(B[i + k].ToString()) * (int)Math.Pow(2, k);
            }
            char hex = ' ';
            hex = sum >= 10 ? (char)(sum + 55) : (char)(sum + 48);
            R.Add(hex);                                             // adds the current hex number in list R
        }
        R.Reverse();                                                // reverses the list
        Console.Write("Hexadecimal representation of this number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var item in R)                                     // prints the result
        {
            Console.Write(item);
        }
        Console.ResetColor();
        Console.WriteLine();
    }
    static void Task7()
    {
        byte from_base = 0;
        while (from_base < 2 || 16 < from_base)                     // is the base from 2 to 16
        {
            Console.Clear();
            Console.Write("Please, choose some numeral system (2-16): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            from_base = byte.Parse(Console.ReadLine());             // reads the base of given numeral system
            Console.ResetColor();
        }
        Console.Write("Please, enter some number from base-{0} numeral system: ", from_base);
        Console.ForegroundColor = ConsoleColor.Yellow;
        string X = Console.ReadLine();                              // the number in the given numeral system
        Console.ResetColor();

        // prints the table with all base-x numeral systems
        Console.WriteLine();
        Console.WriteLine("\t┌────────────────┬" + new string('─', 40) + "┐");
        Console.WriteLine("\t│ Numeral system │\t\tRepresentation\t\t  │");
        Console.WriteLine("\t├────────────────┼" + new string('─', 40) + "┤");

        for (byte to_base = 2; to_base <= 16; to_base++)            // for each one base will be used 'NumSystem' method
        {
            TaskMethods.NumSystem(from_base, to_base, X);
        }
        Console.WriteLine("\t└────────────────┴" + new string('─', 40) + "┘");
    }
    static void Task8()
    {
        byte[] N = new byte[16];                    // the number is type short, so the length is 16bits
        for (byte i = 0; i < N.Length; i++)         // fills the array with 0s
        {
            N[i] = 0;
        }
        Console.Write("Please, enter some signed integer number from type short: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int num = int.Parse(Console.ReadLine());
        Console.ResetColor();
        int temp = num;
        if (num < 0)                                // if the number is negative
        {
            num = short.MaxValue + num + 1;
            N[N.Length - 1] = 1;                    // sets 1 on the leftmost bit
        }
        while (num > 0)                             // checks where are the 1s
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (Math.Pow(2, i + 1) > num)       // this finds where has to be 1
                {
                    N[i] = 1;                       // sets 1 for this bit
                    num -= (int)Math.Pow(2, i);     // decrease the number by this bit
                    break;
                }
            }
        }
        Array.Reverse(N);                           // reverses the array
        Console.Write("Binary representation of this number is: ");
        if (temp != 0)                              // checks is the number equal to 0
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in N)                 // prints the result
            {
                Console.Write(item);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('0', 16));
        }
        Console.ResetColor();
        Console.WriteLine();
    }
    static void Task9()
    {
        Console.Write("Please, enter some floating-point number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        double number = double.Parse(Console.ReadLine());       // reads the floating-point number
        Console.ResetColor();
        int sign = 0;
        if (number < 0)                                         // is the number negative
        {
            sign = 1;
            number *= -1;                                       // makes the number positive
        }

        int exp = (int)(Math.Floor(Math.Log(number, 2)));       // calculates the exponent

        Console.WriteLine();
        Console.WriteLine("\t┌───────┬────────────────┬───────────────────────────────────┐");
        Console.WriteLine("\t│ Sign  │    Exponent    │             Mantissa              │");
        Console.WriteLine("\t├───────┼────────────────┼───────────────────────────────────┤");
        Console.Write("\t│   ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(sign);                                    // prints the sign
        Console.ResetColor();
        Console.Write("   │    ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(Convert.ToString(exp + 127, 2).PadLeft(8, '0'));      // prints the exponent
        Console.ResetColor();
        Console.Write("    │      ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(Convert.ToString((int)(Math.Round(number * Math.Pow(2, 23 - exp))) & ~(1 << 23), 2).PadLeft(23, '0'));
        Console.ResetColor();
        Console.WriteLine("      │");
        Console.WriteLine("\t└───────┴────────────────┴───────────────────────────────────┘");
    }
}

class TaskMethods
{
    public static void NumSystem(byte a, byte b, string X)
    {
        int temp, Decimal = 0;
        bool bigNumber = false;
        for (int i = X.Length - 1; i >= 0; i--)                     // converting the 'x' system to decimal numeral system
        {
            temp = X[i] >= 'a' ? temp = X[i] - 87 : (X[i] >= 'A' ? temp = X[i] - 55 : temp = X[i] - 48);
            Decimal += temp * (int)Math.Pow(a, X.Length - i - 1);   // the result from decimal number
            if (Decimal < 0)                                        // if the number is too big
            {
                bigNumber = true;
            }
        }
        List<char> R = new List<char>();
        char sym = ' ';
        while (Decimal > 0)                                         // converting from decimal to desired numeral system
        {
            sym = (Decimal % b) >= 10 ? (char)(Decimal % b + 55) : (char)(Decimal % b + 48);
            R.Add(sym);                                             // adding each one symbol in R list
            Decimal /= b;
        }
        R.Reverse();                                                // reverses the list
        string c = "";
        if (b.ToString().Length == 1)                               // fills the empty symbols to arrange the table
        {
            c = " ";
        }
        Console.SetCursorPosition(8, 4 + b);                        // sets the right position to print the result
        Console.Write("│");
        Console.ForegroundColor = a == b ? ConsoleColor.Yellow : ConsoleColor.Green;
        Console.Write("    Base-{0}{1}     ", b, c);
        Console.ResetColor();
        Console.Write("│   ");
        Console.ForegroundColor = a == b ? ConsoleColor.Yellow : ConsoleColor.Green;
        if (X == "0")
        {
            Console.Write(0);
            Console.ResetColor();
            Console.Write(new string(' ', 36) + "│");
        }
        else
        {
            if (bigNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Too big number!");
                Console.ResetColor();
            }
            else
            {
                foreach (var item in R)                             // prints the result for each one numeral system
                {
                    Console.Write(item);
                }
            }
            Console.ResetColor();
            if (bigNumber)
            {
                Console.Write(new string(' ', 22) + "│");
            }
            else
            {
                Console.Write(new string(' ', 37 - R.Count) + "│");
            }
        }
        Console.WriteLine();
    }
}