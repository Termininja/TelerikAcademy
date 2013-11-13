//Task 5: Write program that asks for a digit and depending on the input shows
//        the name of that digit (in English) using a switch statement.

using System;

class NameOfDigit
{
    static void Main()
    {
        // Read some digit
        Console.Write("Enter some digit from 0 to 9: ");
        switch (byte.Parse(Console.ReadLine()))
        {
            // Print the result
            case 0: Console.Write("This is Zero\n"); break;
            case 1: Console.Write("This is One\n"); break;
            case 2: Console.Write("This is Two\n"); break;
            case 3: Console.Write("This is Three\n"); break;
            case 4: Console.Write("This is Four\n"); break;
            case 5: Console.Write("This is Five\n"); break;
            case 6: Console.Write("This is Six\n"); break;
            case 7: Console.Write("This is Seven\n"); break;
            case 8: Console.Write("This is Eight\n"); break;
            case 9: Console.Write("This is Nine\n"); break;
            default: break;
        }
    }
}