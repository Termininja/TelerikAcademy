//Task 3: Modify the application to print your name.

using System;

class WriteMyName
{
    static void Main()
    {
        Console.WriteLine("Write your name and press Enter");
        string name = Console.ReadLine();
        Console.WriteLine("\nYour name is: " + name);
    }
}