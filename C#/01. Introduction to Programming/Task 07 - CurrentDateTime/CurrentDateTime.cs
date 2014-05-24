//Task 7: Create a console application that prints the current date and time.

using System;
using System.Threading;

class CurrentDateTime
{
    static void Main()
    {
        // Print the date
        Console.WriteLine("Today is " + DateTime.Now.ToString("dd MMMM yyyy (dddd)"));

        // Looping until some key is pressed
        while (true)
        {
            // Set the cursor on column 0 and row 1
            Console.SetCursorPosition(0, 1);
            Console.Write("The time is ");

            // Print the time
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DateTime.Now.ToString("h:m:ss.ff tt\n"));
            Console.ResetColor();

            // Sleep the program for 90 milliseconds
            Thread.Sleep(90);

            // If some key is pressed
            Console.Write("Press any key to continue . . .");
            if (Console.KeyAvailable) break;
        }
    }
}