//Task 11: Declare two integer variables and assign them with 5 and 10 and after that exchange their values.

using System;

class DeclareTwoIntegers
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        int c = a;  //we create additional variable "c" which will hold the value of "a"
        a = b;      //moving the "b" value (10) to "a"
        b = c;      //moving the "c" value (5) to "b"
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
}