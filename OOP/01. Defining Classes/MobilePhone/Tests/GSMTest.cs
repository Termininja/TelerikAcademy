namespace MobilePhone.Tests
{
    using System;
    using System.Threading;

    using MobilePhone.Phone;

    public static class GSMTest
    {
        public static void Start()
        {
            Console.WriteLine("GSMTest start...");

            // Creates an array of few instances of the GSM class.
            var gsms = new GSM[] { 
                new GSM("E72", "Nokia", null, "Pesho", new Battery("Toshiba", 3, 5, BatteryType.NiCd)),
                new GSM("E1270", "Samsung", 34.8m, null, null, new Display(96, 256)),
                new GSM("C21", "Yezz", 259.99m, "Ivan", new Battery("Toshiba", 20, 14, BatteryType.LiIon), new Display(128, 256000))
            };

            // Displays the information about the GSMs in the array.
            foreach (var gsm in gsms)
            {
                Thread.Sleep(1000);
                Console.WriteLine("\n" + gsm);
            }

            // Displays the information about the static property IPhone4S.
            Thread.Sleep(1000);
            Console.WriteLine("\n{0}\n", GSM.IPhone4S);
            Thread.Sleep(1000);
        }
    }
}
