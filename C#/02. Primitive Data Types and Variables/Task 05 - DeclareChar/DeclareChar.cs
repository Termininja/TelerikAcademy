//Task 5: Declare a character variable and assign it with the symbol that has Unicode code 72.
//        Hint: first use the Windows Calculator to find the hexadecimal representation of 72.

using System;

class DeclareChar
{
    static void Main()
    {
        // Hexadecimal value of Unicode 72 is 48
        char symbol = '\u0048';

        // Print the result
        Console.WriteLine("The symbol with Unicode {0} is \'{1}\'", (int)symbol, symbol);
    }
}