//Task 4: Declare an integer variable and assign it with the value 254 in hexadecimal format.
//        Use Windows Calculator to find its hexadecimal representation.

using System;

class DeclareHexadecimal
{
    static void Main()
    {
        // Integer with assigned 254 in hexadecimal format
        int hexnumber = 0xFE;

        // Print the result
        Console.WriteLine("The hexadecimal value of {0} is {0:X}", hexnumber);
    }
}