//Task 3: Write a method that returns the last digit of given integer as an English word.
//        Examples: 512 → "two", 1024 → "four", 12309 → "nine".

using System;

class DigitToWord
{
    static void Main()
    {
        Console.Write("Please, enter some integer number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int number = int.Parse(Console.ReadLine());             // reads some integer number
        Console.ResetColor();
        Console.Write("The last digit is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ReturnsToWord(number));               // calls the "ReturnsToWord" method
        Console.ResetColor();
    }

    static string ReturnsToWord(int n)                          // method which returns a digit to word
    {
        switch (n % 10)                                         // checks what is the last digit of the number
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
        }
        return "";
    }
}