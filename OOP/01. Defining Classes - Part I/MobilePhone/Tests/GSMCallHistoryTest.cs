namespace MobilePhone.Tests
{
    using System;
    using System.Linq;
    using System.Threading;

    using MobilePhone.Phone;

    public static class GSMCallHistoryTest
    {
        private const decimal PricePerMinute = 0.37m;

        private static Random rand = new Random();

        internal static void Start()
        {
            Console.WriteLine("GSMCallHistoryTest start...");
            Thread.Sleep(1000);

            // Creates an instance of the GSM class and adds few calls.
            Console.Write("Add calls ");
            var gsm = new GSM("E72", "Nokia");
            for (int i = 0; i < 9; i++)
            {
                Thread.Sleep(500);
                gsm.AddCall(new Call(DateTime.Now, "088" + rand.Next(1000000, 9999999), rand.Next(1, 500)));
                Console.Write(".");
            }

            // Displays the information about the calls.
            Console.WriteLine("\n\n{0}", string.Join("\n", gsm.CallHistory));

            // Calculates and print the total price of the calls in the history.
            Console.WriteLine("\nTotal calls: {0}", gsm.CallHistory.Count);
            Console.WriteLine("Total price of the calls: {0:F2}", gsm.TotalPrice(PricePerMinute));

            var longestCall = gsm.CallHistory.OrderByDescending(call => call.Duration).First();
            Console.WriteLine("Longest call:");
            Console.WriteLine("\tDateTime: {0}", longestCall.DateTime);
            Console.WriteLine("\tDialledPhoneNumber: {0}", longestCall.DialledPhoneNumber);
            Console.WriteLine("\tDuration: {0}", longestCall.Duration);

            // Removes the longest call from the history and calculates the total price again.
            Thread.Sleep(1000);
            gsm.DeleteCall(longestCall);
            Console.WriteLine("\nRemove the longest call from the history...");
            Console.WriteLine("Total calls: {0}", gsm.CallHistory.Count);
            Console.WriteLine("Total price of the calls: {0:F2}", gsm.TotalPrice(PricePerMinute));

            // Clears the call history and print it.
            Console.WriteLine("\nClears the call history...");
            Thread.Sleep(1000);
            gsm.ClearCallHistory();
            Console.WriteLine("Total calls: {0}\n", gsm.CallHistory.Count);
        }
    }
}
