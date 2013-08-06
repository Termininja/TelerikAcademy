//Task 7: Create a console application that prints the current date and time.

using System;

class CurrentDateTime
{
    static void Main()
    {
        Console.WriteLine("Today is " + DateTime.Now.ToString("dd MMMM yyyy (dddd)"));
        Console.WriteLine("The time is " + DateTime.Now.ToString("h:m:ss tt"));
    }
}