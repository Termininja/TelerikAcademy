//Task 11*: Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
//	        0   → "Zero"
//	        273 → "Two hundred seventy three"
//	        400 → "Four hundred"
//	        501 → "Five hundred and one"
//	        711 → "Seven hundred and eleven"

using System;

class ConvertNumberToText
{
    static int number;
    static string[] N = new string[1000];                               // list of some basic number's names 

    static void Tens()                                                  // for two-digit numbers
    {
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
    static void Main()
    {
        N[1] = "one"; N[2] = "two"; N[3] = "three"; N[4] = "four"; N[5] = "five"; N[6] = "six";
        N[7] = "seven"; N[8] = "eight"; N[9] = "nine"; N[10] = "ten"; N[11] = "eleven"; N[12] = "twelve";
        N[13] = "thirteen"; N[14] = "fourteen"; N[15] = "fifteen"; N[16] = "sixteen"; N[17] = "seventeen";
        N[18] = "eighteen"; N[19] = "nineteen"; N[20] = "twenty"; N[30] = "thirty"; N[40] = "forty";
        N[50] = "fifty"; N[60] = "sixty"; N[70] = "seventy"; N[80] = "eighty"; N[90] = "ninety";

        Console.Write("Please, enter some integer number from 0 to 999: ");
        number = int.Parse(Console.ReadLine());

        Console.Write("The number is: ");
        if (number == 0)                                                // if the number is 0
        {
            Console.Write("zero");
        }
        else if (number > 0 && number < 1000)                           // if the number is between 0 and 1000
        {
            if (number > 99)                                            // for three-digit numbers
            {
                Console.Write(N[number / 100] + " hundred");            // prints the hundreds
                if (number % 100 > 0)                                   // if there are tens or ones
                {
                    Console.Write(" and ");
                    Tens();
                }
            }
            else                                                        // for two-digit numbers
            {
                Tens();
            }
        }
        Console.WriteLine();
    }
}
