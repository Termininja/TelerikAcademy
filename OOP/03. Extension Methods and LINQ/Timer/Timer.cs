namespace Timer
{
    using System;

    public class Timer
    {
        // This method will be executed at each 't' seconds
        public static void Task()
        {
            Console.Write(DateTime.Now);
        }
    }
}