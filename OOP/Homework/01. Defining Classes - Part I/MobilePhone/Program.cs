/* Task 01: Define a class that holds information about a mobile phone device:
 *          model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk)
 *          and display characteristics (size and number of colors). Define 3 separate classes
 *          (class GSM holding instances of the classes Battery and Display).
 *          
 * Task 02: Define several constructors for the defined classes that take different sets of arguments
 *          (the full information for the class or part of it). Assume that model and manufacturer are mandatory
 *          (the others are optional). All unknown data fill with null.
 *          
 * Task 03: Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
 * 
 * Task 04: Add a method in the GSM class for displaying all information about it. Try to override ToString().
 * 
 * Task 05: Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
 *          Ensure all fields hold correct data at any given time.
 * 
 * Task 06: Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
 * 
 * Task 07: Write a class GSMTest to test the GSM class:
 *          Create an array of few instances of the GSM class.
 *          Display the information about the GSMs in the array.
 *          Display the information about the static property IPhone4S.
 * 
 * Task 08: Create a class Call to hold a call performed through a GSM.
 *          It should contain date, time, dialed phone number and duration (in seconds).
 * 
 * Task 09: Add a property CallHistory in the GSM class to hold a list of the performed calls.
 *          Try to use the system class List<Call>.
 * 
 * Task 10: Add methods in the GSM class for adding and deleting calls from the calls history.
 *          Add a method to clear the call history.
 * 
 * Task 11: Add a method that calculates the total price of the calls in the call history.
 *          Assume the price per minute is fixed and is provided as a parameter.
 * 
 * Task 12: Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
 *          Create an instance of the GSM class.
 *          Add few calls.
 *          Display the information about the calls.
 *          Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
 *          Remove the longest call from the history and calculate the total price again.
 *          Finally clear the call history and print it.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class Program
    {
        static void Main()
        {
            WindowSize();                   // change console width and height

            decimal callPrice = 0.37m;      // price per minute

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please, enter some test number:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": for GSMTest");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": for GSMCallHistoryTest");
                Console.ResetColor();
                ConsoleKeyInfo Input;

                // reads some input key (1 - for test1 and 2 for test2)
                do
                {
                    Input = Console.ReadKey();
                    Console.Write("\b \b");
                }
                while (Input.Key != ConsoleKey.D1 && Input.Key != ConsoleKey.D2);

                switch (Input.Key)
                {
                    case ConsoleKey.D1:                         // Test 1
                        GSMTest.CreateGSM();
                        GSMTest.PrintGSM();
                        break;
                    case ConsoleKey.D2:                         // Test 2
                        GSMCallHistoryTest.AddCalls();
                        GSMCallHistoryTest.PrintGSMs(callPrice);
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nDo you want to continue? (");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("N");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")");
                Console.ResetColor();

                ConsoleKeyInfo exit = Console.ReadKey();
                Console.Write("\b \b");
                while (exit.Key != ConsoleKey.Y && ConsoleKey.Y != ConsoleKey.N)
                {
                    if (exit.Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("\n");
                        continue;
                    }
                    else if (exit.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("\n");
                        Environment.Exit(0);
                    }
                    exit = Console.ReadKey();
                    Console.Write("\b \b");
                }
                Console.Clear();
            }
        }

        static void WindowSize()
        {
            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 34;
        }
    }
}
