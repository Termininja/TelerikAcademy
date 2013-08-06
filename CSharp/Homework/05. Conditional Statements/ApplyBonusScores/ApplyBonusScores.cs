//Task 10: Write a program that applies bonus scores to given scores in the range [1..9].
//         The program reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10;
//         if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000.
//         If it is zero or if the value is not a digit, the program must report an error.
//         Use a switch statement and at the end print the calculated new value in the console.

using System;

class ApplyBonusScores
{
    static void Main()
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
}