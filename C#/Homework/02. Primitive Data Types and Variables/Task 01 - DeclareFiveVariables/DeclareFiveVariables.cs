//Task 1: Declare five variables choosing for each of them the most appropriate
//        of the types: byte, sbyte, short, ushort, int, uint, long, ulong to
//        represent the following values: 52130, -115, 4825932, 97, -10000.

using System;

class DeclareFiveVariables
{
    static void Main()
    {
        ushort value1 = 52130;      // the value is between 0 ÷ 65535
        sbyte value2 = -115;        // the value is between -128 ÷ 127
        int value3 = 4825932;       // the value is between -2147483648 ÷ 2147483647
        byte value4 = 97;           // the value is between 0 ÷ 255
        short value5 = -10000;      // the value is between -32768 ÷ 32767

        // Print the types and values
        Type(value1);
        Type(value2);
        Type(value3);
        Type(value4);
        Type(value5);
    }

    // Method which get and print the type of some value
    private static void Type<T>(T value)
    {
        Console.WriteLine("Type: {0,-15} → value = {1}", value.GetType().Name, value);
    }
}