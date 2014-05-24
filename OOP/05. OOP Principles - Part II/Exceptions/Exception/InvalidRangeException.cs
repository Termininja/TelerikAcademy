using System;

namespace Exceptions
{
    class InvalidRangeException<T> : ApplicationException
    {
        // Field which hold an error message
        private static string ErrorMessage = "The value is not in the range!";

        // Properties
        public T Start { get; private set; }
        public T End { get; private set; }

        // Constructor
        public InvalidRangeException(T start, T end)
            : base(ErrorMessage)
        {
            this.Start = start;
            this.End = end;
        }
    }
}