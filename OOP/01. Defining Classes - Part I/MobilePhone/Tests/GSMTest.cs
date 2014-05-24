using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    class GSMTest
    {
        static GSM[] gsms = new GSM[4];                         // array with different phones

        public static void CreateGSM()
        {
            // Creates an element with information about IPhone 4S
            gsms[0] = GSM.IPhone4S;

            // Creates a new GSM
            gsms[1] = new GSM("Galaxy S4", "Samsung");          // only with mandatory parameters

            // Creates a second GSM
            gsms[2] = new GSM(
                "E71", "Nokia",
                new Display(34, 16000),                         // information about the display
                new Battery("Bat", 50, 20, BatteryType.NiCd)    // information about the battery
                );
            gsms[2].Owner = "Ivan Ivanov";                      // sets the optional parameter "owner"
            gsms[2].Price = 175.85m;                            // sets the optional parameter "price"

            // Creates a third GSM
            gsms[3] = new GSM(
                "E400", "LG", "Dimitar Petrov", 210m,
                new Display(42, 36000),
                new Battery("KL34", 80, 57, BatteryType.NiMH)
                );
        }

        public static void PrintGSM()
        {
            // Display the information about all phones in array
            for (int n = 0; n < gsms.Length; n++)
            {
                Console.Clear();
                Console.WriteLine(gsms[n]);                     // prints the GSM info by using class GSMTest 

                if (n < gsms.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nPress << ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" >> to see next GSM");
                    Console.ResetColor();
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        Console.Write("\b \b");
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
