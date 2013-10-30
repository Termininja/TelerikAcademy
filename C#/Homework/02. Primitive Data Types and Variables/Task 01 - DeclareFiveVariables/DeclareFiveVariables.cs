//Task 1: Declare five variables choosing for each of them the most appropriate of the types:
//byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.

using System;

class DeclareFiveVariables
{
    static void Main()
    {        
        ushort value1 = 52130;  // the value is between 0 ÷ 65535
        sbyte value2 = -115;    // the value is between -128 ÷ 127
        int value3 = 4825932;   // the value is between -2147483648 ÷ 2147483647
        byte value4 = 97;       // the value is between 0 ÷ 255
        short value5 = -10000;  // the value is between -32768 ÷ 32767
        Console.WriteLine("value1 = " + value1 + "\t\t  → Type is {0}", value1.GetType().Name);  //
        Console.WriteLine("value2 = " + value2 + "\t\t  → Type is {0}", value2.GetType().Name);  //
        Console.WriteLine("value3 = " + value3 + "\t  → Type is {0}", value3.GetType().Name);    // Print the values and types
        Console.WriteLine("value4 = " + value4 + "\t\t  → Type is {0}", value4.GetType().Name);  //
        Console.WriteLine("value5 = " + value5 + "\t\t  → Type is {0}", value5.GetType().Name);  //
    }
}