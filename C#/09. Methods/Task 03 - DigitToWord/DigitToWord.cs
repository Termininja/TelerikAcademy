// Task 3: Write a method that returns the last digit of given integer as an English word.
//         Examples: 512 → "two", 1024 → "four", 12309 → "nine".

using System;

class DigitToWord
{
    static void Main()
    {
        // Reads some integer number
        Console.Write("Please, enter some integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());
        Console.ResetColor();

        // Print the result
        Console.Write("The last digit is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ReturnsToWord(number));
        Console.ResetColor();
    }

    // Returns a digit to word
    static string ReturnsToWord(int n)
    {
        // Checks what is the last digit of the number
        switch (n % 10)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: return String.Empty;
        }
    }
}