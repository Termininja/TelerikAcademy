// Task 7: Write a method that reverses the digits of given decimal number.
//         Example: 25.6 → 6.52

using System;

class ReverseNumber
{
    static void Main()
    {
        // Reads some decimal number
        Console.Write("Please, enter some decimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        decimal number = decimal.Parse(Console.ReadLine());
        Console.ResetColor();

        // Prints the result
        Console.Write("The reversed number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Reverse(number));
        Console.ResetColor();
    }

    // Reverses the decimal number
    static decimal Reverse(decimal n)
    {
        // If the number is negative
        bool sign = false;
        if (n < 0)
        {
            // Keep the sign and makes the number positive
            sign = true;
            n *= -1;
        }

        // Converts the number to string
        string num = n.ToString();

        // Creates a new reversed number
        string newNum = String.Empty;
        for (int i = num.Length - 1; i >= 0; i--)
        {
            newNum += num[i];
        }

        // Converts the new number to decimal
        n = decimal.Parse(newNum);

        // If the sign was negative
        if (sign) n *= -1;

        // Returns the new reversed number
        return n;
    }
}