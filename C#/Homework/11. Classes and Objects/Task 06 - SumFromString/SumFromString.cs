//Task6: You are given a sequence of positive integer values written
//       into a string, separated by spaces. Write a function that reads
//       these values from given string and calculates their sum.
//       Example: string = "43 68 9 23 318" → result = 461

using System;

public class SumFromString
{
    public static void Main()
    {
        // Reads and splits some sequence of integer values
        Console.Write("Please, enter some sequence of integer values: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string input = (Console.ReadLine().Trim());
        for (int i = 0; i < input.Length; i++)
        {
            // Remove all free spaces
            input = input.Replace("  ", " ");
        }

        string[] numbers = input.Split(' ');
        Console.ResetColor();

        // Calculates the sum
        int sum = 0;
        foreach (var item in numbers)
        {
            sum += int.Parse(item);
        }

        // prints the result
        Console.Write("The sum of these values is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(sum);
        Console.ResetColor();
    }
}