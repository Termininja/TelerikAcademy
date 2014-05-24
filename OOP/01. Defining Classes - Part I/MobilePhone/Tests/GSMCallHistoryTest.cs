using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        static GSM[] gsms = new GSM[]           // array with some GSMs
        { 
            new GSM("LP-4", "Nokia"),
            new GSM("S37", "Samsung"),
            new GSM("E960","LG"),
            new GSM("C1505","Sony")
        };

        public static void AddCalls()
        {
            //GSM 1
            gsms[0].AddCall(new Call(DateTime.Parse("01.03.2012 14:27"), "0882784532", 135));
            gsms[0].AddCall(new Call(DateTime.Parse("04.03.2012 22:11"), "0888111608", 73));
            gsms[0].AddCall(new Call(DateTime.Parse("07.03.2012 18:01"), "0889900932", 457));
            gsms[0].AddCall(new Call(DateTime.Parse("07.03.2012 04:44"), "0882913590", 243));

            //GSM 2
            gsms[1].AddCall(new Call(DateTime.Parse("01.03.2012 03:09"), "0882098989", 1155));
            gsms[1].AddCall(new Call(DateTime.Parse("01.03.2012 05:01"), "0886338773", 944));
            gsms[1].AddCall(new Call(DateTime.Parse("11.03.2012 11:51"), "0886168533", 3243));

            //GSM 3
            gsms[2].AddCall(new Call(DateTime.Parse("01.03.2012 11:59"), "0882325033", 344));
            gsms[2].AddCall(new Call(DateTime.Parse("08.03.2012 21:21"), "0886999341", 874));
            gsms[2].AddCall(new Call(DateTime.Parse("09.03.2012 02:33"), "0889987359", 193));
            gsms[2].AddCall(new Call(DateTime.Parse("09.03.2012 14:30"), "0882930235", 47));

            //GSM 4
            gsms[3].AddCall(new Call(DateTime.Parse("10.03.2012 17:52"), "0886384330", 228));
            gsms[3].AddCall(new Call(DateTime.Parse("11.03.2012 07:42"), "0882953883", 120));
        }
        public static void PrintGSMs(decimal callPrice)
        {
            for (int n = 0; n < gsms.Length; n++)
            {
                Console.Clear();
                Console.WriteLine(gsms[n]);
                int longestCall = 0;            // the longest call
                int position = 0;               // position for longest call
                for (int c = 0; c < gsms[n].CallHistory.Count; c++)
                {
                    Console.WriteLine(gsms[n].CallHistory[c].ToString());
                    if (gsms[n].CallHistory[c].Duration >= longestCall)
                    {
                        longestCall = gsms[n].CallHistory[c].Duration;
                        position = c;
                    }
                }

                // calculate and print the total price of the calls in the history
                Console.WriteLine(new string('─', 45));
                Console.WriteLine("\n\tTotal price:\t{0:F2}", gsms[n].TotalPrice(callPrice));

                // remove the longest call from the history and calculate the total price again
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to remove the longest call from the history...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Write("\b \b");
                gsms[n].DeleteCall(position);
                Console.WriteLine("\n\tTotal price:\t{0:F2}", gsms[n].TotalPrice(callPrice));

                // clear the call history and print it
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to clear the call history...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Write("\b \b");
                gsms[n].ClearAllCalls();
                Console.WriteLine("\n\tTotal price:\t{0:F2}", gsms[n].TotalPrice(callPrice));

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