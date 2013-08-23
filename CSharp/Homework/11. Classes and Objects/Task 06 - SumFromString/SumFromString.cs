//Task6: You are given a sequence of positive integer values written into a string, separated by spaces.
//       Write a function that reads these values from given string and calculates their sum.
//       Example: string = "43 68 9 23 318" → result = 461

using System;

class SumFromString
{
    static void Main()
    {
        Console.Write("Please, enter some sequence of integer values: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] numbers = Console.ReadLine().Split(' ');       // reads and splits the values
        Console.ResetColor();

        int sum = 0;
        foreach (var item in numbers)                           // checks each one value
        {
            sum += int.Parse(item);                             // sums the values
        }
        Console.Write("The sum of these values is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(sum);                                 // prints the result
        Console.ResetColor();
    }
}