//Task 5: Declare a character variable and assign it with the symbol that has Unicode code 72.
//Hint: first use the Windows Calculator to find the hexadecimal representation of 72.

using System;

class DeclareChar
{
    static void Main()
    {
        char symbol = '\u0048';             // hexadecimal value of 72 is 48
        Console.WriteLine("The symbol with Unicode {0} is \"{1}\"", (int)symbol, symbol);
    }
}