//Task 10: Write a program that applies bonus scores to given scores in the
//         range [1..9]. The program reads a digit as an input. If the digit
//         is between 1 and 3, the program multiplies it by 10; if it is
//         between 4 and 6, multiplies it by 100; if it is between 7 and 9,
//         multiplies it by 1000. If it is zero or if the value is not a digit,
//         the program must report an error. Use a switch statement and at the
//         end print the calculated new value in the console.

using System;

class ApplyBonusScores
{
    static void Main()
    {
        while (true)
        {
            // Read some user input key
            Console.Write("Enter some digit [1 - 9] or press [Q] to exit: ");
            ConsoleKeyInfo inputKey = Console.ReadKey();

            // Check the value of the key
            dynamic result = null;
            switch (inputKey.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                    result = int.Parse(inputKey.KeyChar.ToString()) * 10;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                    result = int.Parse(inputKey.KeyChar.ToString()) * 100;
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                    result = int.Parse(inputKey.KeyChar.ToString()) * 1000;
                    break;
                case
                ConsoleKey.Q: Environment.Exit(0);
                    break;
                default:
                    result = "Error!";
                    break;
            }

            // Print the result
            Console.WriteLine("\b{0}", result);
        }
    }
}