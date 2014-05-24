//Task 11: Declare two integer variables and assign them with
//         5 and 10 and after that exchange their values.

using System;

class DeclareTwoIntegers
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        // Exchange both values
        int temp = a;
        a = b;
        b = temp;

        // Print the result
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
}