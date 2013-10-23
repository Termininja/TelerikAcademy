using System;

namespace Exceptions
{
    class InvalidRangeException<T>
    {
        public string ErrorMessage { get; set; }

        public void ErrorCondition<T>(T value, T start, T end) where T : IComparable
        {
            if (value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0)
            {
                Console.Write(ErrorMessage);
            }
            else
            {
                Console.Write("ok");
            }
        }
    }
}