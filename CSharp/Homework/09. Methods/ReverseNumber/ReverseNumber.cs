//Task 7: Write a method that reverses the digits of given decimal number. Example: 256 → 652

using System;

class ReverseNumber
{
    static void Main()
    {
        Console.Write("Please, enter some decimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        decimal number = decimal.Parse(Console.ReadLine());     // reads some decimal number
        Console.ResetColor();
        Console.Write("The reversed number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Reverse(number));                     // prints the result by "Reverse" method
        Console.ResetColor();
    }

    static decimal Reverse(decimal n)                           // reverses the decimal number
    {
        bool sign = false;
        if (n < 0)                                              // if the number is negative
        {
            sign = true;                                        // keep the "-" sign
            n *= -1;                                            // makes the number positive
        }
        string num = n.ToString();                              // converts the number to string
        string newnum = "";
        for (int i = num.Length - 1; i >= 0; i--)               // checks all letters in the string
        {
            newnum += num[i];                                   // creates a new reversed number
        }
        n = decimal.Parse(newnum);                              // converts the new number to decimal
        if (sign)                                               // if the sign was negative
        {
            n *= -1;
        }
        return n;                                               // returns the new reversed number in Main method
    }
}